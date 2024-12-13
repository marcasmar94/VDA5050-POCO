using Newtonsoft.Json;

namespace VDA5050_POCO.Models.V2_0_0.FactSheet;

/// <summary>
/// Specifies the type and general characteristics of the AGV.
/// </summary>
public record TypeSpecification
{
    [JsonProperty(PropertyName = "seriesName", Required = Required.Always)]
    public required string SeriesName { get; init; }

    [JsonProperty(PropertyName = "seriesDescription", NullValueHandling = NullValueHandling.Ignore)]
    public string? SeriesDescription { get; init; }

    [JsonProperty(PropertyName = "agvKinematic", Required = Required.Always)]
    public required AGVKinematic AGVKinematic { get; init; }

    [JsonProperty(PropertyName = "agvClass", Required = Required.Always)]
    public required AGVClass AGVClass { get; init; }

    [JsonProperty(PropertyName = "maxLoadMass", Required = Required.Always)]
    public required double MaxLoadMass { get; init; }

    [JsonProperty(PropertyName = "localizationTypes", Required = Required.Always)]
    public required List<string> LocalizationTypes { get; init; }

    [JsonProperty(PropertyName = "navigationTypes", Required = Required.Always)]
    public required List<string> NavigationTypes { get; init; }
}

/// <summary>
/// Enumeration of AGV kinematics.
/// </summary>
public enum AGVKinematic
{
    DIFF,
    OMNI,
    THREEWHEEL
}

/// <summary>
/// Enumeration of AGV classes.
/// </summary>
public enum AGVClass
{
    FORKLIFT,
    CONVEYOR,
    TUGGER,
    CARRIER
}
