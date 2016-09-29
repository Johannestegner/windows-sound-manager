#region License etc.

// File ITarget.cs is part of the "Windows Sound Manager" project.
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

using System.Collections.Generic;

namespace JohannesTegner.WSM.Shared.Interfaces
{
  public interface ITarget : IMuteable, IVolumeChangeable
  {
    #region  Fields and Properties

    /// <summary>
    ///   Icon path for target.
    /// </summary>
    string Icon
    {
      get;
    }

    /// <summary>
    ///   Identifier of the target.
    /// </summary>
    string Id
    {
      get;
    }

    /// <summary>
    ///   Target device name.
    /// </summary>
    string Name
    {
      get;
    }

    /// <summary>
    ///   Get all current sources as read only list.
    /// </summary>
    IReadOnlyList<ISource> Sources
    {
      get;
    }

    #endregion

    /// <summary>
    ///   Set source to stream to target.
    /// </summary>
    /// <param name="source">Source to stream.</param>
    /// <returns>Result.</returns>
    bool AddSource(ISource source);

    /// <summary>
    ///   Stop streaming a source from target.
    /// </summary>
    /// <param name="source">Source to stop stream.</param>
    /// <returns>Result.</returns>
    bool RemoveSource(ISource source);
  }
}