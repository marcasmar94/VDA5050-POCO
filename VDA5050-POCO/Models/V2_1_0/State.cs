namespace VDA5050_POCO.Models.V2_1_0;

using System;
using System.Collections.Generic;
using Newtonsoft.Json;

/// <summary>
/// Represents the all-encompassing state of the AGV.
/// </summary>
[JsonObject]
public record State
{
    /// <summary>
    /// Header ID of the message. The headerId is defined per topic and incremented by 1 with each sent (but not necessarily received) message.
    /// </summary>
    [JsonProperty("headerId", Required = Required.Always)]
    public required int HeaderId { get; init; }

    /// <summary>
    /// Timestamp in ISO8601 format (YYYY-MM-DDTHH:mm:ss.ffZ).
    /// </summary>
    [JsonProperty("timestamp", Required = Required.Always)]
    public required DateTime Timestamp { get; init; }

    /// <summary>
    /// Version of the protocol [Major].[Minor].[Patch].
    /// </summary>
    [JsonProperty("version", Required = Required.Always)]
    public required string Version { get; init; }

    /// <summary>
    /// Manufacturer of the AGV.
    /// </summary>
    [JsonProperty("manufacturer", Required = Required.Always)]
    public required string Manufacturer { get; init; }

    /// <summary>
    /// Serial number of the AGV.
    /// </summary>
    [JsonProperty("serialNumber", Required = Required.Always)]
    public required string SerialNumber { get; init; }

    /// <summary>
    /// Array of map objects that are currently stored on the vehicle.
    /// </summary>
    [JsonProperty("maps")]
    public List<Map> Maps { get; init; } = new();

    /// <summary>
    /// Unique order identification of the current order or the previous finished order.
    /// </summary>
    [JsonProperty("orderId", Required = Required.Always)]
    public required string OrderId { get; init; }

    /// <summary>
    /// Order Update Identification to identify that an order update has been accepted by the AGV.
    /// </summary>
    [JsonProperty("orderUpdateId", Required = Required.Always)]
    public required int OrderUpdateId { get; init; }

    /// <summary>
    /// Unique ID of the zone set that the AGV currently uses for path planning.
    /// </summary>
    [JsonProperty("zoneSetId")]
    public string? ZoneSetId { get; init; }

    /// <summary>
    /// Node ID of last reached node or, if AGV is currently on a node, current node.
    /// </summary>
    [JsonProperty("lastNodeId", Required = Required.Always)]
    public required string LastNodeId { get; init; }

    /// <summary>
    /// Sequence ID of the last reached node or, if the AGV is currently on a node, sequence ID of current node.
    /// </summary>
    [JsonProperty("lastNodeSequenceId", Required = Required.Always)]
    public required int LastNodeSequenceId { get; init; }

    /// <summary>
    /// Indicates whether the AGV is driving and/or rotating.
    /// </summary>
    [JsonProperty("driving", Required = Required.Always)]
    public required bool Driving { get; init; }

    /// <summary>
    /// Indicates whether the AGV is currently in a paused state.
    /// </summary>
    [JsonProperty("paused")]
    public bool? Paused { get; init; }

    /// <summary>
    /// Indicates if a new base request is required.
    /// </summary>
    [JsonProperty("newBaseRequest")]
    public bool? NewBaseRequest { get; init; }

    /// <summary>
    /// Distance driven past the last node in meters.
    /// </summary>
    [JsonProperty("distanceSinceLastNode")]
    public double? DistanceSinceLastNode { get; init; }

    /// <summary>
    /// Current operating mode of the AGV.
    /// </summary>
    [JsonProperty("operatingMode", Required = Required.Always)]
    public required string OperatingMode { get; init; }

    /// <summary>
    /// Array of node state objects.
    /// </summary>
    [JsonProperty("nodeStates", Required = Required.Always)]
    public required List<NodeState> NodeStates { get; init; } = new();

    /// <summary>
    /// Array of edge state objects.
    /// </summary>
    [JsonProperty("edgeStates", Required = Required.Always)]
    public required List<EdgeState> EdgeStates { get; init; } = new();

    /// <summary>
    /// Position of the AGV.
    /// </summary>
    [JsonProperty("agvPosition")]
    public AgvPosition? AgvPosition { get; init; }

    /// <summary>
    /// Velocity of the AGV.
    /// </summary>
    [JsonProperty("velocity")]
    public Velocity? Velocity { get; init; }

    /// <summary>
    /// Array of load objects currently being handled by the AGV.
    /// </summary>
    [JsonProperty("loads")]
    public List<Load> Loads { get; init; } = new();

    /// <summary>
    /// Array of action state objects.
    /// </summary>
    [JsonProperty("actionStates")]
    public List<ActionState> ActionStates { get; init; } = new();

    /// <summary>
    /// Battery state of the AGV.
    /// </summary>
    [JsonProperty("batteryState", Required = Required.Always)]
    public required BatteryState BatteryState { get; init; }

    /// <summary>
    /// Array of error objects.
    /// </summary>
    [JsonProperty("errors", Required = Required.Always)]
    public required List<Error> Errors { get; init; } = new();

    /// <summary>
    /// Array of information objects.
    /// </summary>
    [JsonProperty("information")]
    public List<Information> Information { get; init; } = new();

    /// <summary>
    /// Safety state of the AGV.
    /// </summary>
    [JsonProperty("safetyState", Required = Required.Always)]
    public required SafetyState SafetyState { get; init; }
}

/// <summary>
/// Represents a map object that is currently stored on the vehicle.
/// </summary>
[JsonObject]
public record Map
{
    /// <summary>
    /// ID of the map describing a defined area of the vehicle's workspace.
    /// </summary>
    [JsonProperty("mapId", Required = Required.Always)]
    public required string MapId { get; init; }

    /// <summary>
    /// Version of the map.
    /// </summary>
    [JsonProperty("mapVersion", Required = Required.Always)]
    public required string MapVersion { get; init; }

    /// <summary>
    /// Additional information on the map.
    /// </summary>
    [JsonProperty("mapDescription")]
    public string? MapDescription { get; init; }

    /// <summary>
    /// Status of the map indicating if a map version is currently used on the vehicle.
    /// "ENABLED" indicates this map is currently active/used on the AGV.
    /// "DISABLED" indicates this map version is currently not enabled on the AGV and could be enabled or deleted by request.
    /// </summary>
    [JsonProperty("mapStatus", Required = Required.Always)]
    public required string MapStatus { get; init; }
}

/// <summary>
/// Represents a load object that describes the load if the AGV has information about it.
/// </summary>
[JsonObject]
public record Load
{
    /// <summary>
    /// Unique identification number of the load (e.g., barcode or RFID).
    /// Empty field if the AGV can identify the load but did not identify it yet.
    /// Optional, if the AGV cannot identify the load.
    /// </summary>
    [JsonProperty("loadId")]
    public string? LoadId { get; init; }

    /// <summary>
    /// Type of load.
    /// </summary>
    [JsonProperty("loadType")]
    public string? LoadType { get; init; }

    /// <summary>
    /// Indicates which load handling/carrying unit of the AGV is used, e.g., in case the AGV has multiple spots/positions to carry loads.
    /// Optional for vehicles with only one load position.
    /// </summary>
    [JsonProperty("loadPosition")]
    public string? LoadPosition { get; init; }

    /// <summary>
    /// Point of reference for the location of the bounding box.
    /// The point of reference is always the center of the bounding box bottom surface (at height = 0)
    /// and is described in coordinates of the AGV coordinate system.
    /// </summary>
    [JsonProperty("boundingBoxReference")]
    public BoundingBoxReference? BoundingBoxReference { get; init; }

    /// <summary>
    /// Dimensions of the load's bounding box in meters.
    /// </summary>
    [JsonProperty("loadDimensions")]
    public LoadDimensions? LoadDimensions { get; init; }

    /// <summary>
    /// Absolute weight of the load measured in kg.
    /// </summary>
    [JsonProperty("weight")]
    public double? Weight { get; init; }
}

/// <summary>
/// Represents the bounding box reference for a load.
/// </summary>
[JsonObject]
public record BoundingBoxReference
{
    [JsonProperty("x", Required = Required.Always)]
    public required double X { get; init; }

    [JsonProperty("y", Required = Required.Always)]
    public required double Y { get; init; }

    [JsonProperty("z", Required = Required.Always)]
    public required double Z { get; init; }

    [JsonProperty("theta")] public double? Theta { get; init; }
}

/// <summary>
/// Represents the dimensions of a load's bounding box in meters.
/// </summary>
[JsonObject]
public record LoadDimensions
{
    [JsonProperty("length", Required = Required.Always)]
    public required double Length { get; init; }

    [JsonProperty("width", Required = Required.Always)]
    public required double Width { get; init; }

    [JsonProperty("height")] public double? Height { get; init; }
}

/// <summary>
/// Represents the battery state of the AGV.
/// </summary>
[JsonObject]
public record BatteryState
{
    [JsonProperty("batteryCharge", Required = Required.Always)]
    public required double BatteryCharge { get; init; }

    [JsonProperty("batteryVoltage")] public double? BatteryVoltage { get; init; }

    [JsonProperty("batteryHealth")] public double? BatteryHealth { get; init; }

    [JsonProperty("charging", Required = Required.Always)]
    public required bool Charging { get; init; }

    [JsonProperty("reach")] public double? Reach { get; init; }
}

/// <summary>
/// Represents an action state of the AGV.
/// </summary>
[JsonObject]
public record ActionState
{
    /// <summary>
    /// Unique action identifier.
    /// </summary>
    [JsonProperty("actionId", Required = Required.Always)]
    public required string ActionId { get; init; }

    /// <summary>
    /// Optional: Only for informational or visualization purposes. Order knows the type.
    /// </summary>
    [JsonProperty("actionType")]
    public string? ActionType { get; init; }

    /// <summary>
    /// Additional information on the current action.
    /// </summary>
    [JsonProperty("actionDescription")]
    public string? ActionDescription { get; init; }

    /// <summary>
    /// The current status of the action.
    /// </summary>
    [JsonProperty("actionStatus", Required = Required.Always)]
    public required ActionStatus ActionStatus { get; init; }

    /// <summary>
    /// Describes the result of the action, e.g., the result of an RFID-read.
    /// </summary>
    [JsonProperty("resultDescription")]
    public string? ResultDescription { get; init; }
}

/// <summary>
/// Represents the possible statuses for an action.
/// </summary>
public enum ActionStatus
{
    /// <summary>
    /// The action is waiting for a trigger (passing the mode, entering the edge).
    /// </summary>
    WAITING,

    /// <summary>
    /// The action is currently initializing.
    /// </summary>
    INITIALIZING,

    /// <summary>
    /// The action is actively running.
    /// </summary>
    RUNNING,

    /// <summary>
    /// The action has successfully finished.
    /// </summary>
    FINISHED,

    /// <summary>
    /// The action has failed and could not be performed.
    /// </summary>
    FAILED
}

/// <summary>
/// Represents an error that has occurred in the AGV.
/// </summary>
[JsonObject]
public record Error
{
    /// <summary>
    /// The type or name of the error.
    /// </summary>
    [JsonProperty("errorType", Required = Required.Always)]
    public required string ErrorType { get; init; }

    /// <summary>
    /// A verbose description providing details and possible causes of the error.
    /// </summary>
    [JsonProperty("errorDescription")]
    public string? ErrorDescription { get; init; }

    /// <summary>
    /// A hint on how to approach or solve the reported error.
    /// </summary>
    [JsonProperty("errorHint")]
    public string? ErrorHint { get; init; }

    /// <summary>
    /// The severity level of the error.
    /// </summary>
    [JsonProperty("errorLevel", Required = Required.Always)]
    public required ErrorLevel ErrorLevel { get; init; }

    /// <summary>
    /// An array of references that provide more context or information related to the error.
    /// </summary>
    [JsonProperty("errorReferences")]
    public List<ErrorReference>? ErrorReferences { get; init; }
}

/// <summary>
/// Represents an error reference that provides more information on where the error occurred.
/// </summary>
[JsonObject]
public record ErrorReference
{
    /// <summary>
    /// Specifies the type of reference used (e.g., nodeId, edgeId, orderId, actionId, etc.).
    /// </summary>
    [JsonProperty("referenceKey", Required = Required.Always)]
    public required string ReferenceKey { get; init; }

    /// <summary>
    /// The value that belongs to the reference key. For example, the id of the node where the error occurred.
    /// </summary>
    [JsonProperty("referenceValue", Required = Required.Always)]
    public required string ReferenceValue { get; init; }
}

/// <summary>
/// Represents the possible error levels for the AGV.
/// </summary>
public enum ErrorLevel
{
    /// <summary>
    /// Indicates that the AGV has a warning but is still ready to start (e.g., maintenance cycle expiration warning).
    /// </summary>
    WARNING,

    /// <summary>
    /// Indicates that the AGV is not in a running condition, and user intervention is required (e.g., laser scanner is contaminated).
    /// </summary>
    FATAL
}

/// <summary>
/// Represents information related to the AGV's state or operation.
/// </summary>
[JsonObject]
public record Information
{
    /// <summary>
    /// The type or name of the information.
    /// </summary>
    [JsonProperty("infoType", Required = Required.Always)]
    public required string InfoType { get; init; }

    /// <summary>
    /// A descriptive message providing context for the information.
    /// </summary>
    [JsonProperty("infoDescription")]
    public string? InfoDescription { get; init; }

    /// <summary>
    /// The level of the information (DEBUG, INFO).
    /// </summary>
    [JsonProperty("infoLevel", Required = Required.Always)]
    public required InfoLevel InfoLevel { get; init; }

    /// <summary>
    /// A list of references that provide additional information related to the info message.
    /// </summary>
    [JsonProperty("infoReferences")]
    public List<InfoReference>? InfoReferences { get; init; }
}

/// <summary>
/// Represents an info reference that provides more information related to the information object.
/// </summary>
[JsonObject]
public record InfoReference
{
    /// <summary>
    /// References the type of reference (e.g., headerId, orderId, actionId, etc.).
    /// </summary>
    [JsonProperty("referenceKey", Required = Required.Always)]
    public required string ReferenceKey { get; init; }

    /// <summary>
    /// The value that belongs to the reference key.
    /// </summary>
    [JsonProperty("referenceValue", Required = Required.Always)]
    public required string ReferenceValue { get; init; }
}

/// <summary>
/// Represents the possible information levels for the AGV.
/// </summary>
public enum InfoLevel
{
    /// <summary>
    /// Information level used for debugging purposes.
    /// </summary>
    DEBUG,

    /// <summary>
    /// Information level used for visualization purposes.
    /// </summary>
    INFO
}

/// <summary>
/// Represents the safety state of the AGV.
/// </summary>
[JsonObject]
public record SafetyState
{
    /// <summary>
    /// The type of e-stop that is currently active.
    /// </summary>
    [JsonProperty("eStop", Required = Required.Always)]
    public required EStopType EStop { get; init; }

    /// <summary>
    /// True if a protective field violation occurred; false otherwise.
    /// </summary>
    [JsonProperty("fieldViolation", Required = Required.Always)]
    public required bool FieldViolation { get; init; }
}

/// <summary>
/// Represents the safety state of the AGV.
/// </summary>
public enum EStopType
{
    /// <summary>
    /// An auto-acknowledgeable e-stop is activated (e.g., bumper or protective field).
    /// </summary>
    AUTOACK,

    /// <summary>
    /// The e-stop must be acknowledged manually at the vehicle.
    /// </summary>
    MANUAL,

    /// <summary>
    /// The facility e-stop must be acknowledged remotely.
    /// </summary>
    REMOTE,

    /// <summary>
    /// No e-stop is activated.
    /// </summary>
    NONE
}

/// <summary>
/// Represents the state of a node that the AGV must traverse as part of an order.
/// </summary>
[JsonObject]
public record NodeState
{
    /// <summary>
    /// Unique identifier for the node.
    /// </summary>
    [JsonProperty("nodeId", Required = Required.Always)]
    public required string NodeId { get; init; }

    /// <summary>
    /// The sequence identifier used to discern multiple nodes with the same nodeId.
    /// </summary>
    [JsonProperty("sequenceId", Required = Required.Always)]
    public required int SequenceId { get; init; }

    /// <summary>
    /// Additional information related to the node.
    /// </summary>
    [JsonProperty("nodeDescription")]
    public string? NodeDescription { get; init; }

    /// <summary>
    /// True if the node is part of the base plan, false if it is part of the horizon plan.
    /// </summary>
    [JsonProperty("released", Required = Required.Always)]
    public required bool Released { get; init; }

    /// <summary>
    /// Position information of the node.
    /// </summary>
    [JsonProperty("nodePosition")]
    public StateNodePosition? NodePosition { get; init; }
}

/// <summary>
/// Represents the position of a node on the map.
/// </summary>
[JsonObject]
public record StateNodePosition
{
    /// <summary>
    /// X-coordinate of the node's position on the map.
    /// </summary>
    [JsonProperty("x", Required = Required.Always)]
    public required double X { get; init; }

    /// <summary>
    /// Y-coordinate of the node's position on the map.
    /// </summary>
    [JsonProperty("y", Required = Required.Always)]
    public required double Y { get; init; }

    /// <summary>
    /// Orientation (angle) of the node relative to the global coordinate system.
    /// </summary>
    [JsonProperty("theta")]
    public double? Theta { get; init; }

    /// <summary>
    /// The unique identifier of the map in which this node position is referenced.
    /// </summary>
    [JsonProperty("mapId", Required = Required.Always)]
    public required string MapId { get; init; }
}

/// <summary>
/// Represents the state of an edge that the AGV must traverse as part of an order.
/// </summary>
[JsonObject]
public record EdgeState
{
    /// <summary>
    /// Unique identifier for the edge.
    /// </summary>
    [JsonProperty("edgeId", Required = Required.Always)]
    public required string EdgeId { get; init; }

    /// <summary>
    /// The sequence identifier used to discern multiple edges with the same edgeId.
    /// </summary>
    [JsonProperty("sequenceId", Required = Required.Always)]
    public required int SequenceId { get; init; }

    /// <summary>
    /// Additional information related to the edge.
    /// </summary>
    [JsonProperty("edgeDescription")]
    public string? EdgeDescription { get; init; }

    /// <summary>
    /// True if the edge is part of the base plan, false if it is part of the horizon plan.
    /// </summary>
    [JsonProperty("released", Required = Required.Always)]
    public required bool Released { get; init; }

    /// <summary>
    /// The trajectory of the edge, represented as a NURBS (non-uniform rational B-spline) curve.
    /// </summary>
    [JsonProperty("trajectory")]
    public StateEdgeTrajectory? Trajectory { get; init; }
}

/// <summary>
/// Represents the trajectory of an edge, defined as a NURBS (non-uniform rational B-spline) curve.
/// </summary>
[JsonObject]
public record StateEdgeTrajectory
{
    /// <summary>
    /// The degree of the NURBS curve.
    /// </summary>
    [JsonProperty("degree", Required = Required.Always)]
    public required int Degree { get; init; }

    /// <summary>
    /// The knot vector, a sequence of parameter values that determines where and how control points affect the NURBS curve.
    /// </summary>
    [JsonProperty("knotVector", Required = Required.Always)]
    public required List<double> KnotVector { get; init; }

    /// <summary>
    /// The list of control points that define the NURBS curve, including start and end points.
    /// </summary>
    [JsonProperty("controlPoints", Required = Required.Always)]
    public required List<ControlPoint> ControlPoints { get; init; }
}