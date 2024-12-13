using Newtonsoft.Json;

namespace VDA5050_POCO.Models.V2_0_0.FactSheet;

/// <summary>
/// Describes localization parameters of the AGV.
/// </summary>
public record LocalizationParameters
{
    [JsonProperty(PropertyName = "localizationParameter1")]
    public string? LocalizationParameter1 { get; init; }

    [JsonProperty(PropertyName = "localizationParameter2")]
    public string? LocalizationParameter2 { get; init; }
}