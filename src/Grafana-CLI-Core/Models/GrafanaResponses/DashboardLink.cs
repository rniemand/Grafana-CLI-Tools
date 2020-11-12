using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace GrafanaCli.Core.Models.GrafanaResponses
{
  public class DashboardLink
  {
    [JsonProperty("asDropdown"), JsonPropertyName("asDropdown")]
    public bool AsDropdown { get; set; }

    [JsonProperty("icon"), JsonPropertyName("icon")]
    public string Icon { get; set; }

    [JsonProperty("includeVars"), JsonPropertyName("includeVars")]
    public bool IncludeVars { get; set; }

    [JsonProperty("keepTime"), JsonPropertyName("keepTime")]
    public bool KeepTime { get; set; }

    [JsonProperty("tags"), JsonPropertyName("tags")]
    public string[] Tags { get; set; }

    [JsonProperty("targetBlank"), JsonPropertyName("targetBlank")]
    public bool TargetBlank { get; set; }

    [JsonProperty("title"), JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonProperty("type"), JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonProperty("tooltip"), JsonPropertyName("tooltip")]
    public string Tooltip { get; set; }

    [JsonProperty("url"), JsonPropertyName("url")]
    public string Url { get; set; }

    public DashboardLink()
    {
      // TODO: [TESTS] (DashboardLink.DashboardLink) Add tests
      AsDropdown = false;
      Icon = string.Empty;
      IncludeVars = false;
      KeepTime = false;
      Tags = new string[0];
      TargetBlank = false;
      Title = string.Empty;
      Type = string.Empty;
      Tooltip = string.Empty;
      Url = string.Empty;
    }
  }
}