using Newtonsoft.Json;

namespace VDA5050_POCO.Models.V2_0_0.Common;

/// <summary>
/// Represents a key-value parameter for an action.
/// </summary>
public record ActionParameter
{
    /// <summary>
    /// The key of the action parameter.
    /// Examples: "duration", "direction", "signal".
    /// </summary>
    [JsonProperty(PropertyName = "key", Required = Required.Always)]
    public required string Key { get; init; }

    /// <summary>
    /// The value of the action parameter. Can be of type string, number, boolean, array, or object.
    /// </summary>
    [JsonProperty(PropertyName = "value", Required = Required.Always)]
    public required object Value { get; init; }
}