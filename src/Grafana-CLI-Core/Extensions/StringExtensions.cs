namespace GrafanaCli.Core.Extensions
{
  public static class StringExtensions
  {
    public static string AppendIfMissing(this string source, string append)
    {
      // TODO: [TESTS] (StringExtensions.AppendIfMissing) Add tests

      if (string.IsNullOrWhiteSpace(append))
        return source;

      return source.EndsWith(append) ? source : $"{source}{append}";
    }
  }
}
