using Newtonsoft.Json;

namespace VDA5050_POCO.Models.V2_0_0.FactSheet;

/// <summary>
/// Represents the AGV Factsheet, which provides information about a specific AGV type series. 
/// This information allows comparison of different AGV types and supports planning, dimensioning, and simulation of an AGV system.
/// </summary>
public record AGVFactsheet
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
    /// Version of the VDA5050 protocol (e.g., 2.0.0).
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
    /// General specifications that define the type and capabilities of the AGV.
    /// </summary>
    [JsonProperty(PropertyName = "typeSpecification", Required = Required.Always)]
    public required TypeSpecification TypeSpecification { get; init; }

    /// <summary>
    /// Describes the physical characteristics of the AGV.
    /// </summary>
    [JsonProperty(PropertyName = "physicalParameters", Required = Required.Always)]
    public required PhysicalParameters PhysicalParameters { get; init; }

    /// <summary>
    /// Describes the protocol limits of the AGV.
    /// </summary>
    [JsonProperty(PropertyName = "protocolLimits", Required = Required.Always)]
    public required ProtocolLimits ProtocolLimits { get; init; }

    /// <summary>
    /// Describes the features supported by the VDA5050 protocol.
    /// </summary>
    [JsonProperty(PropertyName = "protocolFeatures", Required = Required.Always)]
    public required ProtocolFeatures ProtocolFeatures { get; init; }

    /// <summary>
    /// Detailed definition of AGV geometry.
    /// </summary>
    [JsonProperty(PropertyName = "agvGeometry", Required = Required.Always)]
    public required AGVGeometry AGVGeometry { get; init; }

    /// <summary>
    /// Abstract specification of load capabilities.
    /// </summary>
    [JsonProperty(PropertyName = "loadSpecification", Required = Required.Always)]
    public required LoadSpecification LoadSpecification { get; init; }

    /// <summary>
    /// Detailed specification of localization parameters.
    /// </summary>
    [JsonProperty(PropertyName = "localizationParameters", NullValueHandling = NullValueHandling.Ignore)]
    public LocalizationParameters? LocalizationParameters { get; init; }
}



