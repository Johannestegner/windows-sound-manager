#region License etc.

// File Target.cs is part of the "Windows Sound Manager" project.
// Created 2016 09 28 by Johannes Tegnér
// 
// #region License
// MIT License
// 
// Copyright (c) 2016 Johannes
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.
// #endregion
// 
// Source: https://github.com/Johannestegner/windows-sound-manager
// Issue tracker: https://github.com/Johannestegner/windows-sound-manager/issues
// Contact: <Johannes Tegnér> jitedev@gmail.com

#endregion

using System;
using System.Collections.Generic;
using JohannesTegner.WSM.Shared.Interfaces;

namespace JohannesTegner.WSM.TargetHandler
{
  public class Target : ITarget
  {
    #region  Fields and Properties

    private readonly List<ISource> sources = new List<ISource>();
    private int volume = 0;

    /// <inheritdoc />
    public string Icon
    {
      get;
      private set;
    }

    /// <inheritdoc />
    public string Id
    {
      get;
      private set;
    }

    /// <inheritdoc />
    public string Name
    {
      get;
      private set;
    }

    /// <inheritdoc />
    public int Volume
    {
      get
      {
        return this.volume;
      }
      set
      {
        this.volume = Math.Max(0, Math.Min(100, value));
      }
    }

    /// <inheritdoc />
    public IReadOnlyList<ISource> Sources
    {
      get
      {
        return this.sources.AsReadOnly();
      }
    }

    /// <inheritdoc />
    public bool Mute
    {
      get;
      set;
    }

    #endregion

    public Target(string name, string icon, int volume, string id)
    {
      this.Volume = volume;
      this.Icon = icon;
      this.Id = id;
      this.Name = name;
    }

    /// <inheritdoc />
    public bool AddSource(ISource source)
    {
      if (this.sources.Contains(source))
      {
        return false;
      }

      this.sources.Add(source);
      return true;
    }

    /// <inheritdoc />
    public bool RemoveSource(ISource source)
    {
      return !this.sources.Contains(source) || this.sources.Remove(source);
    }
  }
}