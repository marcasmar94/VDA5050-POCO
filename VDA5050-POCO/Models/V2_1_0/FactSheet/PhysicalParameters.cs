using Newtonsoft.Json;
namespace VDA5050_POCO.Models.V2_1_0.FactSheet;

/// <summary>
/// Represents the physical parameters of the AGV.
/// </summary>
[JsonObject]
public record PhysicalParameters
{
    [JsonProperty("speedMin", Required = Required.Always)]
    public required double SpeedMin { get; init; }

    [JsonProperty("speedMax", Required = Required.Always)]
    public required double SpeedMax { get; init; }

    [JsonProperty("accelerationMax", Required = Required.Always)]
    public required double AccelerationMax { get; init; }

    [JsonProperty("decelerationMax", Required = Required.Always)]
    public required double DecelerationMax { get; init; }

    [JsonProperty("heightMin")]
    public double? HeightMin { get; init; }

    [JsonProperty("heightMax", Required = Required.Always)]
    public required double HeightMax { get; init; }

    [JsonProperty("width", Required = Required.Always)]
    public required double Width { get; init; }

    [JsonProperty("length", Required = Required.Always)]
    public required double Length { get; init; }
}
