using System.Collections.Generic;
using GrafanaCli.Core.Models;

namespace GrafanaCli.Core.Config
{
  public class DeveloperConfig
  {
    public bool Enabled { get; set; }
    public bool UseDevHttpClient { get; set; }
    public List<DevHttpResponse> HttpClientResponses { get; set; }

    public DeveloperConfig()
    {
      // TODO: [TESTS] (DeveloperConfig.DeveloperConfig) Add tests
      Enabled = false;
      UseDevHttpClient = false;
      HttpClientResponses = new List<DevHttpResponse>();
    }
  }
}
