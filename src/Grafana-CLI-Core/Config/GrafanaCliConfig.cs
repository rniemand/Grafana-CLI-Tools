namespace GrafanaCli.Core.Config
{
  public class GrafanaCliConfig
  {
    public string GrafanaBaseUrl { get; set; }
    public string GrafanaApiToken { get; set; }

    public GrafanaCliConfig()
    {
      // TODO: [TESTS] (GrafanaCliConfig.GrafanaCliConfig) Add tests
      GrafanaBaseUrl = string.Empty;
      GrafanaApiToken = string.Empty;
    }
  }
}
