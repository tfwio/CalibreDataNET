/* oOo * 11/14/2007 : 10:22 PM */
using System;

namespace System
{
  public class XLog
  {
    public enum OutputMode
    {
      Debugger,
      Console,
      XLog
    }

    public static bool IsConsoleEnabled = false;

    public static event EventHandler<XLogEventArgs> XLogEvent;

    private static void OnXLogEvent()
    {
      if (XLog.XLogEvent != null)
      {
        XLog.XLogEvent(null, new XLogEventArgs(true));
      }
    }

    private static void OnXLogEvent(ConsoleColor Colour, string title, string format, params object[] args)
    {
      if (XLog.XLogEvent != null)
      {
        XLog.XLogEvent(null, new XLogEventArgs(Colour, title, format, args));
      }
    }

    private static void OnXLogEvent(ConsoleColor Colour, string title, string titleFilter, string format, params object[] args)
    {
      if (XLog.XLogEvent != null)
      {
        XLog.XLogEvent(null, new XLogEventArgs(Colour, title, titleFilter, format, args));
      }
    }

    public static void WarnError(string filter, params object[] args)
    {
      XLog.Write(ConsoleColor.Red, "{0}", "Error", filter, args);
    }

    public static void Warn(string title, string filter, params object[] args)
    {
      XLog.Write(ConsoleColor.Red, "{0}", title, filter, args);
    }

    public static void Write(ConsoleColor titleFg, string title, string filter, params object[] args)
    {
      XLog.Write(titleFg, "{0}", title, filter, args);
    }

    public static void Clear()
    {
      try
      {
        if (XLog.IsConsoleEnabled)
        {
          Console.Clear();
        }
      }
      catch
      {
        XLog.IsConsoleEnabled = false;
      }
      XLog.OnXLogEvent();
    }

    public static void WriteLine()
    {
      XLog.WriteLine("\n", new object[0]);
    }

    public static void WriteLine(string filter, params object[] args)
    {
      XLog.Write(filter + "\n", args);
    }

    public static void Write(string filter, params object[] args)
    {
      XLog.Write(ConsoleColor.White, "", filter, args);
    }

    public static void Write(ConsoleColor titleFg, string titleFilter, string title, string filter, params object[] args)
    {
      ConsoleColor fg = Console.ForegroundColor;
      try
      {
        if (XLog.IsConsoleEnabled)
        {
          Console.ForegroundColor = titleFg;
          Console.Write(titleFilter, title);
          Console.ForegroundColor = fg;
          Console.Write(filter, args);
        }
      }
      catch
      {
        XLog.IsConsoleEnabled = false;
      }
      XLog.OnXLogEvent(titleFg, title, titleFilter, filter, args);
    }

    public static void WriteY(string title, string filter, params object[] args)
    {
      XLog.Write(ConsoleColor.Yellow, "{0}", title, filter, args);
    }

    public static void WriteDY(string title, string filter, params object[] args)
    {
      XLog.Write(ConsoleColor.DarkYellow, "{0}", title, filter, args);
    }

    public static void WriteC(string title, string filter, params object[] args)
    {
      XLog.Write(ConsoleColor.Cyan, "{0}", title, filter, args);
    }

    public static void WriteDC(string title, string filter, params object[] args)
    {
      XLog.Write(ConsoleColor.DarkCyan, "{0}", title, filter, args);
    }

    public static void WriteM(string title, string filter, params object[] args)
    {
      XLog.Write(ConsoleColor.Magenta, "{0}", title, filter, args);
    }

    public static void WriteDM(string title, string filter, params object[] args)
    {
      XLog.Write(ConsoleColor.DarkMagenta, "{0}", title, filter, args);
    }

    public static void WriteG(string title, string filter, params object[] args)
    {
      XLog.Write(ConsoleColor.Green, "{0}", title, filter, args);
    }
  }
}
