using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;

namespace GAT.Core.Devices.Gen7.Commands.App
{
    [CommandName("App.SaveSpecialCards")]
    public class SaveSpecialCardsRequest : Request
    {
        public List<SpecialCardSet> SpecialCardSets { get; set; }

        public class SpecialCardSet
        {
            [JsonConverter(typeof(StringEnumConverter))]
            public Types Type { get; set; }
            public List<string> UIDs { get; set; }
            public enum Types
            {
                MASTER,
                SERVICE,
                OPENMASTER,
                MAINTENANCE
            }
        }

    }
}
