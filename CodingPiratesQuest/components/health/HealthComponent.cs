using Godot;
using System;

public partial class HealthComponent : Node
{
	[Export]
	public int Health { get; set; } = 100;
}
