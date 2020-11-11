using System.Collections.Generic;
using System.Net;
using GrafanaCli.Core.Enums;
using GrafanaCli.Core.Models;

namespace GrafanaCli.DevConsole.DevUtils.Builders
{
  public class DevHttpResponsesBuilder
  {
    private readonly List<DevHttpResponse> _responses;

    public DevHttpResponsesBuilder()
    {
      _responses = new List<DevHttpResponse>();
    }

    public DevHttpResponsesBuilder WithOkResponse(string url, string filePath)
    {
      // TODO: [TESTS] (DevHttpResponsesBuilder.WithOkResponse) Add tests

      _responses.Add(new DevHttpResponse
      {
        ResponseType = DevHttpClientResponseType.File,
        Url = url,
        FilePath = filePath,
        StatusCode = HttpStatusCode.OK,
        ResponseDelayMs = DevHelper.Random.Next(10, 300)
      });

      return this;
    }

    public List<DevHttpResponse> Build()
    {
      return _responses;
    }
  }
}
