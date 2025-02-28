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

using System;

namespace DisCatSharp.ApplicationCommands.Attributes;

/// <summary>
/// Sets a IChoiceProvider for a command options. ChoiceProviders can be used to provide
/// DiscordApplicationCommandOptionChoice from external sources such as a database.
/// </summary>
[AttributeUsage(AttributeTargets.Parameter, AllowMultiple = true)]
public class ChoiceProviderAttribute : Attribute
{

	/// <summary>
	/// The type of the provider.
	/// </summary>
	public Type ProviderType { get; }

	/// <summary>
	/// Adds a choice provider to this command.
	/// </summary>
	/// <param name="providerType">The type of the provider.</param>
	public ChoiceProviderAttribute(Type providerType)
	{
		this.ProviderType = providerType;
	}
}
