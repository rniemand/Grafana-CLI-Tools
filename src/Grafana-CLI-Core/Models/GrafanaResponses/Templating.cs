using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace GrafanaCli.Core.Models.GrafanaResponses
{
  public class Templating
  {
    // TODO: [COMPLETE] (Templating.list) Complete porting
    [JsonProperty("list"), JsonPropertyName("list")]
    public TemplateEntry[] List { get; set; }

    public Templating()
    {
      // TODO: [TESTS] (Templating.Templating) Add tests
      List = new TemplateEntry[0];
    }

    public class TemplateEntry
    {
      public string allValue { get; set; }
      public Current current { get; set; }
      public object error { get; set; }
      public int hide { get; set; }
      public bool includeAll { get; set; }
      public string label { get; set; }
      public bool multi { get; set; }
      public string name { get; set; }
      public Option[] options { get; set; }
      public string query { get; set; }
      public bool skipUrlSync { get; set; }
      public string type { get; set; }
      public string datasource { get; set; }
      public int refresh { get; set; }
      public string regex { get; set; }
      public int sort { get; set; }
      public string tagValuesQuery { get; set; }
      public object[] tags { get; set; }
      public string tagsQuery { get; set; }
      public bool useTags { get; set; }
    }

    public class Current
    {
      public bool selected { get; set; }
      public object text { get; set; }
      public object value { get; set; }
    }

    public class Option
    {
      public bool selected { get; set; }
      public string text { get; set; }
      public string value { get; set; }
    }

  }
}