#region License etc.

// File TargetContainer.cs is part of the "Windows Sound Manager" project.
// Created 2016 09 27 by Johannes Tegnér
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

using System.Collections.Generic;
using JohannesTegner.WSM.Shared.Interfaces;

namespace JohannesTegner.WSM.TargetHandler
{
  public class TargetContainer
  {
    #region  Fields and Properties

    private readonly List<Target> targets;

    public IReadOnlyList<ITarget> Targets
    {
      get
      {
        return this.targets;
      }
    }

    #endregion

    public TargetContainer()
    {
      this.targets = new List<Target>();
    }
  }
}