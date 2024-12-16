using Newtonsoft.Json;
namespace VDA5050_POCO.Models.V2_1_0.FactSheet;

/// <summary>
/// Represents the AGV Factsheet providing basic information about a specific AGV type series.
/// </summary>
[JsonObject]
public record Factsheet
{
    /// <summary>
    /// Header ID of the message.
    /// </summary>
    [JsonProperty("headerId")]
    public int? HeaderId { get; init; }

    /// <summary>
    /// Timestamp in ISO8601 format (YYYY-MM-DDTHH:mm:ss.ffZ).
    /// </summary>
    [JsonProperty("timestamp")]
    public string? Timestamp { get; init; }

    /// <summary>
    /// Version of the VDA-5050 protocol.
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

    [JsonProperty("typeSpecification", Required = Required.Always)]
    public required TypeSpecification TypeSpecification { get; init; }

    [JsonProperty("physicalParameters", Required = Required.Always)]
    public required PhysicalParameters PhysicalParameters { get; init; }

    [JsonProperty("protocolLimits", Required = Required.Always)]
    public required ProtocolLimits ProtocolLimits { get; init; }

    [JsonProperty("protocolFeatures", Required = Required.Always)]
    public required ProtocolFeatures ProtocolFeatures { get; init; }

    [JsonProperty("agvGeometry", Required = Required.Always)]
    public required AgvGeometry AgvGeometry { get; init; }

    [JsonProperty("loadSpecification", Required = Required.Always)]
    public required LoadSpecification LoadSpecification { get; init; }

    [JsonProperty("vehicleConfig")]
    public VehicleConfig? VehicleConfig { get; init; }
}