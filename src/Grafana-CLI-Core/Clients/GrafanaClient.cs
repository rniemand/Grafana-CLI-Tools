using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using GrafanaCli.Core.Abstractions;
using GrafanaCli.Core.Builders;
using GrafanaCli.Core.Config;
using GrafanaCli.Core.Logging;
using GrafanaCli.Core.Models.GrafanaResponses;

namespace GrafanaCli.Core.Clients
{
  public interface IGrafanaClient
  {
    Task<List<SearchResponse>> SearchDashboards(string query);
  }

  public class GrafanaClient : IGrafanaClient
  {
    private readonly ILoggerAdapter<GrafanaClient> _logger;
    private readonly IGrafanaUrlBuilder _urlBuilder;
    private readonly IGrafanaHttpClient _httpClient;
    private readonly IJsonAbstraction _jsonAbstraction;
    private readonly GrafanaCliConfig _config;

    public GrafanaClient(
      ILoggerAdapter<GrafanaClient> logger,
      IGrafanaUrlBuilder urlBuilder,
      IGrafanaHttpClient httpClient,
      IJsonAbstraction jsonAbstraction,
      GrafanaCliConfig config)
    {
      // TODO: [TESTS] (GrafanaClient.GrafanaClient) Add tests
      _logger = logger;
      _urlBuilder = urlBuilder;
      _httpClient = httpClient;
      _jsonAbstraction = jsonAbstraction;
      _config = config;

      _logger.Trace("New instance created");
    }

    public async Task<List<SearchResponse>> SearchDashboards(string query)
    {
      // TODO: [TESTS] (GrafanaClient.SearchDashboards) Add tests
      // TODO: [TRY] (GrafanaClient.SearchDashboards) Handle exceptions...

      var allResults = new List<SearchResponse>();
      var endOfResults = false;
      var pageNumber = 1;

      while (!endOfResults)
      {
        var url = _urlBuilder.ListAllDashboards(
          query,
          _config.SearchResultPageLimit,
          pageNumber++
        );

        var request = new HttpRequestMessage(HttpMethod.Get, url);
        var response = await _httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();
        var responseBody = await response.Content.ReadAsStringAsync();
        var results = _jsonAbstraction.DeserializeObject<SearchResponse[]>(responseBody);
        allResults.AddRange(results);

        // Check if we are at the end of the results
        if (pageNumber == 1 && results.Length < _config.SearchResultPageLimit)
          endOfResults = true;

        if (results.Length == 0)
          endOfResults = true;
      }

      return allResults;
    }
  }
}
