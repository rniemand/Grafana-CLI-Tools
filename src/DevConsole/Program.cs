using System;
using System.IO;
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
      var responseFile = pathBuilder.ResponseFile("search.dashboards.all.success");

      var grafanaUrlBuilder = new DevGrafanaUrlBuilderBuilder()
        .WithListAllDashboardsUrl("foobar")
        .Build();

      var responsesBuilder = new DevHttpResponsesBuilder()
        .WithOkResponse("foobar", responseFile);

      var devConfig = new DeveloperConfigBuilder()
        .AsEnabled()
        .WithDevHttpClientEnabled(responsesBuilder.Build())
        .Build();

      SetupDIContainer(grafanaUrlBuilder, devConfig);

      var urlBuilder = _provider.GetService<IGrafanaUrlBuilder>();
      var httpClient = _provider.GetService<IGrafanaHttpClient>();

      var request = new HttpRequestMessage(HttpMethod.Get, urlBuilder.ListAllDashboards());

      var response = httpClient.SendAsync(request)
        .ConfigureAwait(false)
        .GetAwaiter()
        .GetResult();

      //var responseString = response.Content.ReadAsStringAsync()
      //  .ConfigureAwait(false)
      //  .GetAwaiter()
      //  .GetResult();


      Console.WriteLine("Hello World!");
    }

    private static void SetupDIContainer(
      IGrafanaUrlBuilder grafanaUrlBuilder = null,
      DeveloperConfig developerConfig = null)
    {
      var collection = new ServiceCollection();

      var config = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
        .Build();

      collection
        .AddSingleton<IFile, FileAbstraction>()
        .AddSingleton(typeof(ILoggerAdapter<>), typeof(LoggerAdapter<>))
        .AddLogging(loggingBuilder =>
        {
          loggingBuilder.ClearProviders();
          loggingBuilder.SetMinimumLevel(LogLevel.Trace);
          loggingBuilder.AddNLog(config);
        });

      RegisterGrafanaCliConfig(collection, config, developerConfig);
      RegisterGrafanaUrlBuilder(collection, grafanaUrlBuilder);
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

    private static void RegisterGrafanaUrlBuilder(IServiceCollection collection, IGrafanaUrlBuilder builder = null)
    {
      if (builder != null)
      {
        collection.AddSingleton(builder);
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
