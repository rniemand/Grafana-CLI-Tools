using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace GrafanaCli.Core.Models.GrafanaResponses
{
  public class Dashboard
  {
    [JsonProperty("annotations"), JsonPropertyName("annotations")]
    public DashboardAnnotations Annotations { get; set; }

    [JsonProperty("editable"), JsonPropertyName("editable")]
    public bool Editable { get; set; }

    // TODO: [COMPLETE] (Dashboard.gnetId) Complete me
    public object gnetId { get; set; }

    [JsonProperty("graphTooltip"), JsonPropertyName("graphTooltip")]
    public int GraphTooltip { get; set; }

    [JsonProperty("id"), JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonProperty("links"), JsonPropertyName("links")]
    public DashboardLink[] Links { get; set; }

    [JsonProperty("panels"), JsonPropertyName("panels")]
    public Panel[] Panels { get; set; }

    [JsonProperty("schemaVersion"), JsonPropertyName("schemaVersion")]
    public int SchemaVersion { get; set; }

    [JsonProperty("style"), JsonPropertyName("style")]
    public string Style { get; set; }

    [JsonProperty("tags"), JsonPropertyName("tags")]
    public string[] Tags { get; set; }

    [JsonProperty("templating"), JsonPropertyName("templating")]
    public Templating Templating { get; set; }

    [JsonProperty("time"), JsonPropertyName("time")]
    public Time Time { get; set; }

    [JsonProperty("timepicker"), JsonPropertyName("timepicker")]
    public TimePicker TimePicker { get; set; }

    [JsonProperty("timezone"), JsonPropertyName("timezone")]
    public string Timezone { get; set; }

    [JsonProperty("title"), JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonProperty("uid"), JsonPropertyName("uid")]
    public string Uid { get; set; }

    [JsonProperty("version"), JsonPropertyName("version")]
    public int Version { get; set; }

    public Dashboard()
    {
      // TODO: [TESTS] (Dashboard.Dashboard) Add tests
      Annotations = new DashboardAnnotations();
      Editable = false;
      GraphTooltip = 0;
      Id = 0;
      Panels = new Panel[0];
      SchemaVersion = 0;
      Style = string.Empty;
      Tags = new string[0];
      Templating = new Templating();
      Time = new Time();
      TimePicker = new TimePicker();
      Timezone = string.Empty;
      Title = string.Empty;
      Uid = string.Empty;
      Version = 0;
      Links = new DashboardLink[0];
    }
  }
}