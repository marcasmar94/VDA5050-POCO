using Newtonsoft.Json;
namespace VDA5050_POCO.Models.V2_1_0.FactSheet;

/// <summary>
/// Represents the protocol limitations of the AGV. If a parameter is not defined or set to zero, then there is no explicit limit for this parameter.
/// </summary>
[JsonObject]
public record ProtocolLimits
{
    /// <summary>
    /// Maximum lengths of various strings used in the protocol.
    /// </summary>
    [JsonProperty("maxStringLens", Required = Required.Always)]
    public required MaxStringLengths MaxStringLens { get; init; }

    /// <summary>
    /// Maximum lengths of various arrays used in the protocol.
    /// </summary>
    [JsonProperty("maxArrayLens", Required = Required.Always)]
    public required MaxArrayLengths MaxArrayLens { get; init; }

    /// <summary>
    /// Timing information for message intervals.
    /// </summary>
    [JsonProperty("timing", Required = Required.Always)]
    public required Timing Timing { get; init; }
}

/// <summary>
/// Represents the maximum lengths of strings used in the protocol.
/// </summary>
[JsonObject]
public record MaxStringLengths
{
    /// <summary>
    /// Maximum MQTT message length.
    /// </summary>
    [JsonProperty("msgLen")]
    public int? MsgLen { get; init; }

    /// <summary>
    /// Maximum length of the serial-number part in MQTT topics.
    /// </summary>
    [JsonProperty("topicSerialLen")]
    public int? TopicSerialLen { get; init; }

    /// <summary>
    /// Maximum length of all other parts in MQTT topics.
    /// </summary>
    [JsonProperty("topicElemLen")]
    public int? TopicElemLen { get; init; }

    /// <summary>
    /// Maximum length of ID strings.
    /// </summary>
    [JsonProperty("idLen")]
    public int? IdLen { get; init; }

    /// <summary>
    /// If true, ID strings need to contain numerical values only.
    /// </summary>
    [JsonProperty("idNumericalOnly")]
    public bool? IdNumericalOnly { get; init; }

    /// <summary>
    /// Maximum length of ENUM and Key strings.
    /// </summary>
    [JsonProperty("enumLen")]
    public int? EnumLen { get; init; }

    /// <summary>
    /// Maximum length of load ID strings.
    /// </summary>
    [JsonProperty("loadIdLen")]
    public int? LoadIdLen { get; init; }
}

/// <summary>
/// Represents the maximum lengths of arrays used in the protocol.
/// </summary>
[JsonObject]
public record MaxArrayLengths
{
    [JsonProperty("order.nodes")]
    public int? OrderNodes { get; init; }

    [JsonProperty("order.edges")]
    public int? OrderEdges { get; init; }

    [JsonProperty("node.actions")]
    public int? NodeActions { get; init; }

    [JsonProperty("edge.actions")]
    public int? EdgeActions { get; init; }

    [JsonProperty("actions.actionsParameters")]
    public int? ActionsActionParameters { get; init; }

    [JsonProperty("instantActions")]
    public int? InstantActions { get; init; }

    [JsonProperty("trajectory.knotVector")]
    public int? TrajectoryKnotVector { get; init; }

    [JsonProperty("trajectory.controlPoints")]
    public int? TrajectoryControlPoints { get; init; }

    [JsonProperty("state.nodeStates")]
    public int? StateNodeStates { get; init; }

    [JsonProperty("state.edgeStates")]
    public int? StateEdgeStates { get; init; }

    [JsonProperty("state.loads")]
    public int? StateLoads { get; init; }

    [JsonProperty("state.actionStates")]
    public int? StateActionStates { get; init; }

    [JsonProperty("state.errors")]
    public int? StateErrors { get; init; }

    [JsonProperty("state.information")]
    public int? StateInformation { get; init; }

    [JsonProperty("error.errorReferences")]
    public int? ErrorErrorReferences { get; init; }

    [JsonProperty("information.infoReferences")]
    public int? InformationInfoReferences { get; init; }
}

/// <summary>
/// Represents the timing information for the protocol's message intervals.
/// </summary>
[JsonObject]
public record Timing
{
    /// <summary>
    /// Minimum interval for sending order messages to the AGV.
    /// </summary>
    [JsonProperty("minOrderInterval", Required = Required.Always)]
    public required double MinOrderInterval { get; init; }

    /// <summary>
    /// Minimum interval for sending state messages.
    /// </summary>
    [JsonProperty("minStateInterval", Required = Required.Always)]
    public required double MinStateInterval { get; init; }

    /// <summary>
    /// Default interval for sending state messages, if not defined the default value from the main document is used.
    /// </summary>
    [JsonProperty("defaultStateInterval")]
    public double? DefaultStateInterval { get; init; }

    /// <summary>
    /// Default interval for sending messages on the visualization topic.
    /// </summary>
    [JsonProperty("visualizationInterval")]
    public double? VisualizationInterval { get; init; }
}