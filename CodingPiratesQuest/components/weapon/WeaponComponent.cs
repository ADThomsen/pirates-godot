using Godot;
using System;
using CodingPiratesQuest.components.attack;

public partial class WeaponComponent : Node2D
{
	public Attack Attack { get; set; }

	public override void _Ready()
	{
	}

	public override void _Process(double delta)
	{
	}
}
