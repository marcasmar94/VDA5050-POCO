using Newtonsoft.Json;

namespace VDA5050_POCO.Models.V2_0_0.FactSheet;

/// <summary>
/// Maximum limits of array sizes used in the VDA5050 protocol.
/// </summary>
public record MaxArrayLens
{
    [JsonProperty(PropertyName = "order.nodes", Required = Required.Always)]
    public required int OrderNodes { get; init; }

    [JsonProperty(PropertyName = "order.edges", Required = Required.Always)]
    public required int OrderEdges { get; init; }

    [JsonProperty(PropertyName = "state.loads", Required = Required.Always)]
    public required int StateLoads { get; init; }
}