using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using GrafanaCli.Core.Abstractions;
using GrafanaCli.Core.Clients;
using GrafanaCli.Core.Logging;
using GrafanaCli.DevConsole.DevUtils.Enums;
using GrafanaCli.DevConsole.DevUtils.Models;

namespace GrafanaCli.DevConsole.DevUtils.Clients
{
  public class DevGrafanaHttpClient : IGrafanaHttpClient
  {
    private readonly ILoggerAdapter<DevGrafanaHttpClient> _logger;
    private readonly IFile _file;
    private readonly List<DevHttpClientResponse> _responses;

    public DevGrafanaHttpClient(
      ILoggerAdapter<DevGrafanaHttpClient> logger,
      IFile file)
    {
      _logger = logger;
      _file = file;
      _responses = new List<DevHttpClientResponse>();
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
      await Task.Delay(response.ResponseDelayMs);

      GetResponseBody(response);



      throw new NotImplementedException();
    }

    // Configuration methods
    public void SetOkResponse(string url, string filePath)
    {
      // TODO: [TESTS] (DevGrafanaHttpClient.SetOkResponse) Add tests
      _responses.Add(new DevHttpClientResponse
      {
        ResponseType = DevHttpClientResponseType.File,
        Url = url,
        FilePath = filePath,
        StatusCode = HttpStatusCode.OK,
        ResponseDelayMs = DevHelper.Random.Next(10, 300)
      });
    }

    // Internal methods
    private DevHttpClientResponse GetResponse(HttpRequestMessage requestMessage)
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

    private void GetResponseBody(DevHttpClientResponse response)
    {
      // TODO: [TESTS] (DevGrafanaHttpClient.GetResponseBody) Add tests

      if (response.ResponseType == DevHttpClientResponseType.File)
      {

      }


    }
  }
}
