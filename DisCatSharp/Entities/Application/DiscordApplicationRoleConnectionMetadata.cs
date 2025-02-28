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

using DisCatSharp.Enums;

using Newtonsoft.Json;

namespace DisCatSharp.Entities;

/// <summary>
/// Represents a role connection metadata object that is registered to an application.
/// </summary>
public sealed class DiscordApplicationRoleConnectionMetadata : IEquatable<DiscordApplicationRoleConnectionMetadata>
{
	/// <summary>
	/// Gets the type of this role connection metadata object.
	/// </summary>
	[JsonProperty("type")]
	public ApplicationRoleConnectionMetadataType Type { get; internal set; }

	/// <summary>
	/// The dictionary key for the metadata field.
	/// Must be `a-z`, `0-9`, or `_` characters.
	/// </summary>
	[JsonProperty("key")]
	public string Key { get; internal set; }

	/// <summary>
	/// Gets the name of the metadata field.
	/// </summary>
	[JsonProperty("name")]
	public string Name { get; internal set; }

	/// <summary>
	/// Sets the name localizations.
	/// </summary>
	[JsonProperty("name_localizations", NullValueHandling = NullValueHandling.Ignore)]
	internal Dictionary<string, string> RawNameLocalizations { get; set; }

	/// <summary>
	/// Gets the name localizations.
	/// </summary>
	[JsonIgnore]
	public DiscordApplicationCommandLocalization NameLocalizations
		=> new(this.RawNameLocalizations);

	/// <summary>
	/// Gets the description of the metadata field.
	/// </summary>
	[JsonProperty("description")]
	public string Description { get; internal set; }

	/// <summary>
	/// Sets the description localizations.
	/// </summary>
	[JsonProperty("description_localizations", NullValueHandling = NullValueHandling.Ignore)]
	internal Dictionary<string, string> RawDescriptionLocalizations { get; set; }

	/// <summary>
	/// Gets the description localizations.
	/// </summary>
	[JsonIgnore]
	public DiscordApplicationCommandLocalization DescriptionLocalizations
		=> new(this.RawDescriptionLocalizations);

	/// <summary>
	/// Creates a new instance of a <see cref="DiscordApplicationRoleConnectionMetadata"/>.
	/// </summary>
	public DiscordApplicationRoleConnectionMetadata(
		ApplicationRoleConnectionMetadataType type, string key, string name, string description,
		DiscordApplicationCommandLocalization nameLocalizations = null, DiscordApplicationCommandLocalization descriptionLocalizations = null
	)
	{
		this.Type = type;
		this.Key = key;
		this.Name = name;
		this.Description = description;
		this.RawNameLocalizations = nameLocalizations?.GetKeyValuePairs();
		this.RawDescriptionLocalizations = descriptionLocalizations?.GetKeyValuePairs();
	}

	/// <summary>
	/// Checks whether this <see cref="DiscordApplicationRoleConnectionMetadata"/> object is equal to another object.
	/// </summary>
	/// <param name="other">The command to compare to.</param>
	/// <returns>Whether the command is equal to this <see cref="DiscordApplicationRoleConnectionMetadata"/>.</returns>
	public bool Equals(DiscordApplicationRoleConnectionMetadata other)
		=> this.Key == other.Key;

	/// <summary>
	/// Determines if two <see cref="DiscordApplicationRoleConnectionMetadata"/> objects are equal.
	/// </summary>
	/// <param name="e1">The first command object.</param>
	/// <param name="e2">The second command object.</param>
	/// <returns>Whether the two <see cref="DiscordApplicationRoleConnectionMetadata"/> objects are equal.</returns>
	public static bool operator ==(DiscordApplicationRoleConnectionMetadata e1, DiscordApplicationRoleConnectionMetadata e2)
		=> e1.Equals(e2);

	/// <summary>
	/// Determines if two <see cref="DiscordApplicationRoleConnectionMetadata"/> objects are not equal.
	/// </summary>
	/// <param name="e1">The first command object.</param>
	/// <param name="e2">The second command object.</param>
	/// <returns>Whether the two <see cref="DiscordApplicationRoleConnectionMetadata"/> objects are not equal.</returns>
	public static bool operator !=(DiscordApplicationRoleConnectionMetadata e1, DiscordApplicationRoleConnectionMetadata e2)
		=> !(e1 == e2);

	/// <summary>
	/// Determines if a <see cref="object"/> is equal to the current <see cref="DiscordApplicationRoleConnectionMetadata"/>.
	/// </summary>
	/// <param name="other">The object to compare to.</param>
	/// <returns>Whether the two <see cref="DiscordApplicationRoleConnectionMetadata"/> objects are not equal.</returns>
	public override bool Equals(object other)
		=> other is DiscordApplicationRoleConnectionMetadata dac && this.Equals(dac);

	/// <summary>
	/// Gets the hash code for this <see cref="DiscordApplicationRoleConnectionMetadata"/>.
	/// </summary>
	/// <returns>The hash code for this <see cref="DiscordApplicationRoleConnectionMetadata"/>.</returns>
	public override int GetHashCode()
		=> this.Key.GetHashCode();
}
