using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using GrafanaCli.Core.Builders;
using GrafanaCli.Core.Config;
using GrafanaCli.Core.Models.GrafanaResponses;
using Rn.NetCore.Common.Helpers;
using Rn.NetCore.Common.Logging;

namespace GrafanaCli.Core.Clients
{
  public interface IGrafanaClient
  {
    Task<List<SearchResponse>> SearchDashboards(string query = null);
    Task<string> GetDashboardJson(string uid);
    Task GetDashboard(string uid);
  }

  public class GrafanaClient : IGrafanaClient
  {
    private readonly ILoggerAdapter<GrafanaClient> _logger;
    private readonly IGrafanaUrlBuilder _urlBuilder;
    private readonly IGrafanaHttpClient _httpClient;
    private readonly IJsonHelper _jsonHelper;
    private readonly GrafanaCliConfig _config;

    public GrafanaClient(
      ILoggerAdapter<GrafanaClient> logger,
      IGrafanaUrlBuilder urlBuilder,
      IGrafanaHttpClient httpClient,
      IJsonHelper jsonHelper,
      GrafanaCliConfig config)
    {
      // TODO: [TESTS] (GrafanaClient.GrafanaClient) Add tests
      _logger = logger;
      _urlBuilder = urlBuilder;
      _httpClient = httpClient;
      _jsonHelper = jsonHelper;
      _config = config;

      _logger.Trace("New instance created");
    }

    public async Task<List<SearchResponse>> SearchDashboards(string query = null)
    {
      // TODO: [TESTS] (GrafanaClient.SearchDashboards) Add tests
      // TODO: [TRY] (GrafanaClient.SearchDashboards) Handle exceptions...

      var allResults = new List<SearchResponse>();
      var endOfResults = false;
      var pageNumber = 1;

      while (!endOfResults)
      {
        var url = _urlBuilder.ListAllDashboards(query,
          _config.SearchResultPageLimit,
          pageNumber++
        );

        var request = new HttpRequestMessage(HttpMethod.Get, url);
        var response = await _httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();
        var responseBody = await response.Content.ReadAsStringAsync();
        var results = _jsonHelper.DeserializeObject<SearchResponse[]>(responseBody);
        allResults.AddRange(results);

        // Check if we are at the end of the results
        if (pageNumber == 1 && results.Length < _config.SearchResultPageLimit)
          endOfResults = true;

        if (results.Length == 0)
          endOfResults = true;
      }

      return allResults;
    }

    public async Task<string> GetDashboardJson(string uid)
    {
      // TODO: [TESTS] (GrafanaClient.GetDashboardJson) Add tests

      var dashboardUrl = _urlBuilder.GetDashboard(uid);
      var request = new HttpRequestMessage(HttpMethod.Get, dashboardUrl);
      var response = await _httpClient.SendAsync(request);
      response.EnsureSuccessStatusCode();
      return await response.Content.ReadAsStringAsync();
    }

    public async Task GetDashboard(string uid)
    {
      // TODO: [TESTS] (GrafanaClient.GetDashboard) Add tests

      var dashboardUrl = _urlBuilder.GetDashboard(uid);
      var request = new HttpRequestMessage(HttpMethod.Get, dashboardUrl);
      var response = await _httpClient.SendAsync(request);
      response.EnsureSuccessStatusCode();
      var responseBody = await response.Content.ReadAsStringAsync();

      var dashboard = _jsonHelper.DeserializeObject<GrafanaDashboardInfo>(responseBody);
    }
  }
}
