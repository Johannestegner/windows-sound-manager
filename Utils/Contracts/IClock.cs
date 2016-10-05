#region License etc.

// ///////////////////////////////////////////////////////////////////////////////////
// File IClock.cs is part of the "Windows Sound Manager" project.
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

namespace JohannesTegner.Utils.Contracts
{
  public interface IClock : IComparable
  {
    /// <summary>
    ///   Converts the clock object to windows file time.
    /// </summary>
    /// <returns></returns>
    long ToFileTime();

    /// <summary>
    ///   Converts the clock object to windows file time.
    /// </summary>
    /// <returns></returns>
    long ToFileTimeUtc();

    /// <summary>
    ///   Converts the clock object to its equivalent long date string representation.
    /// </summary>
    /// <returns>Date string.</returns>
    string ToLongDateString();

    /// <summary>
    ///   Converts the clock object to its equivalent long time string representation.
    /// </summary>
    /// <returns>Time string.</returns>
    string ToLongTimeString();

    /// <summary>
    ///   Converts the clock object to its equivalent short date string representation.
    /// </summary>
    /// <returns>Date string.</returns>
    string ToShortDateString();

    /// <summary>
    ///   Converts the clock object to its equivalent short time string representation.
    /// </summary>
    /// <returns>Time string</returns>
    string ToShortTimeString();

    /// <summary>
    ///   Converts the clock object to its equivalent string representation using
    ///   the formatting conventions of the current culture.
    /// </summary>
    /// <returns>Formatted date time string.</returns>
    string ToString();

    /// <summary>
    ///   Converts the clock object to its equivalent string representation using
    ///   the specified culture-specific format information.
    /// </summary>
    /// <param name="formatProvider">Culture specific format provider.</param>
    /// <returns>Formatted date time string.</returns>
    string ToString(IFormatProvider formatProvider);

    /// <summary>
    ///   Converts the clock object to its equivalent string representation using
    ///   the specified format and the formatting conventions of the current culture.
    /// </summary>
    /// <param name="format">Format to use.</param>
    /// <returns>Formatted date time string.</returns>
    string ToString(string format);

    /// <summary>
    ///   Converts the clock object to its equivalent string representation using
    ///   the specified format and the specified culture-specific format information.
    /// </summary>
    /// <param name="format">Format to use.</param>
    /// <param name="formatProvider">Culture specific format provider.</param>
    /// <returns></returns>
    string ToString(string format, IFormatProvider formatProvider);
  }
}