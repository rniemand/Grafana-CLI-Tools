using GrafanaCli.Core.Config;
using GrafanaCli.Core.Extensions;
using GrafanaCli.Core.Logging;

namespace GrafanaCli.Core.Builders
{
  public interface IGrafanaUrlBuilder
  {
    string ListAllDashboards(string query, int limit, int page);
    string GetDashboard(string uid);
  }

  public class GrafanaUrlBuilder : IGrafanaUrlBuilder
  {
    private readonly ILoggerAdapter<GrafanaUrlBuilder> _logger;
    private readonly string _baseUrl;

    // https://grafana.com/docs/grafana/latest/http_api/

    public GrafanaUrlBuilder(
      ILoggerAdapter<GrafanaUrlBuilder> logger,
      GrafanaCliConfig config)
    {
      _logger = logger;
      // TODO: [TESTS] (GrafanaUrlBuilder.GrafanaUrlBuilder) Add tests

      _baseUrl = config.GrafanaBaseUrl.AppendIfMissing("/");
      _logger.Trace("Base URL set to: {url}", _baseUrl);
    }

    public string ListAllDashboards(string query, int limit, int page)
    {
      // TODO: [TESTS] (GrafanaUrlBuilder.SearchDashboards) Add tests
      var url = new UrlBuilder($"{_baseUrl}api/search")
        .WithParam("query", query)
        .WithParam("type", "dash-db")
        .WithParam("limit", limit)
        .WithParam("page", page)
        .Build();

      _logger.Trace("Search URL: {url}", url);
      return url;
    }

    public string GetDashboard(string uid)
    {
      // TODO: [TESTS] (GrafanaUrlBuilder.GetDashboard) Add tests
      var url = $"{_baseUrl}api/dashboards/uid/{uid}";
      _logger.Trace("Dashboard by UID: {url}", url);
      return url;
    }
  }
}
