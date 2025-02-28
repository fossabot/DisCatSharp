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

namespace DisCatSharp.VoiceNext.Entities;

/// <summary>
/// The voice ready payload.
/// </summary>
internal sealed class VoiceReadyPayload
{
	/// <summary>
	/// Gets or sets the s s r c.
	/// </summary>
	[JsonProperty("ssrc")]
	public uint Ssrc { get; set; }

	/// <summary>
	/// Gets or sets the address.
	/// </summary>
	[JsonProperty("ip")]
	public string Address { get; set; }

	/// <summary>
	/// Gets or sets the port.
	/// </summary>
	[JsonProperty("port")]
	public ushort Port { get; set; }

	/// <summary>
	/// Gets or sets the modes.
	/// </summary>
	[JsonProperty("modes")]
	public IReadOnlyList<string> Modes { get; set; }

	/// <summary>
	/// Gets or sets the heartbeat interval.
	/// </summary>
	[JsonProperty("heartbeat_interval")]
	public int HeartbeatInterval { get; set; }
}
