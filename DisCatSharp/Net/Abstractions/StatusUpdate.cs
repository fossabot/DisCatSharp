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

using DisCatSharp.Entities;

using Newtonsoft.Json;

namespace DisCatSharp.Net.Abstractions;

/// <summary>
/// Represents data for websocket status update payload.
/// </summary>
internal sealed class StatusUpdate
{
	/// <summary>
	/// Gets or sets the unix millisecond timestamp of when the user went idle.
	/// </summary>
	[JsonProperty("since", NullValueHandling = NullValueHandling.Include)]
	public long? IdleSince { get; set; }

	/// <summary>
	/// Gets or sets whether the user is AFK.
	/// </summary>
	[JsonProperty("afk")]
	public bool IsAfk { get; set; }

	/// <summary>
	/// Gets or sets the status of the user.
	/// </summary>
	[JsonIgnore]
	public UserStatus Status { get; set; } = UserStatus.Online;

	/// <summary>
	/// Gets the status string of the user.
	/// </summary>
	[JsonProperty("status")]
	internal string StatusString =>
		this.Status switch
		{
			UserStatus.Online => "online",
			UserStatus.Idle => "idle",
			UserStatus.DoNotDisturb => "dnd",
			UserStatus.Invisible or UserStatus.Offline => "invisible",
			UserStatus.Streaming => "streaming",
			_ => "online",
		};

	/// <summary>
	/// Gets or sets the game the user is playing.
	/// </summary>
	[JsonProperty("game", NullValueHandling = NullValueHandling.Ignore)]
	public TransportActivity Activity { get; set; }

	internal DiscordActivity ActivityInternal;
}
