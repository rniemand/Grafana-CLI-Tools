﻿namespace GrafanaCli.Core.Config
{
  public class GrafanaCliConfig
  {
    public string GrafanaBaseUrl { get; set; }
    public string GrafanaApiToken { get; set; }
    public int SearchResultPageLimit { get; set; }
    public DeveloperConfig DevConfig { get; set; }
    public string DataDirectory { get; set; }

    public GrafanaCliConfig()
    {
      // TODO: [TESTS] (GrafanaCliConfig.GrafanaCliConfig) Add tests
      GrafanaBaseUrl = string.Empty;
      GrafanaApiToken = string.Empty;
      DevConfig = new DeveloperConfig();
      SearchResultPageLimit = 100;
      DataDirectory = "./Grafana-data";
    }
  }
}
