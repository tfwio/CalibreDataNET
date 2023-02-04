/* oOo * 11/14/2007 : 10:22 PM */
using System;

namespace System
{
  public class XLogEventArgs : EventArgs
  {
    public bool ClearConsole = false;

    public static string Separator = string.Empty;

    public ConsoleColor Colour { get; set; }

    public string Title { get; set; }

    public string TitleFilter { get; set; }

    public string Format { get; set; }

    public object[] Arguments { get; set; }

    public override string ToString()
    {
      string otitle = string.Format(this.TitleFilter ?? "{0}", this.Title ?? string.Empty);
      string omsg = string.Format(this.Format ?? "{0}", this.Arguments ?? (object)string.Empty);
      return otitle + XLogEventArgs.Separator + omsg;
    }

    public XLogEventArgs(bool clear)
    {
      this.ClearConsole = true;
    }

    public XLogEventArgs(ConsoleColor Colour, string title, string titleFilter, string format, params object[] args) : this(Colour, title, format, args)
    {
      this.TitleFilter = titleFilter;
    }

    public XLogEventArgs(ConsoleColor Colour, string title, string format, params object[] args)
    {
      this.Colour = Colour;
      this.Title = title;
      this.Format = format;
      this.Arguments = args;
    }
  }
}
