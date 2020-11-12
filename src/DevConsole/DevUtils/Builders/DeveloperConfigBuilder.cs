using System.Collections.Generic;
using GrafanaCli.Core.Config;
using GrafanaCli.Core.Models;

namespace GrafanaCli.DevConsole.DevUtils.Builders
{
  public class DeveloperConfigBuilder
  {
    private readonly DeveloperConfig _config;

    public DeveloperConfigBuilder()
    {
      _config = new DeveloperConfig();
    }

    public DeveloperConfigBuilder WithDevHttpClient(List<DevHttpResponse> responses = null)
    {
      _config.Enabled = true;
      _config.UseDevHttpClient = true;
      _config.HttpClientResponses = responses ?? new List<DevHttpResponse>();
      return this;
    }

    public DeveloperConfigBuilder WithGrafanaUrlBuilder(Dictionary<string, string> urls = null)
    {
      // TODO: [TESTS] (DeveloperConfigBuilder.With) Add tests
      _config.Enabled = true;
      _config.UseDevGrafanaUrlBuilder = true;
      _config.UrlBuilderConfig = urls ?? new Dictionary<string, string>();
      return this;
    }

    public DeveloperConfig Build()
    {
      return _config;
    }
  }
}
