using System;
using System.IO;
using System.Net.Http;
using GrafanaCli.Core.Builders;
using GrafanaCli.Core.Clients;
using GrafanaCli.Core.Config;
using GrafanaCli.Core.Logging;
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
      SetupDIContainer();

      var urlBuilder = _provider.GetService<IGrafanaUrlBuilder>();
      var httpClient = _provider.GetService<IGrafanaHttpClient>();

      var request = new HttpRequestMessage(HttpMethod.Get, urlBuilder.ListAllDashboards());

      var response = httpClient.SendAsync(request)
        .ConfigureAwait(false)
        .GetAwaiter()
        .GetResult();


      Console.WriteLine("Hello World!");
    }

    private static void SetupDIContainer()
    {
      var collection = new ServiceCollection();

      var config = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
        .Build();

      var grafanaCliConfig = new GrafanaCliConfig();
      config.Bind("GrafanaCli", grafanaCliConfig);

      collection
        .AddSingleton(grafanaCliConfig)
        .AddSingleton<IGrafanaUrlBuilder, GrafanaUrlBuilder>()
        .AddSingleton<IGrafanaHttpClient, GrafanaHttpClient>()
        .AddSingleton(typeof(ILoggerAdapter<>), typeof(LoggerAdapter<>))
        .AddLogging(loggingBuilder =>
        {
          loggingBuilder.ClearProviders();
          loggingBuilder.SetMinimumLevel(LogLevel.Trace);
          loggingBuilder.AddNLog(config);
        });

      _provider = collection.BuildServiceProvider();
    }
  }
}
