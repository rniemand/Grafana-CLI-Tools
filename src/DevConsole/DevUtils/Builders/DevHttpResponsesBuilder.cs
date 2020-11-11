using System.Collections.Generic;
using System.Net;
using System.Text;
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

    public DevHttpResponsesBuilder WithOkJsonResponse(string url, string filePath)
    {
      // TODO: [TESTS] (DevHttpResponsesBuilder.WithOkJsonResponse) Add tests

      _responses.Add(new DevHttpResponse
      {
        ResponseType = DevHttpClientResponseType.File,
        Url = url,
        FilePath = filePath,
        StatusCode = HttpStatusCode.OK,
        ResponseDelayMs = DevHelper.Random.Next(10, 300),
        ContentType = "application/json",
        ContentEncoding = Encoding.UTF8,
        SetResponseContent = true
      });

      return this;
    }

    public List<DevHttpResponse> Build()
    {
      return _responses;
    }
  }
}
