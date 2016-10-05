#region License etc.

// ///////////////////////////////////////////////////////////////////////////////////
// File Clock.cs is part of the "Windows Sound Manager" project.
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

namespace JohannesTegner.Utils
{
  public class Clock : IComparable
  {
    #region  Fields and Properties

    private static Clock staticClock = null;

    private DateTime dateTime;

    public static Clock Now
    {
      get
      {
        return new Clock(DateTime.Now);
      }
    }

    #endregion

    private Clock(DateTime init)
    {
      this.dateTime = init;
      if (staticClock != null)
      {
        this.dateTime = staticClock.dateTime;
      }
    }

    internal virtual void SetStaticClock(Clock dt)
    {
      staticClock = dt;
    }


    /// <inheritdoc />
    public int CompareTo(object obj)
    {
      return this.dateTime.CompareTo(obj);
    }

    /// <inheritdoc />
    public long ToFileTime()
    {
      return this.dateTime.ToFileTime();
    }

    /// <inheritdoc />
    public long ToFileTimeUtc()
    {
      return this.dateTime.ToFileTimeUtc();
    }

    /// <inheritdoc />
    public string ToLongDateString()
    {
      return this.dateTime.ToLongDateString();
    }

    /// <inheritdoc />
    public string ToLongTimeString()
    {
      return this.dateTime.ToLongTimeString();
    }

    /// <inheritdoc />
    public string ToShortDateString()
    {
      return this.dateTime.ToShortDateString();
    }

    /// <inheritdoc />
    public string ToShortTimeString()
    {
      return this.dateTime.ToShortTimeString();
    }

    /// <inheritdoc />
    public string ToString(IFormatProvider formatProvider)
    {
      return this.dateTime.ToString(formatProvider);
    }

    /// <inheritdoc />
    public string ToString(string format)
    {
      return this.dateTime.ToString(format);
    }

    /// <inheritdoc />
    public string ToString(string format, IFormatProvider formatProvider)
    {
      return this.dateTime.ToString(format, formatProvider);
    }
  }
}