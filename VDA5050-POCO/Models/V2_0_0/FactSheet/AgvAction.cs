using Newtonsoft.Json;

namespace VDA5050_POCO.Models.V2_0_0.Factsheet;

/// <summary>
/// Describes an action that the AGV can support as part of its operational capabilities in the VDA5050 protocol.
/// </summary>
public record AgvAction
{
    /// <summary>
    /// Unique action type corresponding to the "actionType" in VDA5050 actions.
    /// </summary>
    [JsonProperty(PropertyName = "actionType", Required = Required.Always)]
    public required string ActionType { get; init; }

    /// <summary>
    /// Free-text description of the action, provided to offer additional context or detail.
    /// </summary>
    [JsonProperty(PropertyName = "actionDescription", NullValueHandling = NullValueHandling.Ignore)]
    public string? ActionDescription { get; init; }

    /// <summary>
    /// List of allowed scopes where this action type can be used.
    /// Possible scopes are INSTANT, NODE, and EDGE.
    /// </summary>
    [JsonProperty(PropertyName = "actionScopes", Required = Required.Always)]
    public required List<string> ActionScopes { get; init; }

    /// <summary>
    /// List of all the parameters required for this action.
    /// If not defined, the action has no parameters.
    /// </summary>
    [JsonProperty(PropertyName = "actionParameters", NullValueHandling = NullValueHandling.Ignore)]
    public List<ActionParameter>? ActionParameters { get; init; }

    /// <summary>
    /// Describes the result that will be produced after the action is completed.
    /// </summary>
    [JsonProperty(PropertyName = "resultDescription", NullValueHandling = NullValueHandling.Ignore)]
    public string? ResultDescription { get; init; }

    /// <summary>
    /// Possible blocking types for the defined action.
    /// Possible values are NONE, SOFT, HARD.
    /// </summary>
    [JsonProperty(PropertyName = "blockingTypes", NullValueHandling = NullValueHandling.Ignore)]
    public List<string>? BlockingTypes { get; init; }
}

/// <summary>
/// Represents a parameter for an AGV action, which can have a specific type and be optional or required.
/// </summary>
public record ActionParameter
{
    /// <summary>
    /// Key name for the parameter (e.g., "duration", "signal", etc.).
    /// </summary>
    [JsonProperty(PropertyName = "key", Required = Required.Always)]
    public required string Key { get; init; }

    /// <summary>
    /// The data type of the parameter. Possible values are BOOL, NUMBER, INTEGER, FLOAT, STRING, OBJECT, ARRAY.
    /// </summary>
    [JsonProperty(PropertyName = "valueDataType", Required = Required.Always)]
    public required string ValueDataType { get; init; }

    /// <summary>
    /// Free text description of the parameter.
    /// </summary>
    [JsonProperty(PropertyName = "description", NullValueHandling = NullValueHandling.Ignore)]
    public string? Description { get; init; }

    /// <summary>
    /// Indicates if the parameter is optional. If true, this parameter is not required for the action.
    /// </summary>
    [JsonProperty(PropertyName = "isOptional", NullValueHandling = NullValueHandling.Ignore)]
    public bool? IsOptional { get; init; }
}