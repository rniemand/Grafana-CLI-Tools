using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using GrafanaCli.Core.Abstractions;
using GrafanaCli.Core.Clients;
using GrafanaCli.Core.Config;
using GrafanaCli.Core.Enums;
using GrafanaCli.Core.Logging;
using GrafanaCli.Core.Models;

namespace GrafanaCli.DevConsole.DevUtils.Clients
{
  public class DevGrafanaHttpClient : IGrafanaHttpClient
  {
    private readonly ILoggerAdapter<DevGrafanaHttpClient> _logger;
    private readonly IFile _file;
    private readonly List<DevHttpResponse> _responses;

    public DevGrafanaHttpClient(
      ILoggerAdapter<DevGrafanaHttpClient> logger,
      IFile file,
      GrafanaCliConfig config)
    {
      // TODO: [TESTS] (DevGrafanaHttpClient.DevGrafanaHttpClient) Add tests

      _logger = logger;
      _file = file;
      _responses = config.DevConfig.HttpClientResponses;
    }

    // Interface methods
    public async Task<HttpResponseMessage> SendAsync(HttpRequestMessage requestMessage)
    {
      // TODO: [TESTS] (DevGrafanaHttpClient.SendAsync) Add tests

      var response = GetResponse(requestMessage);

      if (response == null)
      {
        // TODO: [LOGGING] (DevGrafanaHttpClient.SendAsync) Add logging
        // TODO: [EX] (DevGrafanaHttpClient.SendAsync) Throw a better exception here
        throw new Exception("Unable to find configured response!");
      }

      var httpResponse = new HttpResponseMessage(response.StatusCode);
      if (response.SetResponseContent)
      {
        httpResponse.Content = new StringContent(
          GetResponseBody(response),
          response.ContentEncoding,
          response.ContentType
        );
      }

      await Task.Delay(response.ResponseDelayMs);
      return httpResponse;
    }

    // Internal methods
    private DevHttpResponse GetResponse(HttpRequestMessage requestMessage)
    {
      // TODO: [TESTS] (DevGrafanaHttpClient.GetResponse) Add tests
      var url = requestMessage.RequestUri.OriginalString;

      // Find exact matches
      var match = _responses.FirstOrDefault(x => x.ExactUrlMatch(url));

      if (match != null)
      {
        _logger.Information("Found matching response ({url}) {type}",
          url, match.ResponseType.ToString("G")
        );

        return match;
      }

      // Unable to find a matching response
      _logger.Warning("Unable to find matching response for: {url}", url);
      return null;
    }

    private string GetResponseBody(DevHttpResponse response)
    {
      // TODO: [TESTS] (DevGrafanaHttpClient.GetResponseBody) Add tests
      if (response.ResponseType == DevHttpClientResponseType.File)
      {
        if (string.IsNullOrWhiteSpace(response.GeneratedResponseBody))
        {
          if (!_file.Exists(response.FilePath))
          {
            // TODO: [EX] (DevGrafanaHttpClient.GetResponseBody) Throw better exception here
            _logger.Error("Unable to find response file: {path}", response.FilePath);
            throw new Exception($"Unable to find response file: {response.FilePath}");
          }

          response.GeneratedResponseBody = _file.ReadAllText(response.FilePath);
          _logger.Trace("Set GeneratedResponseBody using {path}", response.FilePath);
        }

        return response.GeneratedResponseBody;
      }

      // TODO: [COMPLETE] (DevGrafanaHttpClient.GetResponseBody) Complete me
      return string.Empty;
    }
  }
}
