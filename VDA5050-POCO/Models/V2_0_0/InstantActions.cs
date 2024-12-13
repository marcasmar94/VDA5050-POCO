namespace VDA5050_POCO.Models.V2_0_0;

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using VDA5050_POCO.Models.V2_0_0.Common;


/// <summary>
/// Represents a message containing instant actions that the AGV is to execute as soon as they arrive.
/// </summary>
public record InstantActions
{
    /// <summary>
    /// Header ID of the message. Incremented by 1 with each sent (but not necessarily received) message.
    /// </summary>
    [JsonProperty(PropertyName = "headerId", Required = Required.Always)]
    public required int HeaderId { get; init; }

    /// <summary>
    /// Timestamp in ISO8601 format (YYYY-MM-DDTHH:mm:ss.ssZ).
    /// </summary>
    [JsonProperty(PropertyName = "timestamp", Required = Required.Always)]
    public required DateTime Timestamp { get; init; }

    /// <summary>
    /// Version of the protocol in the format [Major].[Minor].[Patch].
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
    /// List of actions that the AGV is to execute immediately.
    /// </summary>
    [JsonProperty(PropertyName = "actions", Required = Required.Always)]
    public required List<Common.Action> Actions { get; init; }
}
