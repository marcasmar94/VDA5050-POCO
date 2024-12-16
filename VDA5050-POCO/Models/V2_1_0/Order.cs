using Newtonsoft.Json;
using Action = VDA5050_POCO.Models.V2_1_0.Common.Action;
namespace VDA5050_POCO.Models.V2_1_0;

/// <summary>
/// Represents the order message sent by the master control to the AGV.
/// </summary>
[JsonObject]
public record Order
{
    /// <summary>
    /// Header ID of the message. The headerId is defined per topic and incremented by 1 with each sent (but not necessarily received) message.
    /// </summary>
    [JsonProperty(PropertyName = "headerId", Required = Required.Always)]
    public required int HeaderId { get; init; }

    /// <summary>
    /// Timestamp in ISO8601 format (YYYY-MM-DDTHH:mm:ss.ssZ).
    /// </summary>
    [JsonProperty(PropertyName = "timestamp", Required = Required.Always)]
    public required DateTime Timestamp { get; init; }

    /// <summary>
    /// Version of the protocol [Major].[Minor].[Patch].
    /// </summary>
    [JsonProperty(PropertyName = "version", Required = Required.Always)]
    public required string Version { get; init; }

    /// <summary>
    /// Manufacturer of the AGV.
    /// </summary>
    [JsonProperty(PropertyName = "manufacturer", Required = Required.Always)]
    public required string Manufacturer { get; init; }

    /// <summary>
    /// Serial number of the AGV.
    /// </summary>
    [JsonProperty(PropertyName = "serialNumber", Required = Required.Always)]
    public required string SerialNumber { get; init; }

    /// <summary>
    /// Order identification. This is to be used to identify multiple order messages that belong to the same order.
    /// </summary>
    [JsonProperty(PropertyName = "orderId", Required = Required.Always)]
    public required string OrderId { get; init; }

    /// <summary>
    /// Order update identification. Is unique per orderId. If an order update is rejected, this field is to be passed in the rejection message.
    /// </summary>
    [JsonProperty(PropertyName = "orderUpdateId", Required = Required.Always)]
    public required int OrderUpdateId { get; init; }

    /// <summary>
    /// Unique identifier of the zone set that the AGV has to use for navigation or that was used by MC for planning.
    /// </summary>
    [JsonProperty(PropertyName = "zoneSetId")]
    public string? ZoneSetId { get; init; }

    /// <summary>
    /// Array of nodes objects to be traversed for fulfilling the order.
    /// </summary>
    [JsonProperty(PropertyName = "nodes", Required = Required.Always)]
    public required List<Node> Nodes { get; init; }

    /// <summary>
    /// Base and Horizon Edges of the Order Graph.
    /// </summary>
    [JsonProperty(PropertyName = "edges", Required = Required.Always)]
    public required List<Edge> Edges { get; init; }
}

/// <summary>
/// Represents a node within an order.
/// </summary>
[JsonObject]
public record Node
{
    /// <summary>
    /// Unique node identification.
    /// </summary>
    [JsonProperty(PropertyName = "nodeId", Required = Required.Always)]
    public required string NodeId { get; init; }

    /// <summary>
    /// Number to track the sequence of nodes and edges in an order and to simplify order updates.
    /// </summary>
    [JsonProperty(PropertyName = "sequenceId", Required = Required.Always)]
    public required int SequenceId { get; init; }

    /// <summary>
    /// Additional information on the node.
    /// </summary>
    [JsonProperty(PropertyName = "nodeDescription")]
    public string? NodeDescription { get; init; }

    /// <summary>
    /// Indicates if the node is part of the base (true) or part of the horizon (false).
    /// </summary>
    [JsonProperty(PropertyName = "released", Required = Required.Always)]
    public required bool Released { get; init; }

    /// <summary>
    /// Defines the position on a map in a global project-specific world coordinate system.
    /// </summary>
    [JsonProperty(PropertyName = "nodePosition")]
    public OrderNodePosition? NodePosition { get; init; }

    /// <summary>
    /// Array of actions to be executed on a node. Empty array if no actions are required.
    /// </summary>
    [JsonProperty(PropertyName = "actions", Required = Required.Always)]
    public required List<Action> Actions { get; init; }
}

/// <summary>
/// Represents an edge within an order.
/// </summary>
[JsonObject]
public record Edge
{
    /// <summary>
    /// Unique edge identification.
    /// </summary>
    [JsonProperty("edgeId", Required = Required.Always)]
    public required string EdgeId { get; init; }

    /// <summary>
    /// Number to track the sequence of nodes and edges in an order and to simplify order updates.
    /// </summary>
    [JsonProperty("sequenceId", Required = Required.Always)]
    public required int SequenceId { get; init; }

    /// <summary>
    /// Additional information on the edge.
    /// </summary>
    [JsonProperty("edgeDescription")]
    public string? EdgeDescription { get; init; }

    /// <summary>
    /// True indicates that the edge is part of the base. False indicates that the edge is part of the horizon.
    /// </summary>
    [JsonProperty("released", Required = Required.Always)]
    public required bool Released { get; init; }

    /// <summary>
    /// The nodeId of the start node.
    /// </summary>
    [JsonProperty("startNodeId", Required = Required.Always)]
    public required string StartNodeId { get; init; }

    /// <summary>
    /// The nodeId of the end node.
    /// </summary>
    [JsonProperty("endNodeId", Required = Required.Always)]
    public required string EndNodeId { get; init; }

    /// <summary>
    /// Permitted maximum speed on the edge in m/s.
    /// </summary>
    [JsonProperty("maxSpeed")]
    public double? MaxSpeed { get; init; }

    /// <summary>
    /// Permitted maximum height of the vehicle, including the load, on edge in meters.
    /// </summary>
    [JsonProperty("maxHeight")]
    public double? MaxHeight { get; init; }

    /// <summary>
    /// Permitted minimal height of the load handling device on the edge in meters.
    /// </summary>
    [JsonProperty("minHeight")]
    public double? MinHeight { get; init; }

    /// <summary>
    /// Orientation of the AGV on the edge.
    /// </summary>
    [JsonProperty("orientation")]
    public double? Orientation { get; init; }

    /// <summary>
    /// Enum {GLOBAL, TANGENTIAL}.
    /// </summary>
    [JsonProperty("orientationType")]
    public string? OrientationType { get; init; }

    /// <summary>
    /// Sets direction at junctions for line-guided or wire-guided vehicles.
    /// </summary>
    [JsonProperty("direction")]
    public string? Direction { get; init; }

    /// <summary>
    /// True: rotation is allowed on the edge. False: rotation is not allowed on the edge.
    /// </summary>
    [JsonProperty("rotationAllowed")]
    public bool? RotationAllowed { get; init; }

    /// <summary>
    /// Maximum rotation speed in rad/s.
    /// </summary>
    [JsonProperty("maxRotationSpeed")]
    public double? MaxRotationSpeed { get; init; }

    /// <summary>
    /// Distance of the path from startNode to endNode in meters.
    /// </summary>
    [JsonProperty("length")]
    public double? Length { get; init; }

    /// <summary>
    /// Trajectory JSON-object for this edge as a NURBS.
    /// Defines the curve, on which the AGV should move between startNode and endNode.
    /// Optional: Can be omitted, if AGV cannot process trajectories or if AGV plans its own trajectory.
    /// </summary>
    [JsonProperty("trajectory")]
    public StateEdgeTrajectory? Trajectory { get; init; }

    /// <summary>
    /// Definition of boundaries in which a vehicle can deviate from its trajectory, e. g. to avoid obstacles.
    /// </summary>
    [JsonProperty("corridor")]
    public Corridor? Corridor { get; init; }

    /// <summary>
    /// Array of action objects with detailed information.
    /// </summary>
    [JsonProperty("actions", Required = Required.Always)]
    public required List<Action> Actions { get; init; }
}

[JsonObject]
public record OrderEdgeTrajectory
{
    /// <summary>
    /// Defines the number of control points that influence any given point on the curve.
    /// Increasing the degree increases continuity. If not defined, the default value is 1.
    /// </summary>
    [JsonProperty("degree", Required = Required.Always)]
    public required int Degree { get; init; }

    /// <summary>
    /// Sequence of parameter values that determines where and how the control points affect the NURBS curve.
    /// knotVector has size of number of control points + degree + 1.
    /// </summary>
    [JsonProperty("knotVector", Required = Required.Always)]
    public required List<double> KnotVector { get; init; }

    /// <summary>
    /// List of JSON controlPoint objects defining the control points of the NURBS, which includes the beginning and end point.
    /// </summary>
    [JsonProperty("controlPoints", Required = Required.Always)]
    public required List<ControlPoint> ControlPoints { get; init; }
}

[JsonObject]
public record ControlPoint
{
    /// <summary>
    /// X coordinate described in the world coordinate system.
    /// </summary>
    [JsonProperty("x", Required = Required.Always)]
    public required double X { get; init; }

    /// <summary>
    /// Y coordinate described in the world coordinate system.
    /// </summary>
    [JsonProperty("y", Required = Required.Always)]
    public required double Y { get; init; }

    /// <summary>
    /// The weight, with which this control point pulls on the curve. When not defined, the default will be 1.0.
    /// </summary>
    [JsonProperty("weight")]
    public double? Weight { get; init; }
}

/// <summary>
/// Definition of boundaries in which a vehicle can deviate from its trajectory, e. g. to avoid obstacles.
/// </summary>
[JsonObject]
public record Corridor
{
    /// <summary>
    /// Defines the width of the corridor in meters to the left related to the trajectory of the vehicle.
    /// </summary>
    [JsonProperty("leftWidth", Required = Required.Always)]
    public required double LeftWidth { get; init; }

    /// <summary>
    /// Defines the width of the corridor in meters to the right related to the trajectory of the vehicle.
    /// </summary>
    [JsonProperty("rightWidth", Required = Required.Always)]
    public required double RightWidth { get; init; }

    /// <summary>
    /// Defines whether the boundaries are valid for the kinematic center or the contour of the vehicle.
    /// </summary>
    [JsonProperty("corridorRefPoint")]
    public string? CorridorRefPoint { get; init; }
}

/// <summary>
/// Represents the position of a node in the map coordinate system.
/// </summary>
public record OrderNodePosition
{
    /// <summary>
    /// X-coordinate of the position on the map.
    /// </summary>
    [JsonProperty(PropertyName = "x", Required = Required.Always)]
    public required double X { get; init; }

    /// <summary>
    /// Y-coordinate of the position on the map.
    /// </summary>
    [JsonProperty(PropertyName = "y", Required = Required.Always)]
    public required double Y { get; init; }

    /// <summary>
    /// Unique identifier of the map.
    /// </summary>
    [JsonProperty(PropertyName = "mapId", Required = Required.Always)]
    public required string MapId { get; init; }

    /// <summary>
    /// Absolute orientation of the AGV at this node.
    /// Optional: If not defined, AGV can plan the path by itself.
    /// </summary>
    [JsonProperty(PropertyName = "theta")]
    public double? Theta { get; init; }

    /// <summary>
    /// Allowed deviation in meters for the X and Y position.
    /// Optional: If not defined, no deviation is allowed.
    /// </summary>
    [JsonProperty(PropertyName = "allowedDeviationXY")]
    public double? AllowedDeviationXY { get; init; }

    /// <summary>
    /// Allowed deviation in radians for the theta orientation.
    /// </summary>
    [JsonProperty(PropertyName = "allowedDeviationTheta")]
    public double? AllowedDeviationTheta { get; init; }

    /// <summary>
    /// Additional information about the map.
    /// </summary>
    [JsonProperty(PropertyName = "mapDescription")]
    public string? MapDescription { get; init; }
}