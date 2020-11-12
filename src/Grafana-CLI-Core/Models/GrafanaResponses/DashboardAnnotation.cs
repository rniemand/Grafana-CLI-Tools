using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace GrafanaCli.Core.Models.GrafanaResponses
{
  public class DashboardAnnotation
  {
    [JsonProperty("builtIn"), JsonPropertyName("builtIn")]
    public int BuiltIn { get; set; }

    [JsonProperty("datasource"), JsonPropertyName("datasource")]
    public string Datasource { get; set; }

    [JsonProperty("enable"), JsonPropertyName("enable")]
    public bool Enable { get; set; }

    [JsonProperty("hide"), JsonPropertyName("hide")]
    public bool Hide { get; set; }

    [JsonProperty("iconColor"), JsonPropertyName("iconColor")]
    public string IconColor { get; set; }

    [JsonProperty("limit"), JsonPropertyName("limit")]
    public int Limit { get; set; }

    [JsonProperty("name"), JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonProperty("query"), JsonPropertyName("query")]
    public string Query { get; set; }

    [JsonProperty("showIn"), JsonPropertyName("showIn")]
    public int ShowIn { get; set; }

    [JsonProperty("tags"), JsonPropertyName("tags")]
    public object[] Tags { get; set; }

    [JsonProperty("tagsColumn"), JsonPropertyName("tagsColumn")]
    public string TagsColumn { get; set; }

    [JsonProperty("textColumn"), JsonPropertyName("textColumn")]
    public string TextColumn { get; set; }

    [JsonProperty("type"), JsonPropertyName("type")]
    public string Type { get; set; }

    public DashboardAnnotation()
    {
      // TODO: [TESTS] (DashboardAnnotation.DashboardAnnotation) Add tests
      BuiltIn = 1;
      Datasource = string.Empty;
      Enable = false;
      Hide = false;
      IconColor = string.Empty;
      Limit = 0;
      Name = string.Empty;
      Query = string.Empty;
      ShowIn = 0;
      Tags = new object[0];
      TagsColumn = string.Empty;
      TextColumn = string.Empty;
      Type = string.Empty;
    }
  }
}