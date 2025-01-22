using Godot;
using System;
using CodingPiratesQuest.components.attack;

public partial class HitboxComponent : Area2D
{
	[Export]
	public int Damage { get; set; } = 10;
	
	[Signal]
	public delegate void AttackEventHandler(Attack attack);
	
	public void OnAreaEntered(Node2D area)
	{
		if (area is HealthComponent healthComponent)
		{
			healthComponent.TakeDamage(Damage);
		}
	}
}
