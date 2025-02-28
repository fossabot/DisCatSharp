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

using Newtonsoft.Json;

namespace DisCatSharp.Entities;

/// <summary>
/// Represents a Discord guild's widget.
/// </summary>
public class DiscordWidget : SnowflakeObject
{
	/// <summary>
	/// Gets the guild.
	/// </summary>
	[JsonIgnore]
	public DiscordGuild Guild { get; internal set; }

	/// <summary>
	/// Gets the guild's name.
	/// </summary>
	[JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
	public string Name { get; internal set; }

	/// <summary>
	/// Gets the guild's invite URL.
	/// </summary>
	[JsonProperty("instant_invite", NullValueHandling = NullValueHandling.Ignore)]
	public string InstantInviteUrl { get; internal set; }

	/// <summary>
	/// Gets the number of online members.
	/// </summary>
	[JsonProperty("presence_count", NullValueHandling = NullValueHandling.Ignore)]
	public int PresenceCount { get; internal set; }

	/// <summary>
	/// Gets a list of online members.
	/// </summary>
	[JsonProperty("members", NullValueHandling = NullValueHandling.Ignore)]
	public IReadOnlyList<DiscordWidgetMember> Members { get; internal set; }

	/// <summary>
	/// Gets a list of widget channels.
	/// </summary>
	[JsonIgnore]
	public IReadOnlyList<DiscordChannel> Channels { get; internal set; }
}
