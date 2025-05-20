using GAT.Core.Devices.Gen7;
using GAT.Core.Devices.Gen7.Commands;
using GAT.Core.Devices.Gen7.Commands.App;
using GAT.Core.Devices.Gen7.Commands.General;
using GAT.Core.Devices.Gen7.Exceptions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using TaA = GAT.Core.Devices.Gen7.Commands.TaA;

namespace GAT.GT7.Client.Core
{
    public class MainViewModel
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<MainViewModel> _logger;
        private Gen7DeviceClient _device;

        private string _host = "192.168.1.133";
        private string _user = "System";
        private string _password = "GAT";
        private bool _isStarted;
        private bool _isConnected;
        private bool _isConnecting;
        private bool _autoScroll = true;
        private bool _allowAccess = true;
        private int _delay = 0;

        public string Host
        {
            get
            {
                return _host;
            }
            set
            {
                if (_host != value)
                {
                    _host = value;
                    OnPropertyChanged(nameof(Host));
                }
            }
        }

        public string User
        {
            get
            {
                return _user;
            }
            set
            {
                if (_user != value)
                {
                    _user = value;
                    OnPropertyChanged(nameof(User));
                }
            }
        }

        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged(nameof(_password));
                }
            }
        }

        public bool IsConnecting
        {
            get { return _isConnecting; }
            set
            {
                if (_isConnecting != value)
                {
                    _isConnecting = value;
                    OnPropertyChanged(nameof(IsConnecting));
                }
            }
        }

        public bool IsStarted
        {
            get
            {
                return _isStarted;
            }
            set
            {
                if (IsStarted != value)
                {
                    _isStarted = value;
                    OnPropertyChanged(nameof(IsStarted));
                }
            }
        }

        public bool IsConnected
        {
            get
            {
                return _isConnected;
            }
            set
            {
                if (_isConnected != value)
                {
                    _isConnected = value;
                    OnPropertyChanged(nameof(IsConnected));
                }
                if (IsStarted && !IsConnected)
                {
                    //connection lost.
                    _device.ConnectionStateChanged += Device_Reconnected;
                }
            }
        }

        public bool AutoScroll
        {
            get
            {
                return _autoScroll;
            }
            set
            {
                if (_autoScroll != value)
                {
                    _autoScroll = value;
                    OnPropertyChanged(nameof(AutoScroll));
                }
            }
        }

        public bool AllowAccess
        {
            get { return _allowAccess; }
            set
            {
                if (_allowAccess != value)
                {
                    _allowAccess = value;
                    OnPropertyChanged(nameof(AllowAccess));
                }
            }
        }

        public int Delay
        {
            get { return _delay; }
            set
            {
                if (_delay != value)
                {
                    _delay = value;
                    OnPropertyChanged(nameof(Delay));
                }
            }
        }

        public ObservableCollection<LogEntry> LogEntries { get; private set; } = new ObservableCollection<LogEntry>();

        public event PropertyChangedEventHandler PropertyChanged;

        public MainViewModel()
        {
            _serviceProvider = new ServiceCollection()
                .AddLogging(cfg => cfg.AddConsole()).Configure<LoggerFilterOptions>(cfg => cfg.MinLevel = LogLevel.Debug)
                .BuildServiceProvider();

            _logger = _serviceProvider.GetService<ILogger<MainViewModel>>();
        }

        /// <summary>
        /// Tasks to be done on a reconnect
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Device_Reconnected(object sender, ConnectionStateChangedArgs e)
        {
            if (e.IsConnected && e.HasLostConnection)
            {
                await Login();

                //Put additional reconnect logic here
            }
        }

        private async Task HandleCardIdentEvent(CardIdentEvent cardIdentEvent)
        {
            _logger.LogDebug($"Card ident received from {cardIdentEvent.UID}.");

            try
            {
                if (Delay != 0)
                {
                    AddLogEntry(new LogEntry { Message = string.Format($"Waiting for {Delay}ms until answering card ident."), Type = LogEntryTypeEnum.Message });
                    await Task.Delay(Delay);
                }

                if (AllowAccess)
                {
                    var response = await _device.SendRequestAsync<StartUnlockProcessRequest, StartUnlockProcessResponse>(new StartUnlockProcessRequest
                    {
                        DisplayText = "Access granted",
                        UnlockingTime_ms = 1000
                    });

                    _logger.LogDebug("Access granted");
                }
                else
                {
                    var response = await _device.SendRequestAsync<StartDenyProcessRequest, StartDenyProcessResponse>(new StartDenyProcessRequest
                    {
                        DisplayText = "Access denied"
                    });

                    _logger.LogDebug("Access denied");
                }
            }
            catch (RequestFailedException ex)
            {
                _logger.LogError(ex, "Failed to handle card ident.");
            }
        }

        private async Task HandlePersonIdentEvent(TaA.PersonIdentEvent personIdentEvent)
        {
            _logger.LogDebug($"Person ident received: IdType {(TaA.Entities.IdentificationType)personIdentEvent.IdType} / IdValue {personIdentEvent.IdValue} / IdValueType {personIdentEvent.IdValueType}");

            try
            {
                if (Delay != 0)
                {
                    AddLogEntry(new LogEntry { Message = string.Format($"Waiting for {Delay}ms until answering person ident."), Type = LogEntryTypeEnum.Message });
                    await Task.Delay(Delay);
                }

                if (AllowAccess)
                {
                    var response = await _device.SendRequestAsync<TaA.StartGrantProcessRequest, Response>(new TaA.StartGrantProcessRequest
                    {
                        DisplayText = "Booking created"
                    });

                    _logger.LogDebug("Booking created");
                }
                else
                {
                    var response = await _device.SendRequestAsync<TaA.StartDenyProcessRequest, StartDenyProcessResponse>(new TaA.StartDenyProcessRequest
                    {
                        DisplayText = "Booking not created"
                    });

                    _logger.LogDebug("Booking not created");
                }
            }
            catch (RequestFailedException ex)
            {
                _logger.LogError(ex, "Failed to handle person ident.");
            }
        }

        private void Device_CommunicationEvent(object sender, CommunicationEventArgs e)
        {
            AddLogEntry(new LogEntry { Message = e.Data, Type = e.Direction == CommunicationEventArgs.Directions.Incoming ? LogEntryTypeEnum.DataReceived : LogEntryTypeEnum.DataSent });
        }

        private void Device_ConnectionStateChanged(object sender, ConnectionStateChangedArgs e)
        {
            IsConnected = e.IsConnected;

            AddLogEntry(new LogEntry { Type = e.IsConnected ? LogEntryTypeEnum.Connected : LogEntryTypeEnum.Disconnected });
        }

        private void AddLogEntry(LogEntry entry)
        {
            entry.Date = DateTime.Now;

            if (Application.Current.Dispatcher.CheckAccess())
            {
                LogEntries.Add(entry);
            }
            else
            {
                Application.Current.Dispatcher.BeginInvoke(
                    DispatcherPriority.Background,
                   new Action(() => LogEntries.Add(entry)));
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #region Clear Communication command

        private RelayCommand _clearCommunicationCommand;

        public ICommand ClearCommunicationCommand
        {
            get
            {
                if (_clearCommunicationCommand == null)
                {
                    _clearCommunicationCommand = new RelayCommand(async param => await this.ClearCommunication(param),
                        param => this.CanClearCommunication(param));
                }
                return _clearCommunicationCommand;
            }
        }

        private bool CanClearCommunication(object param)
        {
            return LogEntries != null && LogEntries.Count > 0;
        }

        private async Task ClearCommunication(object param)
        {
            try
            {
                LogEntries.Clear();
            }
            catch (Exception ex)
            {
                AddLogEntry(new LogEntry { Type = LogEntryTypeEnum.Message, Message = $"Failed to clear communication: \"{ex.Message}\"" });
                _logger.LogError(ex, "Failed to clear communication");
            }
        }

        #endregion Clear Communication command

        #region Stop device command

        private RelayCommand _stopDeviceCommand;

        public ICommand StopDeviceCommand
        {
            get
            {
                if (_stopDeviceCommand == null)
                {
                    _stopDeviceCommand = new RelayCommand(async param => await this.StopDevice(param),
                        param => this.CanStopDevice(param));
                }
                return _stopDeviceCommand;
            }
        }

        private bool CanStopDevice(object param)
        {
            return IsStarted && !IsConnecting;
        }

        private async Task StopDevice(object param)
        {
            try
            {
                await _device.DisconnectAsync();
                _device.Dispose();
                _device = null;

                IsStarted = false;
            }
            catch (Exception ex)
            {
                AddLogEntry(new LogEntry { Type = LogEntryTypeEnum.Message, Message = $"Failed to stop device: \"{ex.Message}\"" });
                _logger.LogError(ex, "Failed to stop");
            }
        }

        #endregion Stop device command

        #region Start device command

        private RelayCommand _startDeviceCommand;

        public ICommand StartDeviceCommand
        {
            get
            {
                if (_startDeviceCommand == null)
                {
                    _startDeviceCommand = new RelayCommand(async param => await this.StartDevice(param),
                        param => this.CanStartDevice(param));
                }
                return _startDeviceCommand;
            }
        }

        private bool CanStartDevice(object param)
        {
            return !IsStarted && !IsConnecting;
        }

        private async Task StartDevice(object param)
        {
            try
            {
                IsConnecting = true;

                if (_device == null)
                {
                    _device = new Gen7DeviceClient(_serviceProvider.GetService<ILogger<Gen7DeviceClient>>());

                    _device.ConnectionStateChanged += Device_ConnectionStateChanged;
                    _device.CommunicationEvent += Device_CommunicationEvent;

                    await _device.RegisterEventListenerAsync<CardIdentEvent>(HandleCardIdentEvent);
                    await _device.RegisterEventListenerAsync<TaA.PersonIdentEvent>(HandlePersonIdentEvent);

                    _device.ReconnectInterval = 10000; //10s
                }

                await _device.ConnectAsync(Host, false);
                await Login();

                IsStarted = true;
            }
            catch (Exception ex)
            {
                AddLogEntry(new LogEntry { Type = LogEntryTypeEnum.Message, Message = $"Failed to start device: \"{ex.Message}\"" });
                _logger.LogError(ex, "Failed to start device");
            }
            finally
            {
                IsConnecting = false;
            }
        }

        private async Task Login()
        {
            try
            {
                await _device.SendRequestAsync<LoginRequest, LoginResponse>(new LoginRequest
                {
                    User = User,
                    Password = Convert.ToBase64String(Encoding.UTF8.GetBytes(Password)),
                    OnlineDecision = true,
                    Info = "DemoClient"
                });
            }
            catch (RequestFailedException rfe)
            {
                if (rfe.State == 1)
                {
                    throw new Exception("Could not login. Is user and password correct?", rfe);
                }
            }
        }

        #endregion Start device command
    }
}