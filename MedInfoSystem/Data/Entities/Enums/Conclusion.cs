﻿using System.Text.Json.Serialization;

namespace MedInfoSystem.Data.Entities.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Conclusion
    {
        Recovery,
        Disease,
        Death
    }
}
