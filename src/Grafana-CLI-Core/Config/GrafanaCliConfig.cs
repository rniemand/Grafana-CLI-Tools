using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace GrafanaCli.Core.Config
{
  public class GrafanaCliConfig
  {
    [JsonProperty("GrafanaBaseUrl"), JsonPropertyName("GrafanaBaseUrl")]
    public string GrafanaBaseUrl { get; set; }

    [JsonProperty("GrafanaApiToken"), JsonPropertyName("GrafanaApiToken")]
    public string GrafanaApiToken { get; set; }

    [JsonProperty("SearchResultPageLimit"), JsonPropertyName("SearchResultPageLimit")]
    public int SearchResultPageLimit { get; set; }

    [JsonProperty("DevConfig"), JsonPropertyName("DevConfig")]
    public DeveloperConfig DevConfig { get; set; }

    [JsonProperty("DataDirectory"), JsonPropertyName("DataDirectory")]
    public string DataDirectory { get; set; }

    [JsonProperty("AcceptAnyServerCertificate"), JsonPropertyName("AcceptAnyServerCertificate")]
    public bool AcceptAnyServerCertificate { get; set; }

    public GrafanaCliConfig()
    {
      // TODO: [TESTS] (GrafanaCliConfig.GrafanaCliConfig) Add tests
      GrafanaBaseUrl = string.Empty;
      GrafanaApiToken = string.Empty;
      DevConfig = new DeveloperConfig();
      SearchResultPageLimit = 100;
      DataDirectory = "./Grafana-data";
      AcceptAnyServerCertificate = false;
    }
  }
}
