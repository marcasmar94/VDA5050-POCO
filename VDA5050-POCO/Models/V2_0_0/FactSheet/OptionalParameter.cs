using Newtonsoft.Json;

namespace VDA5050_POCO.Models.V2_0_0.Factsheet;

/// <summary>
/// Describes a supported or required optional parameter in the VDA5050 protocol, allowing AGVs to define which optional elements they support.
/// </summary>
public record OptionalParameter
{
    /// <summary>
    /// Full name of the optional parameter, e.g., "order.nodes.nodePosition.allowedDeviationTheta"
    /// </summary>
    [JsonProperty(PropertyName = "parameter", Required = Required.Always)]
    public required string Parameter { get; init; }

    /// <summary>
    /// Describes if the parameter is supported or required.
    /// Possible values are SUPPORTED or REQUIRED.
    /// </summary>
    [JsonProperty(PropertyName = "support", Required = Required.Always)]
    public required string Support { get; init; }

    /// <summary>
    /// Free text to describe the reason for support or requirement of this optional parameter.
    /// </summary>
    [JsonProperty(PropertyName = "description", NullValueHandling = NullValueHandling.Ignore)]
    public string? Description { get; init; }
}