using Godot;
using System;

public partial class HealthComponent : Area2D
{
	[Export]
	public int Health { get; set; } = 100;
	[Signal]
	public delegate void DeathEventHandler();
	
	public void TakeDamage(int damage)
	{
		Health -= damage;
		if (Health <= 0)
		{
			EmitSignal(SignalName.Death);
		}
	}
}
