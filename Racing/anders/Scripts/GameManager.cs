using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using RacingGame.Scripts;

public partial class GameManager : Node2D
{
	[Export] public int LapCount = 3;
	
	public Dictionary<string, int> PlayerLaps = new();
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		IEnumerable<Car> cars = GetChildren().Where(x => x is Car).Cast<Car>();
		foreach (Car car in cars)
		{
			PlayerLaps.Add(car.PlayerName, 0);
		}
		EventHub.Publish("PlayerStartedLap", this, PlayerLaps);
		
		EventHub.Subscribe<string>("PlayerCrossedFinishLine", OnPlayerCrossedFinishLine);
	}
	
	private void OnPlayerCrossedFinishLine(object sender, string e)
	{
		PlayerLaps[e] += 1;

		if (PlayerLaps[e] > LapCount)
		{
			EventHub.Publish("PlayerFinishedRace", this, e);
			return;
		}
		
		EventHub.Publish("PlayerStartedLap", this, PlayerLaps);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}