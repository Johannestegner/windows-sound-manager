#region License etc.

// ///////////////////////////////////////////////////////////////////////////////////
// File Target.cs is part of the "Windows Sound Manager" project.                   //
// Created 2016 09 29 by Johannes Tegnér                                            //
// ///////////////////////////////////////////////////////////////////////////////////
// MIT License
// Copyright (c) 2016 Johannes
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
// Source: https://github.com/Johannestegner/windows-sound-manager                 //
// Issue tracker: https://github.com/Johannestegner/windows-sound-manager/issues   //
// Contact: <Johannes Tegnér> jitedev@gmail.com                                    //
// //////////////////////////////////////////////////////////////////////////////////

#endregion

using System;
using System.Collections.Generic;
using JohannesTegner.WSM.Shared.Interfaces;
using JohannesTegner.WSM.SourceHandler;
using NUnit.Framework;

namespace JohannesTegner.WSM.Tests.SourceHandler
{
  [TestFixture]
  public class SourceTests
  {
    [SetUp]
    public void SetUp()
    {
      this.id = (new Guid()).ToString();
      this.source = new Source("test", this.id, "/icon/path", 10);
    }

    private class TestTarget : ITarget
    {
      #region  Fields and Properties

      public bool Muted { get; set; }
      public int Volume { get; set; }
      public string Icon { get; set; }
      public string Id { get; set; }
      public string Name { get; set; }
      public IReadOnlyList<ISource> Sources { get; set; }

      #endregion

      public bool AddSource(ISource source)
      {
        return true;
      }

      public bool RemoveSource(ISource source)
      {
        return true;
      }
    }

    private Source source;
    private string id;

    [Test]
    public void RemoveTarget()
    {
      ITarget a = new TestTarget();
      ITarget b = new TestTarget();

      this.source.AddTarget(a);
      this.source.AddTarget(b);

      Assert.AreEqual(2, this.source.Targets.Count);
      Assert.IsTrue(this.source.RemoveTarget(a));
      Assert.AreSame(b, this.source.Targets[0]);
      Assert.AreEqual(1, this.source.Targets.Count);
      Assert.IsTrue(this.source.RemoveTarget(b));
      Assert.IsEmpty(this.source.Targets);
    }

    [Test]
    public void TestAddTarget()
    {
      ITarget a = new TestTarget();
      ITarget b = new TestTarget();

      Assert.IsTrue(this.source.AddTarget(a));
      Assert.AreEqual(1, this.source.Targets.Count);
      Assert.IsFalse(this.source.AddTarget(a));
      Assert.AreEqual(1, this.source.Targets.Count);
      Assert.IsTrue(this.source.AddTarget(b));
      Assert.AreEqual(2, this.source.Targets.Count);
    }

    [Test]
    public void TestIcon()
    {
      Assert.AreEqual("/icon/path", this.source.Icon);
      ISource otherSource = new Source("", "", "other/path", 10);
      Assert.AreEqual("other/path", otherSource.Icon);
    }

    [Test]
    public void TestId()
    {
      Assert.AreEqual(this.id, this.source.Id);
    }

    [Test]
    public void TestMuted()
    {
      Assert.False(this.source.Muted);
      this.source.Muted = true;
      Assert.True(this.source.Muted);
      this.source.Muted = false;
      Assert.False(this.source.Muted);
    }

    [Test]
    public void TestName()
    {
      Assert.AreEqual("test", this.source.Name);
    }

    [Test]
    public void TestTargets()
    {
      Assert.IsEmpty(this.source.Targets);
      this.source.AddTarget(new TestTarget());
      Assert.AreEqual(1, this.source.Targets.Count);
      this.source.AddTarget(new TestTarget());
      Assert.AreEqual(2, this.source.Targets.Count);
    }

    [Test]
    public void TestVolume()
    {
      Assert.AreEqual(10, this.source.Volume);
      this.source.Volume += 10;
      Assert.AreEqual(20, this.source.Volume);
      this.source.Volume -= 10;
      Assert.AreEqual(10, this.source.Volume);
      this.source.Volume = 100;
      Assert.AreEqual(100, this.source.Volume);
      this.source.Volume = 200;
      Assert.AreEqual(100, this.source.Volume);
      this.source.Volume = -100;
      Assert.AreEqual(0, this.source.Volume);
    }
  }
}