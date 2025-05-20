using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;

namespace GAT.Core.Devices.Gen7.CardSegments
{
    public class SegmentSpecifiedConcreteClassConverter : DefaultContractResolver
    {
        protected override JsonConverter ResolveContractConverter(Type objectType)
        {
            if (typeof(Segment).IsAssignableFrom(objectType) && !objectType.IsAbstract)
                return null; // pretend TableSortRuleConvert is not specified (thus avoiding a stack overflow)
            return base.ResolveContractConverter(objectType);
        }
    }
}
