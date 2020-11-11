using System;
using System.IO;
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

      _provider.GetService<ILoggerAdapter<Program>>().LogTrace("Hello World");
      var config = _provider.GetService<GrafanaCliConfig>();

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
