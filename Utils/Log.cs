#region License etc.

// ///////////////////////////////////////////////////////////////////////////////////
// File Log.cs is part of the "Windows Sound Manager" project.
// Created 2016 09 29 by Johannes Tegnér
// ///////////////////////////////////////////////////////////////////////////////////
// MIT License
// Copyright (c) 2016 Johannes Tegnér
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.
// //////////////////////////////////////////////////////////////////////////////////
// Source: https://github.com/Johannestegner/windows-sound-manager
// Issue tracker: https://github.com/Johannestegner/windows-sound-manager/issues
// Contact: <Johannes Tegnér> jitedev@gmail.com
// //////////////////////////////////////////////////////////////////////////////////

#endregion

using JohannesTegner.Utils.Contracts;

namespace JohannesTegner.Utils
{
  public enum LogLevels
  {
    Error = 5,
    Warning = 4,
    Trace = 3,
    Notice = 2,
    Debug = 1,
    All = 0
  }

  public static class Log
  {
    #region  Fields and Properties

    /// <summary>
    ///   Format used when printing Debug texts.
    /// </summary>
    private const string DebugFormat = "Debug ({0}): {1}";

    /// <summary>
    ///   Format used when printing Error texts.
    /// </summary>
    private const string ErrorFormat = "Error ({0}): {1}";

    /// <summary>
    ///   Format used when printing Warning texts.
    /// </summary>
    private const string WarningFormat = "Warning ({0}): {1}";

    /// <summary>
    ///   Format used when printing Notice texts.
    /// </summary>
    private const string NoticeFormat = "Notice ({0}): {1}";

    /// <summary>
    ///   Format used when printing Trace texts.
    /// </summary>
    private const string TraceFormat = "Trace ({0}): {1}";


    /// <summary>
    ///   Current log level.
    /// </summary>
    public static LogLevels LogLevel { get; set; }

    /// <summary>
    ///   Get the underlying stream writer.
    /// </summary>
    internal static IStreamWriter Writer { private get; set; }

    /// <summary>
    ///   Clock to use instead of the default clock.
    /// </summary>
    internal static Clock StaticClock { get; set; }

    #endregion

    static Log()
    {
      Writer = null;
#if DEBUG
      LogLevel = LogLevels.Debug;
#else
      LogLevel = LogLevels.Error; // If not a debug build, only log errors by default.
#endif
    }

    private static void InitWriter(string path)
    {
      Writer = new StreamWriter(path);
    }

    /// <summary>
    ///   Write a debug message to the stream.
    /// </summary>
    /// <param name="str">Message</param>
    public static void Debug(string str)
    {
      if (LogLevel > LogLevels.Debug) return;
      WriteToFile(string.Format(DebugFormat, GetTimeString(), str));
    }

    public static void Trace(string str)
    {
      if (LogLevel > LogLevels.Trace) return;
      WriteToFile(string.Format(TraceFormat, GetTimeString(), str));
    }

    public static void Error(string str)
    {
      if (LogLevel > LogLevels.Error) return;
      WriteToFile(string.Format(ErrorFormat, GetTimeString(), str));
    }

    public static void Warning(string str)
    {
      if (LogLevel > LogLevels.Warning) return;
      WriteToFile(string.Format(WarningFormat, GetTimeString(), str));
    }

    public static void Notice(string str)
    {
      if (LogLevel > LogLevels.Notice) return;
      WriteToFile(string.Format(NoticeFormat, GetTimeString(), str));
    }

    private static void WriteToFile(string message)
    {
      System.Diagnostics.Debug.WriteLine(message);

      if (Writer == null)
      {
        InitWriter("out.log");
      }

      // ReSharper disable once PossibleNullReferenceException
      Writer.WriteLine(message);
    }

    private static string GetTimeString()
    {
      return StaticClock == null ? Clock.Now.ToString("u") : StaticClock.ToString("u");
    }
  }
}