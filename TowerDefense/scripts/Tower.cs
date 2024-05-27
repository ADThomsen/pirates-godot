using Godot;
using System.Collections.Generic;
using System.Linq;

public partial class Tower : StaticBody2D
{
	[Export]
	public PackedScene BulletScene { get; set; }

	[Export]
	public int Damage { get; set; } = 100;

	public List<Enemy> EnemiesInSight = new List<Enemy>();
	public Marker2D RocketMarker = new Marker2D();

	public override void _Ready()
	{
		RocketMarker = GetNode<Marker2D>("RocketMarker");
	}

	public override void _Process(double delta)
	{
		if (EnemiesInSight.Count > 0)
		{
			LookAt(EnemiesInSight.First().GlobalPosition);
		}
	}

	public void OnBodyEntered(Node2D body)
	{
		if (body is Enemy enemy)
		{
			EnemiesInSight.Add(enemy);
		}
	}

	public void OnBodyExited(Node2D body)
	{
		if (body is Enemy enemy && EnemiesInSight.Contains(enemy))
		{
			EnemiesInSight.Remove(enemy);
		}
	}

	public void OnFireTimerExpired()
	{
		Fire();
	}

	public void Fire()
	{
		if (EnemiesInSight.Count > 0)
		{
			Bullet bullet = BulletScene.Instantiate<Bullet>();
			bullet.Enemy = EnemiesInSight.First();
			bullet.Damage = Damage;
			bullet.GlobalPosition = RocketMarker.Position;
			CallDeferred("add_child", bullet);
		}
	}
}
