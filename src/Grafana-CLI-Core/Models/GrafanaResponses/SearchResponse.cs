using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace GrafanaCli.Core.Models.GrafanaResponses
{
  public class SearchResponse
  {
    [JsonProperty("id"), JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonProperty("uid"), JsonPropertyName("uid")]
    public string Uid { get; set; }

    [JsonProperty("title"), JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonProperty("uri"), JsonPropertyName("uri")]
    public string Uri { get; set; }

    [JsonProperty("url"), JsonPropertyName("url")]
    public string Url { get; set; }

    [JsonProperty("slug"), JsonPropertyName("slug")]
    public string Slug { get; set; }

    [JsonProperty("type"), JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonProperty("tags"), JsonPropertyName("tags")]
    public string[] Tags { get; set; }

    [JsonProperty("isStarred"), JsonPropertyName("isStarred")]
    public bool IsStarred { get; set; }
  }
}
