using Newtonsoft.Json;

namespace GrafanaCli.Core.Abstractions
{
  public interface IJsonAbstraction
  {
    T DeserializeObject<T>(string value);
  }

  public class JsonAbstraction : IJsonAbstraction
  {
    public T DeserializeObject<T>(string value)
    {
      return JsonConvert.DeserializeObject<T>(value);
    }
  }
}
