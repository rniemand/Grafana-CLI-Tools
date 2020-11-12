using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using GrafanaCli.Core.Abstractions;
using GrafanaCli.Core.Builders;
using GrafanaCli.Core.Clients;
using GrafanaCli.Core.Config;
using GrafanaCli.Core.Logging;
using GrafanaCli.DevConsole.DevUtils;
using GrafanaCli.DevConsole.DevUtils.Builders;
using GrafanaCli.DevConsole.DevUtils.Clients;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;

namespace GrafanaCli.DevConsole
{
  class Program
  {
    private static IServiceProvider _provider;

    static void Main(string[] args)
    {
      var pathBuilder = new DevDataPathBuilder();

      var devUrls = new DevGrafanaUrlResponseBuilder()
        .WithSearchDashboards("foobar");

      var devResponses = new DevHttpResponsesBuilder()
        .WithOkJsonResponse("foobar", pathBuilder.ResponseFile("search.dashboards.all.success"));

      SetupDIContainer(new DeveloperConfigBuilder()
        //.WithDevHttpClient(devResponses.Build())
        //.WithGrafanaUrlBuilder(devUrls.Build())
        .Build());

      var grafanaClient = _provider.GetService<IGrafanaClient>();

      var dashboards = grafanaClient.SearchDashboards("hass")
        .ConfigureAwait(false)
        .GetAwaiter()
        .GetResult();

      var hassDashboard = dashboards.First();

      grafanaClient.GetDashboard(hassDashboard.Uid)
        .ConfigureAwait(false)
        .GetAwaiter()
        .GetResult();
    }

    private static void SetupDIContainer(DeveloperConfig developerConfig = null)
    {
      var collection = new ServiceCollection();

      if (developerConfig == null)
        developerConfig = new DeveloperConfig();

      var config = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
        .Build();

      collection
        .AddSingleton<IFile, FileAbstraction>()
        .AddSingleton<IGrafanaClient, GrafanaClient>()
        .AddSingleton<IJsonAbstraction, JsonAbstraction>()
        .AddSingleton(typeof(ILoggerAdapter<>), typeof(LoggerAdapter<>))
        .AddLogging(loggingBuilder =>
        {
          loggingBuilder.ClearProviders();
          loggingBuilder.SetMinimumLevel(LogLevel.Trace);
          loggingBuilder.AddNLog(config);
        });

      RegisterGrafanaCliConfig(collection, config, developerConfig);
      RegisterGrafanaUrlBuilder(collection, developerConfig);
      RegisterGrafanaHttpClient(collection, developerConfig);

      _provider = collection.BuildServiceProvider();
    }

    private static void RegisterGrafanaCliConfig(IServiceCollection collection, IConfiguration configuration, DeveloperConfig developerConfig)
    {
      var grafanaCliConfig = new GrafanaCliConfig();

      configuration.Bind("GrafanaCli", grafanaCliConfig);
      grafanaCliConfig.DevConfig = developerConfig;

      collection.AddSingleton(grafanaCliConfig);
    }

    private static void RegisterGrafanaUrlBuilder(IServiceCollection collection, DeveloperConfig developerConfig)
    {
      if (developerConfig.Enabled && developerConfig.UseDevGrafanaUrlBuilder)
      {
        collection.AddSingleton<IGrafanaUrlBuilder, DevGrafanaUrlBuilder>();
        return;
      }

      collection.AddSingleton<IGrafanaUrlBuilder, GrafanaUrlBuilder>();
    }

    private static void RegisterGrafanaHttpClient(IServiceCollection collection, DeveloperConfig developerConfig)
    {
      if (developerConfig.Enabled && developerConfig.UseDevHttpClient)
      {
        collection.AddSingleton<IGrafanaHttpClient, DevGrafanaHttpClient>();
        return;
      }

      collection.AddSingleton<IGrafanaHttpClient, GrafanaHttpClient>();
    }
  }
}
