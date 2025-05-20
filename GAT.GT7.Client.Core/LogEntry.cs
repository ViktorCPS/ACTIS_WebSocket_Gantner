using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GAT.GT7.Client.Core
{
    public class LogEntry
    {
        private string _formattedMessage;

        public DateTime Date { get; set; }
        public LogEntryTypeEnum Type { get; set; }
        public string Message { get; set; }
        public string MessageFormatted
        {
            get
            {
                if (string.IsNullOrEmpty(_formattedMessage) && string.IsNullOrEmpty(Message) == false)
                {
                    try
                    {
                        dynamic data = JsonConvert.DeserializeObject(Message);
                        if (data != null)
                        {
                            _formattedMessage = JsonConvert.SerializeObject(data, Formatting.Indented);
                        }
                    }
                    catch (Exception)
                    {
                    }
                }

                return _formattedMessage;
            }
        }
    }
    public enum LogEntryTypeEnum
    {
        [Display(Name = "Connected")]
        Connected,
        [Display(Name = "Disconnected")]
        Disconnected,
        [Display(Name = "Data received")]
        DataReceived,
        [Display(Name = "Data sent")]
        DataSent,
        [Display(Name = "Message")]
        Message
    }
}
