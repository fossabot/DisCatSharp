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

using System.Collections.Generic;

using DisCatSharp.Entities;
using DisCatSharp.Enums;

using Newtonsoft.Json;

namespace DisCatSharp.ApplicationCommands.Entities;

/// <summary>
/// Represents a command translator.
/// </summary>
internal class CommandTranslator
{
	/// <summary>
	/// Gets the command name.
	/// </summary>
	[JsonProperty("name")]
	public string Name { get; set; }

	/// <summary>
	/// Gets the command description.
	/// </summary>
	[JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
	public string? Description { get; set; }

	/// <summary>
	/// Gets the application command type.
	/// Used to determine whether it is an translator for context menu or not.
	/// </summary>
	[JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
	public ApplicationCommandType? Type { get; set; }

	/// <summary>
	/// Gets the command name translations.
	/// </summary>
	[JsonProperty("name_translations")]
	internal Dictionary<string, string> NameTranslationDictionary { get; set; }
	[JsonIgnore]
	public DiscordApplicationCommandLocalization NameTranslations
		=> new(this.NameTranslationDictionary);

	/// <summary>
	/// Gets the command description translations.
	/// </summary>
	[JsonProperty("description_translations")]
	internal Dictionary<string, string> DescriptionTranslationDictionary { get; set; }
	[JsonIgnore]
	public DiscordApplicationCommandLocalization DescriptionTranslations
		=> new(this.DescriptionTranslationDictionary);

	/// <summary>
	/// Gets the option translators, if applicable.
	/// </summary>
	[JsonProperty("options", NullValueHandling = NullValueHandling.Ignore)]
	public List<OptionTranslator> Options { get; set; }
}
