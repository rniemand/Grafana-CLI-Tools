using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace GrafanaCli.Core.Models.GrafanaResponses
{
  public class DashboardAnnotations
  {
    [JsonProperty("list"), JsonPropertyName("list")]
    public DashboardAnnotation[] List { get; set; }
  }
}