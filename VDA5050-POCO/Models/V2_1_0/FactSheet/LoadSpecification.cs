using Newtonsoft.Json;

namespace VDA5050_POCO.Models.V2_1_0.FactSheet;

/// <summary>
/// Abstract specification of load capabilities.
/// </summary>
[JsonObject]
public record LoadSpecification
{
    /// <summary>
    /// List of load positions / load handling devices.
    /// This list contains the valid values for the parameter "state.loads[].loadPosition"
    /// and for the action parameter "lhd" of the actions pick and drop.
    /// If this list doesn’t exist or is empty, the AGV has no load handling device.
    /// </summary>
    [JsonProperty("loadPositions")]
    public List<string>? LoadPositions { get; init; }

    /// <summary>
    /// List of load-sets that can be handled by the AGV.
    /// </summary>
    [JsonProperty("loadSets")]
    public List<LoadSet>? LoadSets { get; init; }
}

/// <summary>
/// Represents a load set that can be handled by the AGV.
/// </summary>
[JsonObject]
public record LoadSet
{
    /// <summary>
    /// Unique name of the load set, e.g., DEFAULT, SET1, etc.
    /// </summary>
    [JsonProperty("setName", Required = Required.Always)]
    public required string SetName { get; init; }

    /// <summary>
    /// Type of load, e.g., EPAL, XLT1200, etc.
    /// </summary>
    [JsonProperty("loadType", Required = Required.Always)]
    public required string LoadType { get; init; }

    /// <summary>
    /// List of load positions between load handling devices where this load-set is valid.
    /// If this parameter does not exist or is empty, this load-set is valid for all load handling devices on this AGV.
    /// </summary>
    [JsonProperty("loadPositions")]
    public List<string>? LoadPositions { get; init; }

    /// <summary>
    /// Bounding box reference as defined in parameter "loads[]" in the state message.
    /// </summary>
    [JsonProperty("boundingBoxReference")]
    public BoundingBoxReference? BoundingBoxReference { get; init; }

    /// <summary>
    /// Dimensions of the load's bounding box.
    /// </summary>
    [JsonProperty("loadDimensions")]
    public LoadDimensions? LoadDimensions { get; init; }

    /// <summary>
    /// Maximum weight of the load type (in kg).
    /// </summary>
    [JsonProperty("maxWeight")]
    public double? MaxWeight { get; init; }

    /// <summary>
    /// Minimum allowed height for handling of this load-type and weight.
    /// References the boundingBoxReference.
    /// </summary>
    [JsonProperty("minLoadhandlingHeight")]
    public double? MinLoadhandlingHeight { get; init; }

    /// <summary>
    /// Maximum allowed height for handling of this load-type and weight.
    /// References the boundingBoxReference.
    /// </summary>
    [JsonProperty("maxLoadhandlingHeight")]
    public double? MaxLoadhandlingHeight { get; init; }

    /// <summary>
    /// Minimum allowed depth for this load-type and weight.
    /// References the boundingBoxReference.
    /// </summary>
    [JsonProperty("minLoadhandlingDepth")]
    public double? MinLoadhandlingDepth { get; init; }

    /// <summary>
    /// Maximum allowed depth for this load-type and weight.
    /// References the boundingBoxReference.
    /// </summary>
    [JsonProperty("maxLoadhandlingDepth")]
    public double? MaxLoadhandlingDepth { get; init; }

    /// <summary>
    /// Minimum allowed tilt for this load-type and weight (in radians).
    /// </summary>
    [JsonProperty("minLoadhandlingTilt")]
    public double? MinLoadhandlingTilt { get; init; }

    /// <summary>
    /// Maximum allowed tilt for this load-type and weight (in radians).
    /// </summary>
    [JsonProperty("maxLoadhandlingTilt")]
    public double? MaxLoadhandlingTilt { get; init; }

    /// <summary>
    /// Maximum allowed speed for this load-type and weight (in m/s²).
    /// </summary>
    [JsonProperty("agvSpeedLimit")]
    public double? AgvSpeedLimit { get; init; }

    /// <summary>
    /// Maximum allowed acceleration for this load-type and weight (in m/s²).
    /// </summary>
    [JsonProperty("agvAccelerationLimit")]
    public double? AgvAccelerationLimit { get; init; }

    /// <summary>
    /// Maximum allowed deceleration for this load-type and weight (in m/s²).
    /// </summary>
    [JsonProperty("agvDecelerationLimit")]
    public double? AgvDecelerationLimit { get; init; }

    /// <summary>
    /// Approximate time for picking up the load (in seconds).
    /// </summary>
    [JsonProperty("pickTime")]
    public double? PickTime { get; init; }

    /// <summary>
    /// Approximate time for dropping the load (in seconds).
    /// </summary>
    [JsonProperty("dropTime")]
    public double? DropTime { get; init; }

    /// <summary>
    /// Free text description of the load handling set.
    /// </summary>
    [JsonProperty("description")]
    public string? Description { get; init; }
}

/// <summary>
/// Represents the bounding box reference as defined in the parameter "loads[]" in the state message.
/// </summary>
[JsonObject]
public record BoundingBoxReference
{
    /// <summary>
    /// X-coordinate of the point of reference.
    /// </summary>
    [JsonProperty("x", Required = Required.Always)]
    public required double X { get; init; }

    /// <summary>
    /// Y-coordinate of the point of reference.
    /// </summary>
    [JsonProperty("y", Required = Required.Always)]
    public required double Y { get; init; }

    /// <summary>
    /// Z-coordinate of the point of reference.
    /// </summary>
    [JsonProperty("z", Required = Required.Always)]
    public required double Z { get; init; }

    /// <summary>
    /// Orientation of the load's bounding box.
    /// Important for tugger trains, etc.
    /// </summary>
    [JsonProperty("theta")]
    public double? Theta { get; init; }
}

/// <summary>
/// Represents the dimensions of a load's bounding box.
/// </summary>
[JsonObject]
public record LoadDimensions
{
    /// <summary>
    /// Absolute length of the load's bounding box.
    /// </summary>
    [JsonProperty("length", Required = Required.Always)]
    public required double Length { get; init; }

    /// <summary>
    /// Absolute width of the load's bounding box.
    /// </summary>
    [JsonProperty("width", Required = Required.Always)]
    public required double Width { get; init; }

    /// <summary>
    /// Absolute height of the load's bounding box.
    /// Optional: Set value only if known.
    /// </summary>
    [JsonProperty("height")]
    public double? Height { get; init; }
}