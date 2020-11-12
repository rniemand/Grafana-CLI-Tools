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

    [JsonProperty("schemaVersion"), JsonPropertyName("schemaVersion")]
    public int SchemaVersion { get; set; }

    [JsonProperty("style"), JsonPropertyName("style")]
    public string Style { get; set; }

    // TODO: [COMPLETE] (Dashboard.tags) Complete porting
    [JsonProperty("tags"), JsonPropertyName("tags")]
    public object[] Tags { get; set; }

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
      Tags = new object[0];
      Templating = new Templating();
      Time = new Time();
      TimePicker = new TimePicker();
      Timezone = string.Empty;
      Title = string.Empty;
      Uid = string.Empty;
      Version = 0;
    }
  }

  public class DashboardAnnotations
  {
    [JsonProperty("list"), JsonPropertyName("list")]
    public DashboardAnnotation[] List { get; set; }
  }

  public class Templating
  {
    // TODO: [COMPLETE] (Templating.list) Complete porting
    [JsonProperty("list"), JsonPropertyName("list")]
    public object[] List { get; set; }

    public Templating()
    {
      // TODO: [TESTS] (Templating.Templating) Add tests
      List = new object[0];
    }
  }

  public class Time
  {
    [JsonProperty("from"), JsonPropertyName("from")]
    public string From { get; set; }

    [JsonProperty("to"), JsonPropertyName("to")]
    public string To { get; set; }

    public Time()
    {
      // TODO: [TESTS] (Time.Time) Add tests
      From = string.Empty;
      To = string.Empty;
    }
  }

  public class TimePicker
  {
    // TODO: [COMPLETE] (Timepicker) Complete porting
  }

  public class Panel
  {
    [JsonProperty("aliasColors"), JsonPropertyName("aliasColors")]
    public AliasColors AliasColors { get; set; }

    [JsonProperty("bars"), JsonPropertyName("bars")]
    public bool Bars { get; set; }

    [JsonProperty("dashLength"), JsonPropertyName("dashLength")]
    public int DashLength { get; set; }

    [JsonProperty("dashes"), JsonPropertyName("dashes")]
    public bool Dashes { get; set; }

    [JsonProperty("datasource"), JsonPropertyName("datasource")]
    public string Datasource { get; set; }

    [JsonProperty("fieldConfig"), JsonPropertyName("fieldConfig")]
    public FieldConfig FieldConfig { get; set; }

    [JsonProperty("fill"), JsonPropertyName("fill")]
    public int Fill { get; set; }

    [JsonProperty("fillGradient"), JsonPropertyName("fillGradient")]
    public int FillGradient { get; set; }

    [JsonProperty("gridPos"), JsonPropertyName("gridPos")]
    public GridPos GridPos { get; set; }

    [JsonProperty("hiddenSeries"), JsonPropertyName("hiddenSeries")]
    public bool HiddenSeries { get; set; }

    [JsonProperty("id"), JsonPropertyName("id")]
    public int Id { get; set; }

    // TODO: [COMPLETE] (Panel.Legend) Test other legend types
    [JsonProperty("legend"), JsonPropertyName("legend")]
    public Legend Legend { get; set; }

    [JsonProperty("lines"), JsonPropertyName("lines")]
    public bool Lines { get; set; }

    [JsonProperty("linewidth"), JsonPropertyName("linewidth")]
    public int LineWidth { get; set; }

    [JsonProperty("nullPointMode"), JsonPropertyName("nullPointMode")]
    public string NullPointMode { get; set; }

    [JsonProperty("options"), JsonPropertyName("options")]
    public Options Options { get; set; }

    [JsonProperty("percentage"), JsonPropertyName("percentage")]
    public bool Percentage { get; set; }

    [JsonProperty("pluginVersion"), JsonPropertyName("pluginVersion")]
    public string PluginVersion { get; set; }

    [JsonProperty("pointradius"), JsonPropertyName("pointradius")]
    public int PointRadius { get; set; }

    [JsonProperty("points"), JsonPropertyName("points")]
    public bool Points { get; set; }

    [JsonProperty("renderer"), JsonPropertyName("renderer")]
    public string Renderer { get; set; }

    // TODO: [COMPLETE] (Panel.seriesOverrides) Complete porting
    [JsonProperty("seriesOverrides"), JsonPropertyName("seriesOverrides")]
    public object[] SeriesOverrides { get; set; }

    [JsonProperty("spaceLength"), JsonPropertyName("spaceLength")]
    public int SpaceLength { get; set; }

    [JsonProperty("stack"), JsonPropertyName("stack")]
    public bool Stack { get; set; }

    [JsonProperty("steppedLine"), JsonPropertyName("steppedLine")]
    public bool SteppedLine { get; set; }

    [JsonProperty("targets"), JsonPropertyName("targets")]
    public Target[] Targets { get; set; }

    // TODO: [COMPLETE] (Panel.thresholds) Complete porting
    [JsonProperty("thresholds"), JsonPropertyName("thresholds")]
    public object[] Thresholds { get; set; }

    // TODO: [COMPLETE] (Panel.timeFrom) Complete porting
    [JsonProperty("timeFrom"), JsonPropertyName("timeFrom")]
    public object TimeFrom { get; set; }

    // TODO: [COMPLETE] (Panel.timeRegions) Complete porting
    [JsonProperty("timeRegions"), JsonPropertyName("timeRegions")]
    public object[] TimeRegions { get; set; }

    // TODO: [COMPLETE] (Panel.Panel) Complete porting
    [JsonProperty("timeShift"), JsonPropertyName("timeShift")]
    public object TimeShift { get; set; }

    [JsonProperty("title"), JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonProperty("tooltip"), JsonPropertyName("tooltip")]
    public Tooltip Tooltip { get; set; }

    [JsonProperty("type"), JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonProperty("xaxis"), JsonPropertyName("xaxis")]
    public XAxis Xaxis { get; set; }

    [JsonProperty("yaxes"), JsonPropertyName("yaxes")]
    public Yax[] Yaxes { get; set; }

    [JsonProperty("yaxis"), JsonPropertyName("yaxis")]
    public YAxis Yaxis { get; set; }

    public Panel()
    {
      // TODO: [TESTS] (Panel.Panel) Add tests
      AliasColors = new AliasColors();
      Bars = false;
      DashLength = 0;
      Dashes = false;
      Datasource = string.Empty;
      FieldConfig = new FieldConfig();
      Fill = 0;
      FillGradient = 0;
      HiddenSeries = false;
      Id = 0;
      Legend = new Legend();
      Lines = false;
      LineWidth = 0;
      NullPointMode = string.Empty;
      Percentage = false;
      PluginVersion = string.Empty;
      PointRadius = 0;
      Points = false;
      Renderer = string.Empty;
      SeriesOverrides = new object[0];
      SpaceLength = 0;
      Stack = false;
      SteppedLine = false;
      Targets = new Target[0];
      Thresholds = new object[0];
      TimeFrom = null;
      TimeRegions = new object[0];
      TimeShift = null;
      Title = string.Empty;
      Tooltip = new Tooltip();
      Type = string.Empty;
      Xaxis = new XAxis();
      Yaxes = new Yax[0];
      Yaxis = new YAxis();
    }
  }

  public class AliasColors
  {
  }

  public class FieldConfig
  {
    [JsonProperty("defaults"), JsonPropertyName("defaults")]
    public Defaults Defaults { get; set; }

    [JsonProperty("overrides"), JsonPropertyName("overrides")]
    public object[] Overrides { get; set; }

    public FieldConfig()
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

  public class GridPos
  {
    [JsonProperty("h"), JsonPropertyName("h")]
    public int H { get; set; }

    [JsonProperty("w"), JsonPropertyName("w")]
    public int W { get; set; }

    [JsonProperty("x"), JsonPropertyName("x")]
    public int X { get; set; }

    [JsonProperty("y"), JsonPropertyName("y")]
    public int Y { get; set; }

    public GridPos()
    {
      // TODO: [TESTS] (Gridpos.Gridpos) Add tests
      H = 0;
      W = 0;
      X = 0;
      Y = 0;
    }
  }

  public class Legend
  {
    [JsonProperty("avg"), JsonPropertyName("avg")]
    public bool Avg { get; set; }

    [JsonProperty("current"), JsonPropertyName("current")]
    public bool Current { get; set; }

    [JsonProperty("max"), JsonPropertyName("max")]
    public bool Max { get; set; }

    [JsonProperty("min"), JsonPropertyName("min")]
    public bool Min { get; set; }

    [JsonProperty("show"), JsonPropertyName("show")]
    public bool Show { get; set; }

    [JsonProperty("total"), JsonPropertyName("total")]
    public bool Total { get; set; }

    [JsonProperty("values"), JsonPropertyName("values")]
    public bool Values { get; set; }

    public Legend()
    {
      // TODO: [TESTS] (Legend.Legend) Add tests
      Avg = false;
      Current = false;
      Max = false;
      Min = false;
      Show = false;
      Total = false;
      Values = false;
    }
  }

  public class Options
  {
    [JsonProperty("alertThreshold"), JsonPropertyName("alertThreshold")]
    public bool AlertThreshold { get; set; }

    public Options()
    {
      // TODO: [TESTS] (Options.Options) Add tests
      // TODO: [COMPLETE] (Options.Options) Complete porting
      AlertThreshold = false;
    }
  }

  public class Tooltip
  {
    [JsonProperty("shared"), JsonPropertyName("shared")]
    public bool Shared { get; set; }

    [JsonProperty("sort"), JsonPropertyName("sort")]
    public int Sort { get; set; }

    [JsonProperty("value_type"), JsonPropertyName("value_type")]
    public string ValueType { get; set; }

    public Tooltip()
    {
      // TODO: [TESTS] (Tooltip.Tooltip) Add tests
      Shared = false;
      Sort = 0;
      ValueType = string.Empty;
    }
  }

  public class XAxis
  {
    // TODO: [COMPLETE] (Xaxis.buckets) Complete porting
    [JsonProperty("buckets"), JsonPropertyName("buckets")]
    public object Buckets { get; set; }

    [JsonProperty("mode"), JsonPropertyName("mode")]
    public string Mode { get; set; }

    [JsonProperty("name"), JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonProperty("show"), JsonPropertyName("show")]
    public bool Show { get; set; }

    // TODO: [COMPLETE] (Xaxis.values) Complete porting
    [JsonProperty("values"), JsonPropertyName("values")]
    public object[] Values { get; set; }

    public XAxis()
    {
      // TODO: [TESTS] (Xaxis.Xaxis) Add tests
      Buckets = null;
      Mode = string.Empty;
      Name = string.Empty;
      Show = false;
      Values = new object[0];
    }
  }

  public class YAxis
  {
    [JsonProperty("align"), JsonPropertyName("align")]
    public bool Align { get; set; }

    // TODO: [COMPLETE] (Yaxis.alignLevel) Complete porting
    [JsonProperty("alignLevel"), JsonPropertyName("alignLevel")]
    public object AlignLevel { get; set; }

    public YAxis()
    {
      // TODO: [TESTS] (Yaxis.Yaxis) Add tests
      Align = false;
      AlignLevel = null;
    }
  }

  public class Target
  {
    [JsonProperty("groupBy"), JsonPropertyName("groupBy")]
    public GroupBy[] GroupBy { get; set; }

    [JsonProperty("measurement"), JsonPropertyName("measurement")]
    public string Measurement { get; set; }

    [JsonProperty("orderByTime"), JsonPropertyName("orderByTime")]
    public string OrderByTime { get; set; }

    [JsonProperty("policy"), JsonPropertyName("policy")]
    public string Policy { get; set; }

    [JsonProperty("query"), JsonPropertyName("query")]
    public string Query { get; set; }

    [JsonProperty("rawQuery"), JsonPropertyName("rawQuery")]
    public bool RawQuery { get; set; }

    [JsonProperty("refId"), JsonPropertyName("refId")]
    public string RefId { get; set; }

    [JsonProperty("resultFormat"), JsonPropertyName("resultFormat")]
    public string ResultFormat { get; set; }

    [JsonProperty("select"), JsonPropertyName("select")]
    public Select[][] Select { get; set; }

    [JsonProperty("tags"), JsonPropertyName("tags")]
    public Tag[] Tags { get; set; }

    public Target()
    {
      // TODO: [TESTS] (Target.Target) Add tests
      GroupBy = new GroupBy[0];
      Measurement = string.Empty;
      OrderByTime = string.Empty;
      Policy = string.Empty;
      Query = string.Empty;
      RawQuery = false;
      RefId = string.Empty;
      ResultFormat = string.Empty;
      Select = new Select[][0];
      Tags = new Tag[0];
    }
  }

  public class GroupBy
  {
    [JsonProperty("params"), JsonPropertyName("params")]
    public string[] Params { get; set; }

    [JsonProperty("type"), JsonPropertyName("type")]
    public string Type { get; set; }

    public GroupBy()
    {
      // TODO: [TESTS] (GroupBy.GroupBy) Add tests
      Params = new string[0];
      Type = string.Empty;
    }
  }

  public class Select
  {
    [JsonProperty("params"), JsonPropertyName("params")]
    public string[] Params { get; set; }

    [JsonProperty("type"), JsonPropertyName("type")]
    public string Type { get; set; }

    public Select()
    {
      // TODO: [TESTS] (Select.Select) Add tests
      Params = new string[0];
      Type = string.Empty;
    }
  }

  public class Tag
  {
    [JsonProperty("key"), JsonPropertyName("key")]
    public string Key { get; set; }

    [JsonProperty("operator"), JsonPropertyName("operator")]
    public string Operator { get; set; }

    [JsonProperty("value"), JsonPropertyName("value")]
    public string Value { get; set; }

    public Tag()
    {
      // TODO: [TESTS] (Tag.Tag) Add tests
      Key = string.Empty;
      Operator = string.Empty;
      Value = string.Empty;
    }
  }

  public class Yax
  {
    [JsonProperty("format"), JsonPropertyName("format")]
    public string Format { get; set; }

    [JsonProperty("label"), JsonPropertyName("label")]
    public string Label { get; set; }

    [JsonProperty("logBase"), JsonPropertyName("logBase")]
    public int LogBase { get; set; }

    // TODO: [COMPLETE] (Yax.max) Complete porting
    [JsonProperty("max"), JsonPropertyName("max")]
    public object Max { get; set; }

    // TODO: [COMPLETE] (Yax.min) Complete porting
    [JsonProperty("min"), JsonPropertyName("min")]
    public object Min { get; set; }

    [JsonProperty("show"), JsonPropertyName("show")]
    public bool Show { get; set; }

    public Yax()
    {
      // TODO: [TESTS] (Yax.Yax) Add tests
      Format = string.Empty;
      Label = string.Empty;
      LogBase = 0;
      Max = null;
      Min = null;
      Show = false;
    }
  }
}
