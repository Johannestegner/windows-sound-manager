#region License etc.

// ///////////////////////////////////////////////////////////////////////////////////
// File LogTests.cs is part of the "Windows Sound Manager" project.
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

using System;
using JohannesTegner.Utils;
using JohannesTegner.WSM.Tests.Mocks;
using NUnit.Framework;

namespace JohannesTegner.WSM.Tests.Utils
{
  [TestFixture]
  public class LogTests
  {
    [SetUp]
    public void SetUp()
    {
      this.writer = new TestLoggerStringWriter();
      Log.Writer = this.writer;
      Log.StaticClock = Clock.Now;
      this.curTimeString = Log.StaticClock.ToString("u");
      Log.LogLevel = LogLevels.All;
    }

    [TearDown]
    public void TearDown()
    {
      Log.StaticClock = null;
    }

    private TestLoggerStringWriter writer;
    private string curTimeString;

    [Test]
    public void TestDebug()
    {
      Assert.IsEmpty(this.writer.Value);
      Log.Debug("Test 123");
      Assert.AreEqual(
        string.Format("Debug ({0}): {1}{2}", this.curTimeString, "Test 123", Environment.NewLine),
        this.writer.Value
      );
    }

    [Test]
    public void TestError()
    {
      Assert.IsEmpty(this.writer.Value);
      Log.Error("Test 123");
      Assert.AreEqual(
        string.Format("Error ({0}): {1}{2}", this.curTimeString, "Test 123", Environment.NewLine),
        this.writer.Value
      );
    }

    [Test]
    public void TestLogLevelAll()
    {
    }

    [Test]
    public void TestLogLevelDebug()
    {
      Assert.IsEmpty(this.writer.Value);
      Log.LogLevel = LogLevels.Debug;

      Log.Debug("Debug test.");
      Log.Notice("Notice test.");
      Log.Trace("Trace test.");
      Log.Warning("Warning test.");
      Log.Error("Error test.");

      string[] split = this.writer.Value.Replace(Environment.NewLine, "\n").Split('\n');

      Assert.AreEqual(6, split.Length); // Last one is empty line

      Assert.AreEqual(
        string.Format("Debug ({0}): {1}", this.curTimeString, "Debug test."),
        split[0]
      );

      Assert.AreEqual(
        string.Format("Notice ({0}): {1}", this.curTimeString, "Notice test."),
        split[1]
      );

      Assert.AreEqual(
        string.Format("Trace ({0}): {1}", this.curTimeString, "Trace test."),
        split[2]
      );

      Assert.AreEqual(
        string.Format("Warning ({0}): {1}", this.curTimeString, "Warning test."),
        split[3]
      );

      Assert.AreEqual(
        string.Format("Error ({0}): {1}", this.curTimeString, "Error test."),
        split[4]
      );
    }

    [Test]
    public void TestLogLevelError()
    {
      Assert.IsEmpty(this.writer.Value);
      Log.LogLevel = LogLevels.Error;

      Log.Debug("Debug test.");
      Log.Notice("Notice test.");
      Log.Trace("Trace test.");
      Log.Warning("Warning test.");
      Log.Error("Error test.");

      string[] split = this.writer.Value.Replace(Environment.NewLine, "\n").Split('\n');

      Assert.AreEqual(2, split.Length); // Last one is empty line

      Assert.AreEqual(
        string.Format("Error ({0}): {1}", this.curTimeString, "Error test."),
        split[0]
      );
    }

    [Test]
    public void TestLogLevelNotice()
    {
      Assert.IsEmpty(this.writer.Value);
      Log.LogLevel = LogLevels.Notice;

      Log.Debug("Debug test.");
      Log.Notice("Notice test.");
      Log.Trace("Trace test.");
      Log.Warning("Warning test.");
      Log.Error("Error test.");

      string[] split = this.writer.Value.Replace(Environment.NewLine, "\n").Split('\n');

      Assert.AreEqual(5, split.Length); // Last one is empty line

      Assert.AreEqual(
        string.Format("Notice ({0}): {1}", this.curTimeString, "Notice test."),
        split[0]
      );

      Assert.AreEqual(
        string.Format("Trace ({0}): {1}", this.curTimeString, "Trace test."),
        split[1]
      );

      Assert.AreEqual(
        string.Format("Warning ({0}): {1}", this.curTimeString, "Warning test."),
        split[2]
      );

      Assert.AreEqual(
        string.Format("Error ({0}): {1}", this.curTimeString, "Error test."),
        split[3]
      );
    }

    [Test]
    public void TestLogLevelTrace()
    {
      Assert.IsEmpty(this.writer.Value);
      Log.LogLevel = LogLevels.Trace;

      Log.Debug("Debug test.");
      Log.Notice("Notice test.");
      Log.Trace("Trace test.");
      Log.Warning("Warning test.");
      Log.Error("Error test.");

      string[] split = this.writer.Value.Replace(Environment.NewLine, "\n").Split('\n');

      Assert.AreEqual(4, split.Length); // Last one is empty line

      Assert.AreEqual(
        string.Format("Trace ({0}): {1}", this.curTimeString, "Trace test."),
        split[0]
      );

      Assert.AreEqual(
        string.Format("Warning ({0}): {1}", this.curTimeString, "Warning test."),
        split[1]
      );

      Assert.AreEqual(
        string.Format("Error ({0}): {1}", this.curTimeString, "Error test."),
        split[2]
      );
    }

    [Test]
    public void TestLogLevelWarning()
    {
      Assert.IsEmpty(this.writer.Value);
      Log.LogLevel = LogLevels.Warning;

      Log.Debug("Debug test.");
      Log.Notice("Notice test.");
      Log.Trace("Trace test.");
      Log.Warning("Warning test.");
      Log.Error("Error test.");

      string[] split = this.writer.Value.Replace(Environment.NewLine, "\n").Split('\n');

      Assert.AreEqual(3, split.Length); // Last one is empty line

      Assert.AreEqual(
        string.Format("Warning ({0}): {1}", this.curTimeString, "Warning test."),
        split[0]
      );

      Assert.AreEqual(
        string.Format("Error ({0}): {1}", this.curTimeString, "Error test."),
        split[1]
      );
    }

    [Test]
    public void TestNotice()
    {
      Assert.IsEmpty(this.writer.Value);
      Log.Notice("Test 123");
      Assert.AreEqual(
        string.Format("Notice ({0}): {1}{2}", this.curTimeString, "Test 123", Environment.NewLine),
        this.writer.Value
      );
    }

    [Test]
    public void TestTrace()
    {
      Assert.IsEmpty(this.writer.Value);
      Log.Trace("Test 123");
      Assert.AreEqual(
        string.Format("Trace ({0}): {1}{2}", this.curTimeString, "Test 123", Environment.NewLine),
        this.writer.Value
      );
    }

    [Test]
    public void TestWarning()
    {
      Assert.IsEmpty(this.writer.Value);
      Log.Warning("Test 123");
      Assert.AreEqual(
        string.Format("Warning ({0}): {1}{2}", this.curTimeString, "Test 123", Environment.NewLine),
        this.writer.Value
      );
    }
  }
}