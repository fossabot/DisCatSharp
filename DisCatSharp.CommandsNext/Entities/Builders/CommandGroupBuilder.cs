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
using System.Collections.ObjectModel;
using System.Linq;

using DisCatSharp.CommandsNext.Entities;

namespace DisCatSharp.CommandsNext.Builders;

/// <summary>
/// Represents an interface to build a command group.
/// </summary>
public sealed class CommandGroupBuilder : CommandBuilder
{
	/// <summary>
	/// Gets the list of child commands registered for this group.
	/// </summary>
	public IReadOnlyList<CommandBuilder> Children { get; }

	/// <summary>
	/// Gets the children list.
	/// </summary>
	private readonly List<CommandBuilder> _childrenList;

	/// <summary>
	/// Creates a new module-less command group builder.
	/// </summary>
	public CommandGroupBuilder()
		: this(null)
	{ }

	/// <summary>
	/// Creates a new command group builder.
	/// </summary>
	/// <param name="module">Module on which this group is to be defined.</param>
	public CommandGroupBuilder(ICommandModule module)
		: base(module)
	{
		this._childrenList = new List<CommandBuilder>();
		this.Children = new ReadOnlyCollection<CommandBuilder>(this._childrenList);
	}

	/// <summary>
	/// Adds a command to the collection of child commands for this group.
	/// </summary>
	/// <param name="child">Command to add to the collection of child commands for this group.</param>
	/// <returns>This builder.</returns>
	public CommandGroupBuilder WithChild(CommandBuilder child)
	{
		this._childrenList.Add(child);
		return this;
	}

	/// <summary>
	/// Builds the command group.
	/// </summary>
	/// <param name="parent">The parent command group.</param>
	internal override Command Build(CommandGroup parent)
	{
		var cmd = new CommandGroup
		{
			Name = this.Name,
			Description = this.Description,
			Aliases = this.Aliases,
			ExecutionChecks = this.ExecutionChecks,
			IsHidden = this.IsHidden,
			Parent = parent,
			Overloads = new ReadOnlyCollection<CommandOverload>(this.Overloads.Select(xo => xo.Build()).ToList()),
			Module = this.Module,
			CustomAttributes = this.CustomAttributes
		};

		var cs = new List<Command>();
		foreach (var xc in this.Children)
			cs.Add(xc.Build(cmd));

		cmd.Children = new ReadOnlyCollection<Command>(cs);
		return cmd;
	}
}
