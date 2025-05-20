using System;

namespace GAT.Core.Devices.Gen7.Commands
{
    public class CommandNameAttribute : Attribute
    {
        public string Name { get; private set; }

        public CommandNameAttribute(string name)
        {
            Name = name;
        }
    }
}
