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

    public DeveloperConfigBuilder AsEnabled()
    {
      _config.Enabled = true;
      return this;
    }

    public DeveloperConfigBuilder WithDevHttpClientEnabled(List<DevHttpResponse> responses = null)
    {
      _config.UseDevHttpClient = true;

      return responses?.Count > 0 ? WithHttpClientResponses(responses) : this;
    }

    public DeveloperConfigBuilder WithHttpClientResponses(List<DevHttpResponse> responses)
    {
      _config.HttpClientResponses = responses;
      return this;
    }

    public DeveloperConfig Build()
    {
      return _config;
    }
  }
}
