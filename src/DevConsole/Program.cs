using System;
using System.IO;
using GrafanaCli.Core.Builders;
using GrafanaCli.Core.Clients;
using GrafanaCli.Core.Config;
using GrafanaCli.DevConsole.DevUtils.Builders;
using GrafanaCli.DevConsole.DevUtils.Clients;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using Rn.NetCore.Common.Abstractions;
using Rn.NetCore.Common.Helpers;
using Rn.NetCore.Common.Logging;

namespace GrafanaCli.DevConsole
{
  class Program
  {
    private static IServiceProvider _provider;

    static void Main(string[] args)
    {
      SetupDIContainer(new DeveloperConfigBuilder()
        //.WithDevHttpClient(devResponses.Build())
        //.WithGrafanaUrlBuilder(devUrls.Build())
        .Build());

      var grafanaClient = _provider.GetService<IGrafanaClient>();

      var dashboards = grafanaClient.SearchDashboards()
        .ConfigureAwait(false)
        .GetAwaiter()
        .GetResult();

      foreach (var dashboard in dashboards)
      {
        var dashboardJson = grafanaClient.GetDashboardJson(dashboard.Uid)
          .ConfigureAwait(false)
          .GetAwaiter()
          .GetResult();
      }


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
        .AddSingleton<IFileAbstraction, FileAbstraction>()
        .AddSingleton<IGrafanaClient, GrafanaClient>()
        .AddSingleton<IJsonHelper, JsonHelper>()
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
