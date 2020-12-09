using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using GrafanaCli.Core.Config;
using Rn.NetCore.Common.Logging;

namespace GrafanaCli.Core.Clients
{
  public interface IGrafanaHttpClient
  {
    Task<HttpResponseMessage> SendAsync(HttpRequestMessage requestMessage);
  }

  public class GrafanaHttpClient : IGrafanaHttpClient
  {
    private readonly ILoggerAdapter<GrafanaHttpClient> _logger;
    private readonly HttpClient _httpClient;

    public GrafanaHttpClient(
      ILoggerAdapter<GrafanaHttpClient> logger,
      GrafanaCliConfig config)
    {
      // TODO: [TESTS] (GrafanaHttpClient.GrafanaHttpClient) Add tests

      _logger = logger;
      _httpClient = new HttpClient();

      _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
        "Bearer",
        config.GrafanaApiToken
      );
    }

    public async Task<HttpResponseMessage> SendAsync(HttpRequestMessage requestMessage)
    {
      // TODO: [TESTS] (GrafanaHttpClient.SendAsync) Add tests

      return await _httpClient.SendAsync(requestMessage);
    }
  }
}
