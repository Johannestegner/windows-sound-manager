#region License etc.

// ///////////////////////////////////////////////////////////////////////////////////
// File TargetTests.cs is part of the "Windows Sound Manager" project.
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

using System.Collections.Generic;
using JohannesTegner.WSM.Shared.Interfaces;
using JohannesTegner.WSM.TargetHandler;
using NUnit.Framework;

namespace JohannesTegner.WSM.Tests.TargetHandler
{
  internal class TestSource : ISource
  {
    #region  Fields and Properties

    public bool Muted { get; set; }
    public int Volume { get; set; }
    public string Icon { get; set; }
    public string Id { get; set; }
    public string Name { get; set; }
    public IReadOnlyList<ITarget> Targets { get; set; }

    #endregion

    public bool AddTarget(ITarget target)
    {
      return true;
    }

    public bool RemoveTarget(ITarget target)
    {
      return true;
    }
  }

  [TestFixture]
  public class TargetTests
  {
    [SetUp]
    public void SetUp()
    {
      this.target = new Target("test", "icon/path", 10, TestGuid);
    }

    private Target target;
    private const string TestGuid = "91895597-b64f-4570-be71-42327963a089";

    [Test]
    public void TestAddSource()
    {
      ISource a = new TestSource();
      ISource b = new TestSource();

      Assert.IsTrue(this.target.AddSource(a));
      Assert.AreEqual(1, this.target.Sources.Count);
      Assert.IsFalse(this.target.AddSource(a));
      Assert.AreEqual(1, this.target.Sources.Count);
      Assert.IsTrue(this.target.AddSource(b));
      Assert.AreEqual(2, this.target.Sources.Count);
    }

    [Test]
    public void TestIcon()
    {
      Assert.AreEqual("icon/path", this.target.Icon);
    }

    [Test]
    public void TestId()
    {
      Assert.AreEqual(TestGuid, this.target.Id);
    }

    [Test]
    public void TestMuted()
    {
      Assert.IsFalse(this.target.Muted);
      this.target.Muted = true;
      Assert.IsTrue(this.target.Muted);
    }

    [Test]
    public void TestName()
    {
      Assert.AreEqual("test", this.target.Name);
    }

    [Test]
    public void TestRemoveSource()
    {
      ISource a = new TestSource();
      ISource b = new TestSource();

      this.target.AddSource(a);
      this.target.AddSource(b);

      Assert.AreEqual(2, this.target.Sources.Count);
      Assert.IsTrue(this.target.RemoveSource(a));
      Assert.AreSame(b, this.target.Sources[0]);
      Assert.AreEqual(1, this.target.Sources.Count);
      Assert.IsTrue(this.target.RemoveSource(b));
      Assert.IsEmpty(this.target.Sources);
    }

    [Test]
    public void TestSources()
    {
      Assert.IsEmpty(this.target.Sources);
      this.target.AddSource(new TestSource());
      Assert.AreEqual(1, this.target.Sources.Count);
      this.target.AddSource(new TestSource());
      Assert.AreEqual(2, this.target.Sources.Count);
    }

    [Test]
    public void TestVolume()
    {
      Assert.AreEqual(10, this.target.Volume);
      this.target.Volume += 10;
      Assert.AreEqual(20, this.target.Volume);
      this.target.Volume -= 10;
      Assert.AreEqual(10, this.target.Volume);
      this.target.Volume = 100;
      Assert.AreEqual(100, this.target.Volume);
      this.target.Volume = 200;
      Assert.AreEqual(100, this.target.Volume);
      this.target.Volume = -100;
      Assert.AreEqual(0, this.target.Volume);
    }
  }
}