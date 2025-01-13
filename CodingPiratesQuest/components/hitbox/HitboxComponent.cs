using Godot;
using System;
using CodingPiratesQuest.components.attack;

public partial class HitboxComponent : Area2D
{
	[Signal]
	public delegate void AttackEventHandler(Attack attack);
	
	public void OnAreaEntered(Node2D area)
	{
		if (area is WeaponComponent weapon)
		{
			EmitSignal(SignalName.Attack, weapon.Attack);
		}
	}
}
