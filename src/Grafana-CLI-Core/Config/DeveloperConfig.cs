using System.Collections.Generic;
using System.Text.Json.Serialization;
using GrafanaCli.Core.Models;
using Newtonsoft.Json;

namespace GrafanaCli.Core.Config
{
  public class DeveloperConfig
  {
    [JsonProperty("Enabled"), JsonPropertyName("Enabled")]
    public bool Enabled { get; set; }

    [JsonProperty("UseDevHttpClient"), JsonPropertyName("UseDevHttpClient")]
    public bool UseDevHttpClient { get; set; }

    [JsonProperty("UseDevGrafanaUrlBuilder"), JsonPropertyName("UseDevGrafanaUrlBuilder")]
    public bool UseDevGrafanaUrlBuilder { get; set; }

    [JsonProperty("HttpClientResponses"), JsonPropertyName("HttpClientResponses")]
    public List<DevHttpResponse> HttpClientResponses { get; set; }

    [JsonProperty("UrlBuilderConfig"), JsonPropertyName("UrlBuilderConfig")]
    public Dictionary<string, string> UrlBuilderConfig { get; set; }

    public DeveloperConfig()
    {
      // TODO: [TESTS] (DeveloperConfig.DeveloperConfig) Add tests
      Enabled = false;
      UseDevHttpClient = false;
      UseDevGrafanaUrlBuilder = false;
      HttpClientResponses = new List<DevHttpResponse>();
      UrlBuilderConfig = new Dictionary<string, string>();
    }
  }
}
