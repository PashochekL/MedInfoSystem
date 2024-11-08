using System.Text.Json.Serialization;

namespace MedInfoSystem.Data.Entities.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Sorting
    {
        NameAsc,
        NameDesc,
        CreateAsc,
        CreateDesc,
        InspectionAsc,
        InspectionDesc
    }
}