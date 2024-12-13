using Newtonsoft.Json;

namespace VDA5050_POCO.Models.V2_0_0.Common;

/// <summary>
/// Represents an action that the AGV can perform.
/// </summary>
public record Action
{
    /// <summary>
    /// Unique ID to identify the action and map it to the action state in the state.
    /// Suggestion: Use UUIDs.
    /// </summary>
    [JsonProperty(PropertyName = "actionId", Required = Required.Always)]
    public required string ActionId { get; init; }

    /// <summary>
    /// Name of the action as described in the first column of "Actions and Parameters".
    /// Identifies the function of the action.
    /// </summary>
    [JsonProperty(PropertyName = "actionType", Required = Required.Always)]
    public required string ActionType { get; init; }

    /// <summary>
    /// Additional information about the action.
    /// </summary>
    [JsonProperty(PropertyName = "actionDescription", NullValueHandling = NullValueHandling.Ignore)]
    public string? ActionDescription { get; init; }

    /// <summary>
    /// Regulates if the action is allowed to be executed during movement and/or parallel to other actions.
    /// NONE: action can happen in parallel with others, including movement.
    /// SOFT: action can happen simultaneously with others, but not while moving.
    /// HARD: no other actions can be performed while this action is running.
    /// </summary>
    [JsonProperty(PropertyName = "blockingType", Required = Required.Always)]
    public required BlockingType BlockingType { get; init; }

    /// <summary>
    /// List of parameters for the indicated action, e.g., deviceId, loadId, external triggers.
    /// </summary>
    [JsonProperty(PropertyName = "actionParameters", NullValueHandling = NullValueHandling.Ignore)]
    public List<ActionParameter>? ActionParameters { get; init; }
}

/// <summary>
/// Enum for regulating action blocking behavior.
/// </summary>
public enum BlockingType
{
    NONE,
    SOFT,
    HARD
}