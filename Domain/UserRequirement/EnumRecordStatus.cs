using System.Text.Json.Serialization;

namespace Domain.UserRequirement
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum EnumRecordStatus
    {
        UNKNOWN = 0,
        INITIAL = 1,
        INPROGRESS = 2,
        COMPLETE = 3,
        ABORT = 4
    }
}
