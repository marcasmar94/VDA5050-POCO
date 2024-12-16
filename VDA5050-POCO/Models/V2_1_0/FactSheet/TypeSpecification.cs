using Newtonsoft.Json;
using VDA5050_POCO.Models.V2_1_0.FactSheet.Enums;

namespace VDA5050_POCO.Models.V2_1_0.FactSheet;

/// <summary>
/// Represents the type specification of the AGV.
/// </summary>
[JsonObject]
public record TypeSpecification
{
    /// <summary>
    /// Free text generalized series name as specified by manufacturer.
    /// </summary>
    [JsonProperty("seriesName", Required = Required.Always)]
    public required string SeriesName { get; init; }

    /// <summary>
    /// Free text human-readable description of the AGV type series.
    /// </summary>
    [JsonProperty("seriesDescription")]
    public string? SeriesDescription { get; init; }

    /// <summary>
    /// Simplified description of AGV kinematics type.
    /// </summary>
    [JsonProperty("agvKinematic", Required = Required.Always)]
    public required AgvKinematic AgvKinematic { get; init; }

    /// <summary>
    /// Simplified description of AGV class.
    /// </summary>
    [JsonProperty("agvClass", Required = Required.Always)]
    public required AgvClass AgvClass { get; init; }

    /// <summary>
    /// Maximum loadable mass in kilograms.
    /// </summary>
    [JsonProperty("maxLoadMass", Required = Required.Always)]
    public required double MaxLoadMass { get; init; }

    /// <summary>
    /// Simplified description of localization types.
    /// </summary>
    [JsonProperty("localizationTypes", Required = Required.Always)]
    public required List<LocalizationType> LocalizationTypes { get; init; }

    /// <summary>
    /// List of path planning types supported by the AGV.
    /// </summary>
    [JsonProperty("navigationTypes", Required = Required.Always)]
    public required List<NavigationType> NavigationTypes { get; init; }
}
