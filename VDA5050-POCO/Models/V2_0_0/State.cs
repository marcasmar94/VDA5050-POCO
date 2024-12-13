using VDA5050_POCO.Models.V2_0_0.Common;

namespace VDA5050_POCO.Models.V2_0_0;

using System;
using System.Collections.Generic;
using Newtonsoft.Json;

/// <summary>
/// Represents the all-encompassing state of the AGV.
/// </summary>
[JsonObject]
public record State
{
    /// <summary> Header ID of the message, incremented with each sent message. </summary>
    [JsonProperty(PropertyName = "headerId", Required = Required.Always)]
    public required int HeaderId { get; init; }

    /// <summary> Timestamp in ISO8601 format (YYYY-MM-DDTHH:mm:ss.ssZ). </summary>
    [JsonProperty(PropertyName = "timestamp", Required = Required.Always)]
    public required DateTime Timestamp { get; init; }

    /// <summary> Version of the protocol [Major].[Minor].[Patch]. </summary>
    [JsonProperty(PropertyName = "version", Required = Required.Always)]
    public required string Version { get; init; }

    /// <summary> Manufacturer of the AGV. </summary>
    [JsonProperty(PropertyName = "manufacturer", Required = Required.Always)]
    public required string Manufacturer { get; init; }

    /// <summary> Serial number of the AGV. </summary>
    [JsonProperty(PropertyName = "serialNumber", Required = Required.Always)]
    public required string SerialNumber { get; init; }

    /// <summary> Unique order ID of the current or previously completed order. </summary>
    [JsonProperty(PropertyName = "orderId", Required = Required.Always)]
    public required string OrderId { get; init; }

    /// <summary> Order Update ID to identify accepted order updates. </summary>
    [JsonProperty(PropertyName = "orderUpdateId", Required = Required.Always)]
    public required int OrderUpdateId { get; init; }

    /// <summary> Unique ID of the zone set currently used for path planning. Optional. </summary>
    [JsonProperty(PropertyName = "zoneSetId")]
    public string? ZoneSetId { get; init; }

    /// <summary> The ID of the last node reached or the current node if on a node. </summary>
    [JsonProperty(PropertyName = "lastNodeId", Required = Required.Always)]
    public required string LastNodeId { get; init; }

    /// <summary> Sequence ID of the last node reached or current node. </summary>
    [JsonProperty(PropertyName = "lastNodeSequenceId", Required = Required.Always)]
    public required int LastNodeSequenceId { get; init; }

    /// <summary> Indicates if the AGV is currently driving or rotating. </summary>
    [JsonProperty(PropertyName = "driving", Required = Required.Always)]
    public required bool Driving { get; init; }

    /// <summary> Indicates if the AGV is currently paused. </summary>
    [JsonProperty(PropertyName = "paused")]
    public bool? Paused { get; init; }

    /// <summary> Indicates if the AGV requires a new base from the master control. </summary>
    [JsonProperty(PropertyName = "newBaseRequest")]
    public bool? NewBaseRequest { get; init; }

    /// <summary> Distance traveled past the lastNodeId in meters. </summary>
    [JsonProperty(PropertyName = "distanceSinceLastNode")]
    public double? DistanceSinceLastNode { get; init; }

    /// <summary> Current operating mode of the AGV. </summary>
    [JsonProperty(PropertyName = "operatingMode", Required = Required.Always)]
    public required OperatingMode OperatingMode { get; init; }

    /// <summary> Array of states for the nodes yet to be traversed. Empty if idle. </summary>
    [JsonProperty(PropertyName = "nodeStates", Required = Required.Always)]
    public required List<NodeState> NodeStates { get; init; }

    /// <summary> Array of states for the edges yet to be traversed. Empty if idle. </summary>
    [JsonProperty(PropertyName = "edgeStates", Required = Required.Always)]
    public required List<EdgeState> EdgeStates { get; init; }

    /// <summary> AGV position information. </summary>
    [JsonProperty(PropertyName = "agvPosition")]
    public AgvPosition? AgvPosition { get; init; }

    /// <summary> AGV velocity information. </summary>
    [JsonProperty(PropertyName = "velocity")]
    public Velocity? Velocity { get; init; }

    /// <summary> Array of load objects describing the AGV's current load. </summary>
    [JsonProperty(PropertyName = "loads")]
    public List<Load>? Loads { get; init; }

    /// <summary> List of the current actions and their states. </summary>
    [JsonProperty(PropertyName = "actionStates", Required = Required.Always)]
    public required List<ActionState> ActionStates { get; init; }

    /// <summary> Information about the AGV's battery state. </summary>
    [JsonProperty(PropertyName = "batteryState", Required = Required.Always)]
    public required BatteryState BatteryState { get; init; }

    /// <summary> Array of errors currently present on the AGV. </summary>
    [JsonProperty(PropertyName = "errors", Required = Required.Always)]
    public required List<Error> Errors { get; init; }

    /// <summary> Array of information messages for debugging or visualization. </summary>
    [JsonProperty(PropertyName = "information")]
    public List<Information>? Information { get; init; }

    /// <summary> Information about the AGV's safety state. </summary>
    [JsonProperty(PropertyName = "safetyState", Required = Required.Always)]
    public required SafetyState SafetyState { get; init; }
}

/// <summary>
/// Represents the operating modes of the AGV.
/// </summary>
public enum OperatingMode
{
    AUTOMATIC,
    SEMIAUTOMATIC,
    MANUAL,
    SERVICE,
    TEACHIN
}

/// <summary>
/// Represents the state of a node in the state message.
/// </summary>
public record NodeState
{
    [JsonProperty(PropertyName = "nodeId", Required = Required.Always)]
    public required string NodeId { get; init; }

    [JsonProperty(PropertyName = "sequenceId", Required = Required.Always)]
    public required int SequenceId { get; init; }

    [JsonProperty(PropertyName = "released", Required = Required.Always)]
    public required bool Released { get; init; }
}

/// <summary>
/// Represents the state of an edge in the state message.
/// </summary>
public record EdgeState
{
    [JsonProperty(PropertyName = "edgeId", Required = Required.Always)]
    public required string EdgeId { get; init; }

    [JsonProperty(PropertyName = "sequenceId", Required = Required.Always)]
    public required int SequenceId { get; init; }

    [JsonProperty(PropertyName = "released", Required = Required.Always)]
    public required bool Released { get; init; }

    [JsonProperty(PropertyName = "trajectory")]
    public Trajectory? Trajectory { get; init; }
}

/// <summary>
/// Represents the trajectory of an edge.
/// </summary>
public record Trajectory
{
    [JsonProperty(PropertyName = "degree")]
    public int? Degree { get; init; }

    [JsonProperty(PropertyName = "knotVector", Required = Required.Always)]
    public required List<double> KnotVector { get; init; }

    [JsonProperty(PropertyName = "controlPoints", Required = Required.Always)]
    public required List<ControlPoint> ControlPoints { get; init; }
}

/// <summary>
/// Represents a control point in a trajectory.
/// </summary>
public record ControlPoint
{
    [JsonProperty(PropertyName = "x", Required = Required.Always)]
    public required double X { get; init; }

    [JsonProperty(PropertyName = "y", Required = Required.Always)]
    public required double Y { get; init; }

    [JsonProperty(PropertyName = "weight")]
    public double? Weight { get; init; }
}



/// <summary>
/// Represents the battery state of the AGV.
/// </summary>
public record BatteryState
{
    [JsonProperty(PropertyName = "batteryCharge", Required = Required.Always)]
    public required double BatteryCharge { get; init; }

    [JsonProperty(PropertyName = "charging", Required = Required.Always)]
    public required bool Charging { get; init; }

    [JsonProperty(PropertyName = "batteryVoltage")]
    public double? BatteryVoltage { get; init; }

    [JsonProperty(PropertyName = "batteryHealth")]
    public int? BatteryHealth { get; init; }

    [JsonProperty(PropertyName = "reach")]
    public double? Reach { get; init; }
}

/// <summary>
/// Represents a load carried by the AGV.
/// </summary>
public record Load
{
    [JsonProperty(PropertyName = "loadId")]
    public string? LoadId { get; init; }

    [JsonProperty(PropertyName = "loadType")]
    public string? LoadType { get; init; }

    [JsonProperty(PropertyName = "loadPosition")]
    public string? LoadPosition { get; init; }

    [JsonProperty(PropertyName = "boundingBoxReference")]
    public BoundingBoxReference? BoundingBoxReference { get; init; }

    [JsonProperty(PropertyName = "loadDimensions")]
    public LoadDimensions? LoadDimensions { get; init; }

    [JsonProperty(PropertyName = "weight")]
    public double? Weight { get; init; }
}

/// <summary>
/// Represents the bounding box reference of a load.
/// </summary>
public record BoundingBoxReference
{
    [JsonProperty(PropertyName = "x", Required = Required.Always)]
    public required double X { get; init; }

    [JsonProperty(PropertyName = "y", Required = Required.Always)]
    public required double Y { get; init; }

    [JsonProperty(PropertyName = "z", Required = Required.Always)]
    public required double Z { get; init; }

    [JsonProperty(PropertyName = "theta")]
    public double? Theta { get; init; }
}

/// <summary>
/// Represents the dimensions of a load.
/// </summary>
public record LoadDimensions
{
    [JsonProperty(PropertyName = "length", Required = Required.Always)]
    public required double Length { get; init; }

    [JsonProperty(PropertyName = "width", Required = Required.Always)]
    public required double Width { get; init; }

    [JsonProperty(PropertyName = "height")]
    public double? Height { get; init; }
}

/// <summary>
/// Represents an action state.
/// </summary>
public record ActionState
{
    [JsonProperty(PropertyName = "actionId", Required = Required.Always)]
    public required string ActionId { get; init; }

    [JsonProperty(PropertyName = "actionStatus", Required = Required.Always)]
    public required ActionStatus ActionStatus { get; init; }

    [JsonProperty(PropertyName = "actionType")]
    public string? ActionType { get; init; }

    [JsonProperty(PropertyName = "actionDescription")]
    public string? ActionDescription { get; init; }

    [JsonProperty(PropertyName = "resultDescription")]
    public string? ResultDescription { get; init; }
}

/// <summary>
/// Represents the possible statuses of an action.
/// </summary>
public enum ActionStatus
{
    WAITING,
    INITIALIZING,
    RUNNING,
    PAUSED,
    FINISHED,
    FAILED
}

/// <summary>
/// Represents an error on the AGV.
/// </summary>
public record Error
{
    [JsonProperty(PropertyName = "errorType", Required = Required.Always)]
    public required string ErrorType { get; init; }

    [JsonProperty(PropertyName = "errorLevel", Required = Required.Always)]
    public required ErrorLevel ErrorLevel { get; init; }

    [JsonProperty(PropertyName = "errorReferences")]
    public List<ErrorReference>? ErrorReferences { get; init; }

    [JsonProperty(PropertyName = "errorDescription")]
    public string? ErrorDescription { get; init; }
}

/// <summary>
/// Represents the severity of an error.
/// </summary>
public enum ErrorLevel
{
    WARNING,
    FATAL
}

/// <summary>
/// Represents a reference for an error.
/// </summary>
public record ErrorReference
{
    [JsonProperty(PropertyName = "referenceKey", Required = Required.Always)]
    public required string ReferenceKey { get; init; }

    [JsonProperty(PropertyName = "referenceValue", Required = Required.Always)]
    public required string ReferenceValue { get; init; }
}

/// <summary>
/// Represents a debugging or informational message.
/// </summary>
public record Information
{
    [JsonProperty(PropertyName = "infoType", Required = Required.Always)]
    public required string InfoType { get; init; }

    [JsonProperty(PropertyName = "infoLevel", Required = Required.Always)]
    public required InfoLevel InfoLevel { get; init; }

    [JsonProperty(PropertyName = "infoReferences")]
    public List<InfoReference>? InfoReferences { get; init; }

    [JsonProperty(PropertyName = "infoDescription")]
    public string? InfoDescription { get; init; }
}

/// <summary>
/// Represents the level of an informational message.
/// </summary>
public enum InfoLevel
{
    INFO,
    DEBUG
}

/// <summary>
/// Represents a reference for informational messages.
/// </summary>
public record InfoReference
{
    [JsonProperty(PropertyName = "referenceKey", Required = Required.Always)]
    public required string ReferenceKey { get; init; }

    [JsonProperty(PropertyName = "referenceValue", Required = Required.Always)]
    public required string ReferenceValue { get; init; }
}

/// <summary>
/// Represents the safety state of the AGV.
/// </summary>
public record SafetyState
{
    [JsonProperty(PropertyName = "eStop", Required = Required.Always)]
    public required EStop EStop { get; init; }

    [JsonProperty(PropertyName = "fieldViolation", Required = Required.Always)]
    public required bool FieldViolation { get; init; }
}

/// <summary>
/// Represents the types of emergency stops (eStop).
/// </summary>
public enum EStop
{
    AUTOACK,
    MANUAL,
    REMOTE,
    NONE
}
