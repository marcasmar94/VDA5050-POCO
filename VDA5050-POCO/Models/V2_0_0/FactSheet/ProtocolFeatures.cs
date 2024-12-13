using Newtonsoft.Json;
using VDA5050_POCO.Models.V2_0_0.Factsheet;

namespace VDA5050_POCO.Models.V2_0_0.FactSheet;

/// <summary>
/// Supported features for the VDA5050 protocol.
/// </summary>
public record ProtocolFeatures
{
    [JsonProperty(PropertyName = "optionalParameters", Required = Required.Always)]
    public required List<OptionalParameter> OptionalParameters { get; init; }

    [JsonProperty(PropertyName = "agvActions", Required = Required.Always)]
    public required List<AgvAction> AgvActions { get; init; }
}