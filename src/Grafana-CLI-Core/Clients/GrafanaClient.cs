using System.Net.Http;
using System.Threading.Tasks;
using GrafanaCli.Core.Builders;
using GrafanaCli.Core.Logging;

namespace GrafanaCli.Core.Clients
{
  public interface IGrafanaClient
  {
    Task ListAllDashboards();
  }

  public class GrafanaClient : IGrafanaClient
  {
    private readonly ILoggerAdapter<GrafanaClient> _logger;
    private readonly IGrafanaUrlBuilder _urlBuilder;
    private readonly IGrafanaHttpClient _httpClient;

    public GrafanaClient(
      ILoggerAdapter<GrafanaClient> logger,
      IGrafanaUrlBuilder urlBuilder,
      IGrafanaHttpClient httpClient)
    {
      // TODO: [TESTS] (GrafanaClient.GrafanaClient) Add tests
      _logger = logger;
      _urlBuilder = urlBuilder;
      _httpClient = httpClient;

      _logger.Trace("New instance created");
    }

    public async Task ListAllDashboards()
    {
      // TODO: [TESTS] (GrafanaClient.ListAllDashboards) Add tests
      // TODO: [PAGINATION] (GrafanaClient.ListAllDashboards) Add support for pagination

      var request = new HttpRequestMessage(
        HttpMethod.Get,
        _urlBuilder.ListAllDashboards()
      );

      var response = await _httpClient.SendAsync(request);
      response.EnsureSuccessStatusCode();

      var responseBody = await response.Content.ReadAsStringAsync();

    }
  }
}
