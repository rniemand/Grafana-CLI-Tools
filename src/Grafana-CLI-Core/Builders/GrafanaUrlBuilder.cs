using GrafanaCli.Core.Config;
using GrafanaCli.Core.Extensions;
using GrafanaCli.Core.Logging;

namespace GrafanaCli.Core.Builders
{
  public interface IGrafanaUrlBuilder
  {
    string ListAllDashboards();
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

    public string ListAllDashboards()
    {
      // TODO: [TESTS] (GrafanaUrlBuilder.ListAllDashboards) Add tests
      // TODO: [COMPLETE] (GrafanaUrlBuilder.ListAllDashboards) Add support for pagination

      var url = $"{_baseUrl}api/search?type=dash-db";
      _logger.Trace("Search URL: {url}", url);
      return url;
    }
  }
}
