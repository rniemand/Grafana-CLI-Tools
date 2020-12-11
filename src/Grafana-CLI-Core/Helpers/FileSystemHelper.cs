using System;
using System.IO;
using Rn.NetCore.Common.Abstractions;
using Rn.NetCore.Common.Helpers;
using Rn.NetCore.Common.Logging;

namespace GrafanaCli.Core.Helpers
{
  public interface IFileSystemHelper
  {
    void SaveJsonFile(string path, string json, bool format = false);
  }

  public class FileSystemHelper : IFileSystemHelper
  {
    private readonly ILoggerAdapter<FileSystemHelper> _logger;
    private readonly IDirectoryAbstraction _directory;
    private readonly IFileAbstraction _file;
    private readonly IJsonHelper _jsonHelper;
    private readonly IPathAbstraction _path;

    public FileSystemHelper(
      ILoggerAdapter<FileSystemHelper> logger,
      IDirectoryAbstraction directory,
      IFileAbstraction file,
      IJsonHelper jsonHelper,
      IPathAbstraction path)
    {
      _logger = logger;
      _directory = directory;
      _file = file;
      _jsonHelper = jsonHelper;
      _path = path;
    }

    public void SaveJsonFile(string path, string json, bool format = false)
    {
      // TODO: [TESTS] (FileSystemHelper.SaveJsonFile) Add tests
      if (format)
      {
        if (!_jsonHelper.TryDeserializeObject(json, out object parsed))
          throw new Exception("Invalid JSON");

        json = _jsonHelper.SerializeObject(parsed, true);
      }

      if (_file.Exists(path))
        _file.Delete(path);

      var directoryPath = _path.GetDirectoryName(path);
      if (!_directory.Exists(directoryPath))
        _directory.CreateDirectory(directoryPath);

      _file.WriteAllText(path, json);
    }
  }
}
