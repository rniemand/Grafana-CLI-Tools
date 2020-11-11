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

      var grafanaHttpClient = new DevGrafanaHttpClientBuilder()
        .WithOkResponse("foobar", responseFile)
        .Build();

      SetupDIContainer(grafanaUrlBuilder, grafanaHttpClient);

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
      IGrafanaHttpClient grafanaHttpClient = null)
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

      RegisterGrafanaCliConfig(collection, config);
      RegisterGrafanaUrlBuilder(collection, grafanaUrlBuilder);
      RegisterGrafanaHttpClient(collection, grafanaHttpClient);

      _provider = collection.BuildServiceProvider();
    }

    private static void RegisterGrafanaCliConfig(IServiceCollection collection, IConfiguration configuration)
    {
      var grafanaCliConfig = new GrafanaCliConfig();
      configuration.Bind("GrafanaCli", grafanaCliConfig);
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

    private static void RegisterGrafanaHttpClient(IServiceCollection collection, IGrafanaHttpClient httpClient = null)
    {
      if (httpClient != null)
      {
        collection.AddSingleton(httpClient);
        return;
      }

      collection.AddSingleton<IGrafanaHttpClient, GrafanaHttpClient>();
    }
  }
}
