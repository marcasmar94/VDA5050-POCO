using Newtonsoft.Json;
namespace VDA5050_POCO.Models.V2_1_0.Common;


/// <summary>
/// Describes an action that the AGV can perform.
/// </summary>
[JsonObject]
public record Action
{
    /// <summary>
    /// Unique ID to identify the action and map it to the action state in the state.
    /// </summary>
    [JsonProperty("actionId", Required = Required.Always)]
    public required string ActionId { get; init; }

    /// <summary>
    /// Name of the action as described in the first column of Actions and Parameters. Identifies the function of the action.
    /// </summary>
    [JsonProperty("actionType", Required = Required.Always)]
    public required string ActionType { get; init; }

    /// <summary>
    /// Additional information on the action.
    /// </summary>
    [JsonProperty("actionDescription")]
    public string? ActionDescription { get; init; }

    /// <summary>
    /// Regulates if the action is allowed to be executed during movement and/or parallel to other actions.
    /// Possible values: NONE (can happen in parallel with movement), SOFT (can happen simultaneously but not while moving), HARD (no other actions can be performed while running).
    /// </summary>
    [JsonProperty("blockingType", Required = Required.Always)]
    public required BlockingType BlockingType { get; init; }

    /// <summary>
    /// Array of actionParameter objects for the indicated action, e.g., deviceId, loadId, external triggers.
    /// </summary>
    [JsonProperty("actionParameters")]
    public List<ActionParameter>? ActionParameters { get; init; }
}

/// <summary>
/// Represents the possible blocking types for an action.
/// NONE: Action can happen in parallel with others, including movement.
/// SOFT: Action can happen simultaneously with others, but not while moving.
/// HARD: No other actions can be performed while this action is running.
/// </summary>
[JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public enum BlockingType
{
    /// <summary>
    /// The action can happen in parallel with other actions, including movement.
    /// </summary>
    [JsonProperty("NONE")] NONE,

    /// <summary>
    /// The action can happen simultaneously with other actions, but not while moving.
    /// </summary>
    [JsonProperty("SOFT")] SOFT,

    /// <summary>
    /// No other actions can be performed while this action is running.
    /// </summary>
    [JsonProperty("HARD")] HARD
}

/// <summary>
/// Describes the parameters for an action that the AGV can perform.
/// </summary>
[JsonObject]
public record ActionParameter
{
    /// <summary>
    /// The key of the action parameter (e.g., duration, direction, signal).
    /// </summary>
    [JsonProperty("key", Required = Required.Always)]
    public required string Key { get; init; }

    /// <summary>
    /// The value of the action parameter. It can be a string, number, boolean, object, or array.
    /// </summary>
    [JsonProperty("value", Required = Required.Always)]
    public required object Value { get; init; }
}