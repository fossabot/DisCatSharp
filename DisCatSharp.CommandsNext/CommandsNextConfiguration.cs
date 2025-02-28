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
using System.Collections.Generic;
using System.Threading.Tasks;

using DisCatSharp.CommandsNext.Attributes;
using DisCatSharp.Entities;

using Microsoft.Extensions.DependencyInjection;

namespace DisCatSharp.CommandsNext;

/// <summary>
/// <para>Represents a delegate for a function that takes a message, and returns the position of the start of command invocation in the message. It has to return -1 if prefix is not present.</para>
/// <para>
/// It is recommended that helper methods <see cref="CommandsNextUtilities.GetStringPrefixLength(DiscordMessage, string, StringComparison)"/> and <see cref="CommandsNextUtilities.GetMentionPrefixLength(DiscordMessage, DiscordUser)"/>
/// be used internally for checking. Their output can be passed through.
/// </para>
/// </summary>
/// <param name="msg">Message to check for prefix.</param>
/// <returns>Position of the command invocation or -1 if not present.</returns>
public delegate Task<int> PrefixResolverDelegate(DiscordMessage msg);

/// <summary>
/// Represents a configuration for <see cref="CommandsNextExtension"/>.
/// </summary>
public sealed class CommandsNextConfiguration
{
	/// <summary>
	/// <para>Sets the string prefixes used for commands.</para>
	/// <para>Defaults to no value (disabled).</para>
	/// </summary>
	public List<string> StringPrefixes { internal get; set; }

	/// <summary>
	/// <para>Sets the custom prefix resolver used for commands.</para>
	/// <para>Defaults to none (disabled).</para>
	/// </summary>
	public PrefixResolverDelegate PrefixResolver { internal get; set; }

	/// <summary>
	/// <para>Sets whether to allow mentioning the bot to be used as command prefix.</para>
	/// <para>Defaults to true.</para>
	/// </summary>
	public bool EnableMentionPrefix { internal get; set; } = true;

	/// <summary>
	/// <para>Sets whether strings should be matched in a case-sensitive manner.</para>
	/// <para>This switch affects the behaviour of default prefix resolver, command searching, and argument conversion.</para>
	/// <para>Defaults to false.</para>
	/// </summary>
	public bool CaseSensitive { internal get; set; }

	/// <summary>
	/// <para>Sets whether to enable default help command.</para>
	/// <para>Disabling this will allow you to make your own help command.</para>
	/// <para>
	/// Modifying default help can be achieved via custom help formatters (see <see cref="DisCatSharp.CommandsNext.Converters.BaseHelpFormatter"/> and <see cref="CommandsNextExtension.SetHelpFormatter{T}()"/> for more details).
	/// It is recommended to use help formatter instead of disabling help.
	/// </para>
	/// <para>Defaults to true.</para>
	/// </summary>
	public bool EnableDefaultHelp { internal get; set; } = true;

	/// <summary>
	/// <para>Controls whether the default help will be sent via DMs or not.</para>
	/// <para>Enabling this will make the bot respond with help via direct messages.</para>
	/// <para>Defaults to false.</para>
	/// </summary>
	public bool DmHelp { internal get; set; }

	/// <summary>
	/// <para>Sets the default pre-execution checks for the built-in help command.</para>
	/// <para>Only applicable if default help is enabled.</para>
	/// <para>Defaults to null.</para>
	/// </summary>
	public List<CheckBaseAttribute> DefaultHelpChecks { internal get; set; }

	/// <summary>
	/// <para>Sets whether commands sent via direct messages should be processed.</para>
	/// <para>Defaults to true.</para>
	/// </summary>
	public bool EnableDms { internal get; set; } = true;

	/// <summary>
	/// <para>Sets the service provider for this CommandsNext instance.</para>
	/// <para>Objects in this provider are used when instantiating command modules. This allows passing data around without resorting to static members.</para>
	/// <para>Defaults to an empty service provider.</para>
	/// </summary>
	public IServiceProvider ServiceProvider { internal get; set; }

	/// <summary>
	/// <para>Gets whether any extra arguments passed to commands should be ignored or not. If this is set to false, extra arguments will throw, otherwise they will be ignored.</para>
	/// <para>Defaults to false.</para>
	/// </summary>
	public bool IgnoreExtraArguments { internal get; set; }

	/// <summary>
	/// <para>Gets or sets whether to automatically enable handling commands.</para>
	/// <para>If this is set to false, you will need to manually handle each incoming message and pass it to CommandsNext.</para>
	/// <para>Defaults to true.</para>
	/// </summary>
	public bool UseDefaultCommandHandler { internal get; set; } = true;

	/// <summary>
	/// Creates a new instance of <see cref="CommandsNextConfiguration"/>.
	/// </summary>
	public CommandsNextConfiguration() { }

	/// <summary>
	/// Initializes a new instance of the <see cref="CommandsNextConfiguration"/> class.
	/// </summary>
	/// <param name="provider">The service provider.</param>
	[ActivatorUtilitiesConstructor]
	public CommandsNextConfiguration(IServiceProvider provider)
	{
		this.ServiceProvider = provider;
	}

	/// <summary>
	/// Creates a new instance of <see cref="CommandsNextConfiguration"/>, copying the properties of another configuration.
	/// </summary>
	/// <param name="other">Configuration the properties of which are to be copied.</param>
	public CommandsNextConfiguration(CommandsNextConfiguration other)
	{
		this.CaseSensitive = other.CaseSensitive;
		this.PrefixResolver = other.PrefixResolver;
		this.DefaultHelpChecks = other.DefaultHelpChecks;
		this.EnableDefaultHelp = other.EnableDefaultHelp;
		this.EnableDms = other.EnableDms;
		this.EnableMentionPrefix = other.EnableMentionPrefix;
		this.IgnoreExtraArguments = other.IgnoreExtraArguments;
		this.UseDefaultCommandHandler = other.UseDefaultCommandHandler;
		this.ServiceProvider = other.ServiceProvider;
		this.StringPrefixes = other.StringPrefixes;
		this.DmHelp = other.DmHelp;
	}
}
