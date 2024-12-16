using Newtonsoft.Json;

namespace VDA5050_POCO.Models.V2_1_0.FactSheet;

/// <summary>
/// Represents the configuration of the vehicle, including versions and network configuration.
/// </summary>
[JsonObject]
public record VehicleConfig
{
    /// <summary>
    /// Array containing various hardware and software versions running on the vehicle.
    /// </summary>
    [JsonProperty("versions")]
    public List<VersionInfo>? Versions { get; init; }

    /// <summary>
    /// Network configuration for the vehicle.
    /// </summary>
    [JsonProperty("network")]
    public NetworkConfiguration? Network { get; init; }
}

/// <summary>
/// Represents version information for hardware and software running on the vehicle.
/// </summary>
[JsonObject]
public record VersionInfo
{
    /// <summary>
    /// The key of the version, e.g., software version, camera version, PLC software checksum, etc.
    /// </summary>
    [JsonProperty("key", Required = Required.Always)]
    public required string Key { get; init; }

    /// <summary>
    /// The value of the version, e.g., version number, identifier, or checksum.
    /// </summary>
    [JsonProperty("value", Required = Required.Always)]
    public required string Value { get; init; }
}

/// <summary>
/// Represents the network configuration of the vehicle.
/// </summary>
[JsonObject]
public record NetworkConfiguration
{
    /// <summary>
    /// List of DNS servers used by the vehicle.
    /// </summary>
    [JsonProperty("dnsServers")]
    public List<string>? DnsServers { get; init; }

    /// <summary>
    /// A priori assigned IP address of the vehicle used to communicate with the MQTT broker.
    /// Note that this IP address should not be modified/changed during operations.
    /// </summary>
    [JsonProperty("localIpAddress")]
    public string? LocalIpAddress { get; init; }

    /// <summary>
    /// List of NTP servers used by the vehicle.
    /// </summary>
    [JsonProperty("ntpServers")]
    public List<string>? NtpServers { get; init; }

    /// <summary>
    /// Network subnet mask.
    /// </summary>
    [JsonProperty("netmask")]
    public string? Netmask { get; init; }

    /// <summary>
    /// Default gateway used by the vehicle.
    /// </summary>
    [JsonProperty("defaultGateway")]
    public string? DefaultGateway { get; init; }
}