using Newtonsoft.Json;

namespace VDA5050_POCO.Models.V2_1_0.FactSheet;

/// <summary>
/// Represents the supported features of the VDA5050 protocol.
/// </summary>
[JsonObject]
public record ProtocolFeatures
{
    /// <summary>
    /// List of supported and/or required optional parameters.
    /// Optional parameters, that are not listed here, are assumed to be not supported by the AGV.
    /// </summary>
    [JsonProperty("optionalParameters", Required = Required.Always)]
    public required List<OptionalParameter> OptionalParameters { get; init; }

    /// <summary>
    /// List of all actions with parameters supported by this AGV.
    /// This includes standard actions specified in VDA5050 and manufacturer-specific actions.
    /// </summary>
    [JsonProperty("agvActions", Required = Required.Always)]
    public required List<AgvAction> AgvActions { get; init; }
}

/// <summary>
/// Represents a supported optional parameter of the protocol.
/// </summary>
[JsonObject]
public record OptionalParameter
{
    /// <summary>
    /// Full name of the optional parameter, e.g., "order.nodes.nodePosition.allowedDeviationTheta".
    /// </summary>
    [JsonProperty("parameter", Required = Required.Always)]
    public required string Parameter { get; init; }

    /// <summary>
    /// Type of support for the optional parameter.
    /// Possible values:
    /// "SUPPORTED" - The optional parameter is supported as specified.
    /// "REQUIRED" - The optional parameter is required for proper AGV operation.
    /// </summary>
    [JsonProperty("support", Required = Required.Always)]
    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public required SupportType Support { get; init; }

    /// <summary>
    /// Free text description of the optional parameter.
    /// Example: Reason why the optional parameter 'direction' is necessary for this AGV type
    /// and which values it can contain. The parameter 'nodeMarker' must contain unsigned integer numbers only.
    /// </summary>
    [JsonProperty("description")]
    public string? Description { get; init; }
}

/// <summary>
/// Represents a supported AGV action in the protocol.
/// </summary>
[JsonObject]
public record AgvAction
{
    /// <summary>
    /// Unique action type corresponding to action.actionType.
    /// </summary>
    [JsonProperty("actionType", Required = Required.Always)]
    public required string ActionType { get; init; }

    /// <summary>
    /// Free text description of the action.
    /// </summary>
    [JsonProperty("actionDescription")]
    public string? ActionDescription { get; init; }

    /// <summary>
    /// List of allowed scopes for using this action type.
    /// Possible values: "INSTANT", "NODE", "EDGE".
    /// </summary>
    [JsonProperty("actionScopes", Required = Required.Always)]
    public required List<ActionScope> ActionScopes { get; init; }

    /// <summary>
    /// List of parameters for the action.
    /// If not defined, the action has no parameters.
    /// </summary>
    [JsonProperty("actionParameters")]
    public List<ActionParameter>? ActionParameters { get; init; }

    /// <summary>
    /// Free text description of the result description.
    /// </summary>
    [JsonProperty("resultDescription")]
    public string? ResultDescription { get; init; }

    /// <summary>
    /// Array of possible blocking types for the defined action.
    /// Possible values: "NONE", "SOFT", "HARD".
    /// </summary>
    [JsonProperty("blockingTypes")]
    public List<BlockingType>? BlockingTypes { get; init; }
}

/// <summary>
/// Represents an action parameter associated with an AGV action.
/// </summary>
[JsonObject]
public record ActionParameter
{
    /// <summary>
    /// Key string for the parameter.
    /// </summary>
    [JsonProperty("key", Required = Required.Always)]
    public required string Key { get; init; }

    /// <summary>
    /// Data type of the parameter value.
    /// Possible data types are: BOOL, NUMBER, INTEGER, FLOAT, STRING, OBJECT, ARRAY.
    /// </summary>
    [JsonProperty("valueDataType", Required = Required.Always)]
    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public required ValueDataType ValueDataType { get; init; }

    /// <summary>
    /// Free text description of the parameter.
    /// </summary>
    [JsonProperty("description")]
    public string? Description { get; init; }

    /// <summary>
    /// True if the parameter is optional.
    /// </summary>
    [JsonProperty("isOptional")]
    public bool? IsOptional { get; init; }
}

/// <summary>
/// Represents the support type for an optional parameter.
/// </summary>
public enum SupportType
{
    /// <summary>
    /// The optional parameter is supported as specified.
    /// </summary>
    SUPPORTED,

    /// <summary>
    /// The optional parameter is required for proper AGV operation.
    /// </summary>
    REQUIRED
}

/// <summary>
/// Represents the possible action scopes for an AGV action.
/// </summary>
public enum ActionScope
{
    /// <summary>
    /// The action can be used as an instant action.
    /// </summary>
    INSTANT,

    /// <summary>
    /// The action can be used on nodes.
    /// </summary>
    NODE,

    /// <summary>
    /// The action can be used on edges.
    /// </summary>
    EDGE
}

/// <summary>
/// Represents the possible blocking types for an AGV action.
/// </summary>
public enum BlockingType
{
    /// <summary>
    /// No blocking. The action can happen in parallel with others, including movement.
    /// </summary>
    NONE,

    /// <summary>
    /// Soft blocking. The action can happen simultaneously with others, but not while moving.
    /// </summary>
    SOFT,

    /// <summary>
    /// Hard blocking. No other actions can be performed while this action is running.
    /// </summary>
    HARD
}

/// <summary>
/// Represents the possible data types for an action parameter's value.
/// </summary>
public enum ValueDataType
{
    /// <summary>
    /// Boolean data type.
    /// </summary>
    BOOL,

    /// <summary>
    /// Number data type.
    /// </summary>
    NUMBER,

    /// <summary>
    /// Integer data type.
    /// </summary>
    INTEGER,

    /// <summary>
    /// Float data type.
    /// </summary>
    FLOAT,

    /// <summary>
    /// String data type.
    /// </summary>
    STRING,

    /// <summary>
    /// Object data type.
    /// </summary>
    OBJECT,

    /// <summary>
    /// Array data type.
    /// </summary>
    ARRAY
}