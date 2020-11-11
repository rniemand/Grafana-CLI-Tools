using GrafanaCli.DevConsole.DevUtils.Clients;

namespace GrafanaCli.DevConsole.DevUtils.Builders
{
  public class DevGrafanaHttpClientBuilder
  {
    private readonly DevGrafanaHttpClient _client;

    public DevGrafanaHttpClientBuilder()
    {
      _client = new DevGrafanaHttpClient();
    }

    public DevGrafanaHttpClientBuilder WithOkResponse(string url, string filePath)
    {
      // TODO: [TESTS] (DevGrafanaHttpClientBuilder.WithOkResponse) Add tests
      _client.SetOkResponse(url, filePath);
      return this;
    }

    public DevGrafanaHttpClient Build()
    {
      return _client;
    }
  }
}
