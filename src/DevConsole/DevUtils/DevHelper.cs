using System;

namespace GrafanaCli.DevConsole.DevUtils
{
  public static class DevHelper
  {
    public static Random Random = new Random(DateTime.UtcNow.Millisecond);
  }
}