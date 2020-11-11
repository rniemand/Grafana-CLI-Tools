namespace GrafanaCli.Core.Config
{
  public class GrafanaCliConfig
  {
    public string BaseUrl { get; set; }
    public string ApiKey { get; set; }

    public GrafanaCliConfig()
    {
      // TODO: [TESTS] (GrafanaCliConfig.GrafanaCliConfig) Add tests
      BaseUrl = string.Empty;
      ApiKey = string.Empty;
    }
  }
}
