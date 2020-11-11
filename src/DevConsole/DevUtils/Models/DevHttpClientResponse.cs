using System;
using System.Net;
using GrafanaCli.DevConsole.DevUtils.Enums;

namespace GrafanaCli.DevConsole.DevUtils.Models
{
  public class DevHttpClientResponse
  {
    public string Url { get; set; }
    public DevHttpClientResponseType ResponseType { get; set; }
    public string FilePath { get; set; }
    public HttpStatusCode StatusCode { get; set; }
    public int ResponseDelayMs { get; set; }
    public string GeneratedResponseBody { get; set; }

    public DevHttpClientResponse()
    {
      // TODO: [TESTS] (DevHttpClientResponse.DevHttpClientResponse) Add tests

      Url = string.Empty;
      ResponseType = DevHttpClientResponseType.Unknown;
      FilePath = string.Empty;
      StatusCode = HttpStatusCode.OK;
      ResponseDelayMs = 0;
      GeneratedResponseBody = string.Empty;
    }

    public bool ExactUrlMatch(string url)
    {
      // TODO: [TESTS] (DevHttpClientResponse.ExactUrlMatch) Add tests
      return Url.Equals(url, StringComparison.InvariantCultureIgnoreCase);
    }
  }
}