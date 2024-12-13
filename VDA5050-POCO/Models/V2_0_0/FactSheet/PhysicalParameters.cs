using Newtonsoft.Json;

namespace VDA5050_POCO.Models.V2_0_0.FactSheet;


/// <summary>
/// Specifies the physical characteristics of the AGV.
/// </summary>
public record PhysicalParameters
{
    [JsonProperty(PropertyName = "speedMin", Required = Required.Always)]
    public required double SpeedMin { get; init; }

    [JsonProperty(PropertyName = "speedMax", Required = Required.Always)]
    public required double SpeedMax { get; init; }

    [JsonProperty(PropertyName = "accelerationMax", Required = Required.Always)]
    public required double AccelerationMax { get; init; }

    [JsonProperty(PropertyName = "decelerationMax", Required = Required.Always)]
    public required double DecelerationMax { get; init; }

    [JsonProperty(PropertyName = "heightMin", Required = Required.Always)]
    public required double HeightMin { get; init; }

    [JsonProperty(PropertyName = "heightMax", Required = Required.Always)]
    public required double HeightMax { get; init; }

    [JsonProperty(PropertyName = "width", Required = Required.Always)]
    public required double Width { get; init; }

    [JsonProperty(PropertyName = "length", Required = Required.Always)]
    public required double Length { get; init; }
}

