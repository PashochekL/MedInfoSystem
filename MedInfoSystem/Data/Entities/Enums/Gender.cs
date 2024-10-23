﻿using System.Text.Json.Serialization;

namespace MedInfoSystem.Data.Entities.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Gender
    {
        Male,
        Female
    }
}
