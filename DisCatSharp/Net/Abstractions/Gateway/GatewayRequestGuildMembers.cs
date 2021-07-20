// This file is part of the DisCatSharp project.
//
// Copyright (c) 2021 AITSYS
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
using Newtonsoft.Json;

namespace DisCatSharp.Net.Abstractions
{
    /// <summary>
    /// Request guild members.
    /// </summary>
    internal sealed class GatewayRequestGuildMembers
    {
        /// <summary>
        /// Gets the guild id.
        /// </summary>
        [JsonProperty("guild_id")]
        public ulong GuildId { get; }

        /// <summary>
        /// Gets the query.
        /// </summary>
        [JsonProperty("query", NullValueHandling = NullValueHandling.Ignore)]
        public string Query { get; set; } = null;

        /// <summary>
        /// Gets the limit.
        /// </summary>
        [JsonProperty("limit")]
        public int Limit { get; set; } = 0;

        /// <summary>
        /// Gets whether presences should be returned.
        /// </summary>
        [JsonProperty("presences", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Presences { get; set; } = null;

        /// <summary>
        /// Gets the user ids.
        /// </summary>
        [JsonProperty("user_ids", NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<ulong> UserIds { get; set; } = null;

        /// <summary>
        /// Gets the nonce.
        /// </summary>
        [JsonProperty("nonce", NullValueHandling = NullValueHandling.Ignore)]
        public string Nonce { get; internal set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GatewayRequestGuildMembers"/> class.
        /// </summary>
        /// <param name="guild">The guild.</param>
        public GatewayRequestGuildMembers(DiscordGuild guild)
        {
            this.GuildId = guild.Id;
        }
    }
}