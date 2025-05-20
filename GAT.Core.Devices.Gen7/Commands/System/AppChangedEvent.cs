using System;

namespace GAT.Core.Devices.Gen7.Commands.System
{
    [CommandName("System.AppChanged")]
    public class AppChangedEvent : Event
    {
        /// <summary>
        /// 	App author
        /// </summary>
        public string Author { get; set; }
        /// <summary>
        /// 	App creation date
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// 	Full app name
        /// </summary>
        public string DisplayName { get; set; }
        /// <summary>
        /// 	Required licence points
        /// </summary>
        public int Level { get; set; }
        /// <summary>
        /// App name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// App version
        /// </summary>
        public string Version { get; set; }
    }
}
