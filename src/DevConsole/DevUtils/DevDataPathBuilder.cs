using System;
using Rn.NetCore.Common.Extensions;

namespace GrafanaCli.DevConsole.DevUtils
{
  public class DevDataPathBuilder
  {
    private readonly string _baseDirectory;
    private readonly string _devDataDirectory;
    private readonly string _responseDirectory;

    public DevDataPathBuilder()
    {
      // TODO: [TESTS] (DevDataPathBuilder.DevDataPathBuilder) Add tests

      _baseDirectory = Environment.CurrentDirectory.AppendIfMissing("\\");
      _devDataDirectory = $"{_baseDirectory}DevData\\";
      _responseDirectory = $"{_devDataDirectory}Responses\\";
    }

    public string ResponseFile(string fileName, string extension = ".json")
    {
      // TODO: [TESTS] (DevDataPathBuilder.ResponseFile) Add tests
      if (!fileName.EndsWith(extension))
        fileName = $"{fileName}{extension}";

      return $"{_responseDirectory}{fileName}";
    }
  }
}
