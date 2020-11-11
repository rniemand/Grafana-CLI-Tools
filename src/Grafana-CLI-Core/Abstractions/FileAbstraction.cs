using System.IO;

namespace GrafanaCli.Core.Abstractions
{
  public interface IFile
  {
    bool Exists(string path);
    string ReadAllText(string path);
  }

  public class FileAbstraction : IFile
  {
    public bool Exists(string path) => File.Exists(path);
    public string ReadAllText(string path) => File.ReadAllText(path);
  }
}
