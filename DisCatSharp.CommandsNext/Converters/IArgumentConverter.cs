// This file is part of the DisCatSharp project, based off DSharpPlus.
//
// Copyright (c) 2021-2023 AITSYS
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

using System.Threading.Tasks;

using DisCatSharp.Entities;

namespace DisCatSharp.CommandsNext.Converters;

/// <summary>
/// Argument converter abstract.
/// </summary>
public interface IArgumentConverter
{ }

/// <summary>
/// Represents a converter for specific argument type.
/// </summary>
/// <typeparam name="T">Type for which the converter is to be registered.</typeparam>
public interface IArgumentConverter<T> : IArgumentConverter
{
	/// <summary>
	/// Converts the raw value into the specified type.
	/// </summary>
	/// <param name="value">Value to convert.</param>
	/// <param name="ctx">Context in which the value will be converted.</param>
	/// <returns>A structure containing information whether the value was converted, and, if so, the converted value.</returns>
	Task<Optional<T>> ConvertAsync(string value, CommandContext ctx);
}
