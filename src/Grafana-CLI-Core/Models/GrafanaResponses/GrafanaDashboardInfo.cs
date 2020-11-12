using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace GrafanaCli.Core.Models.GrafanaResponses
{
  public class GrafanaDashboardInfo
  {
    [JsonProperty("meta"), JsonPropertyName("meta")]
    public GrafanaMetadata Meta { get; set; }

    [JsonProperty("dashboard"), JsonPropertyName("dashboard")]
    public Dashboard Dashboard { get; set; }
  }

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

    // TODO: [COMPLETE] (Dashboard.links) Complete me
    public object[] links { get; set; }

    [JsonProperty("panels"), JsonPropertyName("panels")]
    public Panel[] Panels { get; set; }
    public int schemaVersion { get; set; }
    public string style { get; set; }
    public object[] tags { get; set; }
    public Templating templating { get; set; }
    public Time time { get; set; }
    public Timepicker timepicker { get; set; }
    public string timezone { get; set; }
    public string title { get; set; }
    public string uid { get; set; }
    public int version { get; set; }

    public Dashboard()
    {
      // TODO: [TESTS] (Dashboard.Dashboard) Add tests
      Annotations = new DashboardAnnotations();
      Editable = false;
      GraphTooltip = 0;
      Id = 0;
      Panels = new Panel[0];
    }
  }

  public class DashboardAnnotations
  {
    [JsonProperty("list"), JsonPropertyName("list")]
    public DashboardAnnotation[] List { get; set; }
  }



  public class Templating
  {
    public object[] list { get; set; }
  }

  public class Time
  {
    public string from { get; set; }
    public string to { get; set; }
  }

  public class Timepicker
  {
  }

  public class Panel
  {
    [JsonProperty("aliasColors"), JsonPropertyName("aliasColors")]
    public Aliascolors AliasColors { get; set; }

    [JsonProperty("bars"), JsonPropertyName("bars")]
    public bool Bars { get; set; }

    [JsonProperty("dashLength"), JsonPropertyName("dashLength")]
    public int DashLength { get; set; }

    [JsonProperty("dashes"), JsonPropertyName("dashes")]
    public bool Dashes { get; set; }

    [JsonProperty("datasource"), JsonPropertyName("datasource")]
    public string Datasource { get; set; }

    [JsonProperty("fieldConfig"), JsonPropertyName("fieldConfig")]
    public Fieldconfig FieldConfig { get; set; }

    public int fill { get; set; }
    public int fillGradient { get; set; }
    public Gridpos gridPos { get; set; }
    public bool hiddenSeries { get; set; }
    public int id { get; set; }
    public Legend legend { get; set; }
    public bool lines { get; set; }
    public int linewidth { get; set; }
    public string nullPointMode { get; set; }
    public Options options { get; set; }
    public bool percentage { get; set; }
    public string pluginVersion { get; set; }
    public int pointradius { get; set; }
    public bool points { get; set; }
    public string renderer { get; set; }
    public object[] seriesOverrides { get; set; }
    public int spaceLength { get; set; }
    public bool stack { get; set; }
    public bool steppedLine { get; set; }
    public Target[] targets { get; set; }
    public object[] thresholds { get; set; }
    public object timeFrom { get; set; }
    public object[] timeRegions { get; set; }
    public object timeShift { get; set; }
    public string title { get; set; }
    public Tooltip tooltip { get; set; }
    public string type { get; set; }
    public Xaxis xaxis { get; set; }
    public Yax[] yaxes { get; set; }
    public Yaxis yaxis { get; set; }

    public Panel()
    {
      // TODO: [TESTS] (Panel.Panel) Add tests
      AliasColors = new Aliascolors();
      Bars = false;
      DashLength = 0;
      Dashes = false;
      Datasource = string.Empty;
      FieldConfig = new Fieldconfig();
    }
  }

  public class Aliascolors
  {
  }

  public class Fieldconfig
  {
    [JsonProperty("defaults"), JsonPropertyName("defaults")]
    public Defaults Defaults { get; set; }

    [JsonProperty("overrides"), JsonPropertyName("overrides")]
    public object[] Overrides { get; set; }

    public Fieldconfig()
    {
      // TODO: [TESTS] (Fieldconfig.Fieldconfig) Add tests
      // TODO: [COMPLETE] (Fieldconfig.Fieldconfig) Complete porting
      Defaults = new Defaults();
      Overrides = new object [0];
    }
  }

  public class Defaults
  {
    [JsonProperty("custom"), JsonPropertyName("custom")]
    public Custom Custom { get; set; }

    public Defaults()
    {
      // TODO: [TESTS] (Defaults.Defaults) Add tests
      // TODO: [COMPLETE] (Defaults.Defaults) Complete porting
      Custom = new Custom();
    }
  }

  public class Custom
  {
    // TODO: [COMPLETE] (Custom.Custom) Complete porting
  }

  public class Gridpos
  {
    public int h { get; set; }
    public int w { get; set; }
    public int x { get; set; }
    public int y { get; set; }
  }

  public class Legend
  {
    public bool avg { get; set; }
    public bool current { get; set; }
    public bool max { get; set; }
    public bool min { get; set; }
    public bool show { get; set; }
    public bool total { get; set; }
    public bool values { get; set; }
  }

  public class Options
  {
    public bool alertThreshold { get; set; }
  }

  public class Tooltip
  {
    public bool shared { get; set; }
    public int sort { get; set; }
    public string value_type { get; set; }
  }

  public class Xaxis
  {
    public object buckets { get; set; }
    public string mode { get; set; }
    public object name { get; set; }
    public bool show { get; set; }
    public object[] values { get; set; }
  }

  public class Yaxis
  {
    public bool align { get; set; }
    public object alignLevel { get; set; }
  }

  public class Target
  {
    public Groupby[] groupBy { get; set; }
    public string measurement { get; set; }
    public string orderByTime { get; set; }
    public string policy { get; set; }
    public string refId { get; set; }
    public string resultFormat { get; set; }
    public Select[][] select { get; set; }
    public Tag[] tags { get; set; }
  }

  public class Groupby
  {
    public string[] _params { get; set; }
    public string type { get; set; }
  }

  public class Select
  {
    public string[] _params { get; set; }
    public string type { get; set; }
  }

  public class Tag
  {
    public string key { get; set; }
    public string _operator { get; set; }
    public string value { get; set; }
  }

  public class Yax
  {
    public string format { get; set; }
    public object label { get; set; }
    public int logBase { get; set; }
    public object max { get; set; }
    public object min { get; set; }
    public bool show { get; set; }
  }

}
