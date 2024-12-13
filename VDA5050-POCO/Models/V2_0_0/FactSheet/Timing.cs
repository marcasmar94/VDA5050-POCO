using Newtonsoft.Json;

namespace VDA5050_POCO.Models.V2_0_0.FactSheet;

/// <summary>
/// Timing information used in the VDA5050 protocol.
/// </summary>
public record Timing
{
    [JsonProperty(PropertyName = "minOrderInterval", Required = Required.Always)]
    public required double MinOrderInterval { get; init; }

    [JsonProperty(PropertyName = "minStateInterval", Required = Required.Always)]
    public required double MinStateInterval { get; init; }

    [JsonProperty(PropertyName = "defaultStateInterval", NullValueHandling = NullValueHandling.Ignore)]
    public double? DefaultStateInterval { get; init; }

    [JsonProperty(PropertyName = "visualizationInterval", NullValueHandling = NullValueHandling.Ignore)]
    public double? VisualizationInterval { get; init; }
}