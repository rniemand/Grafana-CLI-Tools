using System.IO;

namespace GrafanaCli.Core.Abstractions
{
  public interface IFile
  {
    bool Exists(string path);
  }

  public class FileAbstraction : IFile
  {
    public bool Exists(string path) => File.Exists(path);
  }
}
