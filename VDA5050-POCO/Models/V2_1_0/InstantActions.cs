using Newtonsoft.Json;
using Action = VDA5050_POCO.Models.V2_1_0.Common.Action;

namespace VDA5050_POCO.Models.V2_1_0;

/// <summary>
/// Represents the instant actions message that instructs the AGV to execute actions as soon as they arrive.
/// </summary>
[JsonObject]
public record InstantActions
{
    /// <summary>
    /// HeaderId of the message. The headerId is defined per topic and incremented by 1 with each sent (but not necessarily received) message.
    /// </summary>
    [JsonProperty("headerId", Required = Required.Always)]
    public required int HeaderId { get; init; }

    /// <summary>
    /// Timestamp in ISO8601 format (YYYY-MM-DDTHH:mm:ss.ssZ).
    /// </summary>
    [JsonProperty("timestamp", Required = Required.Always)]
    public required DateTime Timestamp { get; init; }

    /// <summary>
    /// Version of the protocol [Major].[Minor].[Patch] (e.g., 1.3.2).
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

    /// <summary>
    /// List of actions that the AGV is to execute as soon as they arrive.
    /// </summary>
    [JsonProperty("actions", Required = Required.Always)]
    public required List<Action> Actions { get; init; }
}
