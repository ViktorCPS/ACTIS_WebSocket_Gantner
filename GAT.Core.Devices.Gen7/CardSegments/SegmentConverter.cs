using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace GAT.Core.Devices.Gen7.CardSegments
{
    public class SegmentConverter : JsonConverter
    {
        private static JsonSerializerSettings _specifiedSubclassConversion = new JsonSerializerSettings() { ContractResolver = new SegmentSpecifiedConcreteClassConverter() };

        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(Segment));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);

            try
            {
                switch ((Segment.SegmentTypes)Enum.Parse(typeof(Segment.SegmentTypes), jo["SegmentType"].Value<string>()))
                {
                    case Segment.SegmentTypes.LOCKER:
                        return JsonConvert.DeserializeObject<LockerSegment>(jo.ToString(), _specifiedSubclassConversion);

                    case Segment.SegmentTypes.BARCODE_DATA:
                        return JsonConvert.DeserializeObject<BarcodeSegment>(jo.ToString(), _specifiedSubclassConversion);

                    case Segment.SegmentTypes.FIU:
                        return JsonConvert.DeserializeObject<FingerprintSegment>(jo.ToString(), _specifiedSubclassConversion);

                    case Segment.SegmentTypes.WIEGAND_DATA:
                        return JsonConvert.DeserializeObject<WiegandSegment>(jo.ToString(), _specifiedSubclassConversion);

                    case Segment.SegmentTypes.GANTNER_TOKEN:
                        return JsonConvert.DeserializeObject<GantnerTokenSegment>(jo.ToString(), _specifiedSubclassConversion);

                    case Segment.SegmentTypes.CUSTOM:
                        return JsonConvert.DeserializeObject<CustomSegment>(jo.ToString(), _specifiedSubclassConversion);
                }
            }
            catch
            {
                return null;
            }
            throw new NotImplementedException();
        }

        public override bool CanWrite
        {
            get { return false; }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException(); // won't be called because CanWrite returns false
        }
    }
}
