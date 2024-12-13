using Newtonsoft.Json;

namespace VDA5050_POCO.Models.V2_0_0.FactSheet;


/// <summary>
/// Maximum lengths of string-based parameters.
/// </summary>
public record MaxStringLens
{
    [JsonProperty(PropertyName = "msgLen")]
    public int MsgLen { get; init; }

    [JsonProperty(PropertyName = "idLen")]
    public int IdLen { get; init; }

    [JsonProperty(PropertyName = "enumLen")]
    public int EnumLen { get; init; }
}