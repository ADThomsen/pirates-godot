using Godot;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using RacingGame.Scripts;

public partial class GameManager : Node2D
{
	[Export] public int LapCount = 3;
	
	public Dictionary<string, int> PlayerLaps = new();
	public Stopwatch LapTimer = new();
	public Timer StartTimer = new();
	public int Countdown = 3;
	public Label CountdownTimerLabel = new();
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		StartTimer = GetNode<Timer>("StartTimer");
		StartTimer.WaitTime = 1;
		CountdownTimerLabel = GetNode<Label>("StartTimerLabel");
		CountdownTimerLabel.Text = Countdown.ToString();
		StartTimer.Start();
		
		IEnumerable<Car> cars = GetChildren().Where(x => x is Car).Cast<Car>();
		foreach (Car car in cars)
		{
			PlayerLaps.Add(car.PlayerName, 0);
			EventHub.Publish("PlayerJoinedRace", this, car.PlayerName);
		}
		
		EventHub.Subscribe<string>("PlayerCrossedFinishLine", OnPlayerCrossedFinishLine);
		Storage.LoadFastestTime();
	}
	
	public void CountdownTimerTimeout()
	{
		if (Countdown == 0)
		{
			CountdownTimerLabel.QueueFree();
			LapTimer.Start();
			return;
		}
		
		Countdown -= 1;
		CountdownTimerLabel.Text = Countdown.ToString();
		
		if (Countdown == 0)
		{
			EventHub.Publish<string>("RaceStarted", this, null);
		}
	}
	
	private void OnPlayerCrossedFinishLine(object sender, string playerName)
	{
		PlayerLaps[playerName] += 1;

		if (PlayerLaps[playerName] > LapCount)
		{
			Storage.AddNewTime(playerName, LapTimer.ElapsedMilliseconds);
			EventHub.Publish("PlayerFinishedRace", this, playerName);
			return;
		}
		
		EventHub.Publish("PlayerStartedLap", this, playerName);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		EventHub.Publish("LapTimeUpdated", this, LapTimer.ElapsedMilliseconds);
	}
}