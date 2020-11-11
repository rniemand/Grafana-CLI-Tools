namespace GrafanaCli.DevConsole.DevUtils.Builders
{
  public class DevGrafanaUrlBuilderBuilder
  {
    private readonly DevGrafanaUrlBuilder _builder;

    public DevGrafanaUrlBuilderBuilder()
    {
      _builder = new DevGrafanaUrlBuilder();
    }

    public DevGrafanaUrlBuilderBuilder WithListAllDashboardsUrl(string url)
    {
      // TODO: [TESTS] (DevGrafanaUrlBuilderBuilder.WithListAllDashboardsUrl) Add tests
      _builder.SetReturnUrl("ListAllDashboards", url);
      return this;
    }

    public DevGrafanaUrlBuilder Build()
    {
      return _builder;
    }
  }
}
