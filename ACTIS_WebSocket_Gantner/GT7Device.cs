using System;
using System.Collections;
using System.Data.Entity.Infrastructure;
using System.Net.WebSockets;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using ACTIS_WebSocket_Gantner.Models;
using GAT.Core.Devices.Gen7;
using GAT.Core.Devices.Gen7.Commands.App;
using GAT.Core.Devices.Gen7.Commands.General;
using GAT.Core.Devices.Gen7.Commands.System;
using GAT.Core.Devices.Gen7.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;

namespace ACTIS_WebSocket_Gantner
{
    public class GT7Device
    {
        private readonly ILogger<GT7Device> _logger;
        private readonly string _deviceId;
        private readonly Gen7DeviceServer _device;
        private static Actis3011aprilContext dbContext = new();
        /// <summary>
        /// Constructor for GT7Device.
        /// </summary>
        /// <param name="logger">logger only be functional if a log4Net file exists. in this docu we dont implement the logger fake it for our GAT.Core.Devices.Gen7</param>
        /// <param name="webSocket">websocket connection with G7 device.</param>
        /// <param name="deviceId">optional device Id.</param>
        public GT7Device(ILogger<GT7Device> logger, WebSocket webSocket, string deviceId)
        {
            _logger = logger;
            _deviceId = deviceId;
            _device = new Gen7DeviceServer(logger, webSocket);
        }

        /// <summary>
        /// Start communication if a device will connect via Websocket.
        /// </summary>
        /// <returns></returns>
        public async Task Start()
        {
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            // communication only works after "_device.Start()" but first we register events and request for communication with devie.
            RegisterRequestsToListener();
            RegisterEventsToListener();
            GetDeviceInfoRequest();
            SetHostInfo();
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed

            await _device.Start();
        }

        /// <summary>
        /// Set the Host Info on Device, you can see it on webinterface of GT7 in OverView under connections
        /// </summary>
        /// <returns></returns>
        private async Task SetHostInfo()
        {
            await _device.SendRequestAsync<SetHostInfoRequest, SetHostInfoResponse>(new SetHostInfoRequest() { OnlineDecision = true, Info = "Online servis je aktivan!" });
        }


        /// <summary>
        /// Register Request to the Listener. in this case the listener is the Server.
        /// </summary>
        /// <returns></returns>
        private async Task RegisterRequestsToListener()
        {
            _device.RegisterRequestListener<HeartbeatRequest, HeartbeatResponse>(HandleHeartbeatRequest);

        }

        /// <summary>
        /// Register events to the Listner. the Listener in this case is the Server.
        /// </summary>
        /// <returns></returns>
        private async Task RegisterEventsToListener()
        {
            await _device.RegisterEventListenerAsync<CardIdentEvent>(HandleCardIdentEvent);
            await _device.RegisterEventListenerAsync<LockStateChangedEvent>(HandleLockStateChagnedEvent);
            await _device.RegisterEventListenerAsync<LockRequestEvent>(HandleLockRequestEvent);
        }


        /// <summary>
        /// here i show you how you can send request from server to the device. only sends if the device is open (after Start()).
        /// As an example we Get Device Info with the GetDeviceInfoRequest.
        /// </summary>
        /// <returns></returns>
        private async Task GetDeviceInfoRequest()
        {
            var response = await _device.SendRequestAsync<GetDeviceInfoRequest, GetDeviceInfoResponse>(new GetDeviceInfoRequest());
        }

        /// <summary>
        /// If a Device establish a connection successfully it will send any 30 or 60 seconds a Hearbeat. With the Heartbeat the server and the device knows if 
        /// connection is open. 
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        private static async Task<HeartbeatResponse> HandleHeartbeatRequest(HeartbeatRequest arg)
        {
            HeartbeatResponse response = new()
            {
                HBI = 50,
                RT = DateTime.UtcNow
            };

            return response;
        }

        /// <summary>
        /// Anytime if a Lock state changes, a Device will send to the Server a LockstateChangedEvent
        /// </summary>
        /// <param name="event"></param>
        /// <returns></returns>
        private async Task HandleLockStateChagnedEvent(LockStateChangedEvent @event)
        {
            // here implement logic of handling LockStateChangedEvent
        }

        /// <summary>
        /// LockRequestEvent will execute from device if you show Card directly to a locker.
        /// </summary>
        /// <param name="event"></param>
        /// <returns></returns>
        private async Task HandleLockRequestEvent(LockRequestEvent lockRequestEvent)
        {

            // implement lockREquestEvent logic
        }

        /// <summary>
        /// CardidentEvent will be executed from device if you show Card directly by Terminal.
        /// </summary>
        /// <param name="cardIdentEvent"></param>
        /// <returns></returns>
        private async Task HandleCardIdentEvent(CardIdentEvent cardIdentEvent)
        {
            _logger.LogDebug($"Card ident received from {cardIdentEvent.UID}.");

            try
            {
                bool passValid = true;
                dbContext = new();
                if (await CheckRequest(cardIdentEvent.UID))
                {
                    var response = await _device.SendRequestAsync<StartUnlockProcessRequest, StartUnlockProcessResponse>(new StartUnlockProcessRequest { DisplayText = "Pristup dozvoljen. Dobrodosli!", UnlockingTime_ms = 5000 });
                    _logger.LogDebug("Pristup dozvoljen.");
                    await CheckLimitRemaining(cardIdentEvent.UID,passValid);
                }
                else
                {
                    var response = await _device.SendRequestAsync<StartDenyProcessRequest, StartDenyProcessResponse>(new StartDenyProcessRequest {DisplayText="Pristup nije dozvoljen!" });
                    _logger.LogDebug("Pristup nije dozvoljen.");
                    await CheckLimitRemaining(cardIdentEvent.UID, passValid);
                }
            }
            catch (RequestFailedException ex)
            {
                _logger.LogError(ex, "Failed to handle card ident.");
            }
        }

        private async Task<bool> CheckRequest(string UID)
        {
            bool isValid = true;
            try
            {
                //IZVLACENJE IZ dbContext info o terminalu,tiketu,dogadjaju,intervalu dnevnom za tu kartu za kapiju i provera da li je karta vazeca u tom trenutku
                ValidationTerminal vt = await dbContext.ValidationTerminals.Where(x => x.IpAddress == _deviceId && x.Status == "ENABLED").FirstOrDefaultAsync(); // izvlacenje terminala iz baze u odnosu na IP adresu
                List<Ticket> tickets = await dbContext.Tickets.Where(x => x.TicketId == UID && x.Status=="1").OrderBy(x => x.OrdNum).Include(x => x.TicketType).ToListAsync(); // svi ticketi sa ovim UID
                List<DailyInterval> dailyIntervals = []; // dnevni intervali za ovaj tip karte na kapijama
                List<WeekSchedulesXGate> weekSchedulesXGate = []; // intervaliXkapije
                List<Pass> passes = []; // prolasci za ovaj TicketID
                Ticket ticket = tickets[^1]; // poslednji ticket napravljen sa ovim TicketID
                Event ticket_event = new(); // dogadjaj za taj tip karte
                DailyInterval dailyInterval = new(); // dnevni interval koji je validan u trenutku cekiranja karte
                int gateId = -1, terminalId = -1; // kapija, terminal iz baze ID
                int day = (int)DateTime.Now.DayOfWeek;
                if (vt != null)
                {
                    gateId = vt.GateId;
                    terminalId = vt.ValidationTerminalId;
                }
                else
                {
                    isValid = false;
                }
                if (isValid && ticket != null && ticket.EventId != null)
                {
                    ticket_event = await dbContext.Events.Where(x=>x.EventId==ticket.EventId).FirstOrDefaultAsync();
                }
                else
                {
                    isValid = false;
                }
                if (isValid && ticket_event != null && ticket != null)
                {
                    weekSchedulesXGate = await dbContext.WeekSchedulesXGates.Where(x => x.WeekScheduleId == ticket.TicketType.WeekScheduleId && x.Day == day).ToListAsync();
                    foreach (var item in weekSchedulesXGate)
                    {
                        DailyInterval di = await dbContext.DailyIntervals.Where(x => x.DailyIntervalId == item.DailyIntervalId).FirstOrDefaultAsync();
                        if (di != null)
                            dailyIntervals.Add(di);
                    }
                    passes=await dbContext.Passes.Where(x=>x.TicketId== ticket.TicketId && x.OrdNum==ticket.OrdNum).ToListAsync();
                }
                else
                { isValid = false; }

                if (isValid && ticket != null && vt != null && ticket_event != null && weekSchedulesXGate != null)
                {
                    if (ticket.ValidFrom <= DateTime.Now && ticket.ValidTo > DateTime.Now && (ticket.LimitTotal > 0 || ticket.LimitTotal == -100) && ticket.Status == "1" && ticket_event.DateStart <= DateTime.Now && ticket_event.DateEnd > DateTime.Now)
                    {
                        foreach (var item in dailyIntervals)
                        {
                            DateTime startTimeItem = new DateTime(item.StartTime.Year, item.StartTime.Month, item.StartTime.Day, item.StartTime.Hour, item.StartTime.Minute, item.StartTime.Second);
                            DateTime endTimeItem = new DateTime(item.EndTime.Year, item.EndTime.Month, item.EndTime.Day, item.EndTime.Hour, item.EndTime.Minute, item.EndTime.Second);
                            DateTime currTime = new DateTime(item.StartTime.Year, item.StartTime.Month, item.StartTime.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
                            if (currTime >= startTimeItem && currTime <= endTimeItem)
                            {
                                isValid = true;
                                dailyInterval = item;
                                break;
                            }
                            isValid = false;
                        }
                        if (isValid && passes.Count > 0)
                        {
                            int? ticketTypeLimitTotal = ticket.TicketType.LimitRuleValue;
                            if (ticketTypeLimitTotal.HasValue && ticketTypeLimitTotal != -100)
                            {
                                if (passes.Count < ticketTypeLimitTotal)
                                {
                                    isValid = true;
                                }
                                else
                                    isValid = false;
                            }
                            else
                                isValid = true;
                        }
                        passes=passes.Where(x=>x.EventTime.Date==DateTime.Now.Date && x.OrdNum==ticket.OrdNum).ToList();
                        if (isValid && passes.Count > 0)
                        {
                            WeekSchedulesXGate tempSchWeek = await dbContext.WeekSchedulesXGates.Where(x => x.DailyIntervalId == dailyInterval.DailyIntervalId && x.WeekScheduleId == ticket.TicketType.WeekScheduleId && x.Day == day).Include(x=>x.WeekSchedule).FirstOrDefaultAsync();
                            int? dailyLimit = tempSchWeek.WeekSchedule.LimitDay;
                            int? intervalLimit = tempSchWeek.WeekSchedule.LimitInterval;
                            if(isValid && dailyLimit != null && dailyLimit != -100 && intervalLimit != null && intervalLimit != -100)
                            {
                                List<Pass> passInterval = passes.Where(x => x.EventTime.TimeOfDay >= dailyInterval.StartTime.TimeOfDay && x.EventTime.TimeOfDay <= dailyInterval.EndTime.TimeOfDay).ToList();
                                if (passes.Count >= dailyLimit || passInterval.Count >= intervalLimit)
                                    isValid = false;
                                else
                                    isValid= true;
                            }
                        }
                    }
                    else
                        isValid = false;
                    if (isValid)
                    {
                        Gate gate = await dbContext.Gates.Where(x => x.GateId == vt.GateId).FirstOrDefaultAsync();
                        await ProcessPass(ticket, vt, gate);
                    }
                    else
                        await UpdateTicket(ticket);
                }
            }
            catch (Exception ex)
            {
                isValid=false;
                _logger.LogError(ex, "Failed to handle card ident.");
            }
            return isValid;
        }

        private async Task UpdateTicket(Ticket ticketP)
        {
            if (ticketP != null)
            {
                List<Ticket> tickets = await dbContext.Tickets.Where(x => x.TicketId == ticketP.TicketId).OrderBy(x => x.OrdNum).ToListAsync();
                Ticket ticket = tickets[^1];
                ticket.ModifiedBy = "WS Service";
                ticket.ModifiedTime = DateTime.Now;
                ticket.RefuseMessage = "PRISTUP ODBIJEN! " + DateTime.Now.ToString("dd.MM.yyyy. HH:mm:ss");
                ticket.Status = "3";
                dbContext.Tickets.Update(ticket);
                await dbContext.SaveChangesAsync();
            }
        }

        private async Task CheckLimitRemaining(string UID, bool passValid)
        {
            try
            {
                if (passValid)
                {
                    List<Ticket> tickets = await dbContext.Tickets.Where(x => x.TicketId == UID).OrderBy(x => x.OrdNum).ToListAsync();
                    Ticket ticket = tickets[^1];
                    if (ticket != null)
                    {
                        if (ticket.LimitTotal == -100)
                        {

                            ticket.ModifiedBy = "WS Service";
                            ticket.ModifiedTime = DateTime.Now;
                            ticket.RefuseMessage = "PRISTUP DOZVOLJEN! " + DateTime.Now.ToString("dd.MM.yyyy. HH:mm:ss");
                            dbContext.Tickets.Update(ticket);
                            await dbContext.SaveChangesAsync();
                        }
                        else
                        {
                            if (ticket.LimitTotal > 0)
                            {
                                ticket.LimitTotal--;
                                if (ticket.LimitTotal == 0)
                                    ticket.Status = "3";
                                ticket.ModifiedBy = "WS Service";
                                ticket.ModifiedTime = DateTime.Now;
                                ticket.RefuseMessage = "PRISTUP DOZVOLJEN! " + DateTime.Now.ToString("dd.MM.yyyy. HH:mm:ss");
                                dbContext.Tickets.Update(ticket);
                                await dbContext.SaveChangesAsync();
                            }
                        }
                    } 
                }
                else
                {
                    List<Ticket> tickets = await dbContext.Tickets.Where(x => x.TicketId == UID).OrderBy(x => x.OrdNum).ToListAsync();
                    Ticket ticket = tickets[^1];
                    if (ticket != null)
                    {
                        ticket.ModifiedBy = "WS Service";
                        ticket.ModifiedTime = DateTime.Now;
                        ticket.RefuseMessage = "PRISTUP NIJE DOZVOLJEN! " + DateTime.Now.ToString("dd.MM.yyyy. HH:mm:ss");
                        dbContext.Tickets.Update(ticket);
                        await dbContext.SaveChangesAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to handle card ident."); 
            }
        }

        private async Task ProcessPass(Ticket ticket, ValidationTerminal vt, Gate gate)
        {
            try
            {
                Pass pass = new()
                {
                    TicketId = ticket.TicketId, //047003CAAA4884
                    OrdNum = ticket.OrdNum,
                    EventTime = DateTime.Now,
                    ValidationTerminalId = vt.ValidationTerminalId,
                    LocationId = gate.LocationId,
                    GateId = gate.GateId,
                    Direction = "IN",
                    CreatedBy = "WS Service",
                    CreatedTime = DateTime.Now
                };
                dbContext.Passes.Add(pass);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to insert into actismgr.passes table. Error is: " + ex.ToString());
            }
        }
    }
}