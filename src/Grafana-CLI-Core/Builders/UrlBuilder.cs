using System.Collections.Generic;
using System.Web;

namespace GrafanaCli.Core.Builders
{
  public class UrlBuilder
  {
    public string BaseUrl { get; set; }
    private readonly Dictionary<string, string> _params;

    public UrlBuilder(string baseUrlUrl)
    {
      // TODO: [TESTS] (UrlBuilder.UrlBuilder) Add tests
      BaseUrl = baseUrlUrl;
      _params = new Dictionary<string, string>();
    }

    public UrlBuilder WithParam(string key, string value)
    {
      // TODO: [TESTS] (UrlBuilder.WithParam) Add tests
      _params[key] = value;
      return this;
    }
    
    public UrlBuilder WithParam(string key, bool value)
    {
      // TODO: [TESTS] (UrlBuilder.WithParam) Add tests
      _params[key] = value ? "true" : "false";
      return this;
    }

    public UrlBuilder WithParam(string key, int value)
    {
      // TODO: [TESTS] (UrlBuilder.WithParam) Add tests
      _params[key] = value.ToString("D");
      return this;
    }

    public string Build()
    {
      // TODO: [TESTS] (UrlBuilder.Build) Add tests

      var encodedParams = new List<string>();
      foreach (var (param, value) in _params)
      {
        encodedParams.Add($"{UrlEncode(param)}={UrlEncode(value)}");
      }
      var builtParams = string.Join("&", encodedParams);
      if (builtParams.Length > 0) builtParams = $"?{builtParams}";


      return $"{BaseUrl}{builtParams}";
    }

    private string UrlEncode(string value)
    {
      // TODO: [TESTS] (UrlBuilder.UrlEncode) Add tests
      return HttpUtility.UrlEncode(value);
    }
  }
}
