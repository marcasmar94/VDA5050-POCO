using Newtonsoft.Json;

namespace VDA5050_POCO.Models.V2_0_0.FactSheet;



/// <summary>
/// Defines the protocol limits for the AGV system.
/// </summary>
public record ProtocolLimits
{
    [JsonProperty(PropertyName = "maxStringLens", Required = Required.Always)]
    public required MaxStringLens MaxStringLens { get; init; }

    [JsonProperty(PropertyName = "maxArrayLens", Required = Required.Always)]
    public required MaxArrayLens MaxArrayLens { get; init; }

    [JsonProperty(PropertyName = "timing", Required = Required.Always)]
    public required Timing Timing { get; init; }
}
