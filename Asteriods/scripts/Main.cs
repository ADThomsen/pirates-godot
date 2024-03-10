using Godot;

public partial class Main : Node
{
	Node Lasers = new Node();
	Node Asteroids = new Node();
	Player Player = new Player();
	Hud Hud = new Hud();
	Node2D SpawnPosition = new Node2D();
	Control GameOverScreen = new Control();
	AudioStreamPlayer LaserSound = new AudioStreamPlayer();
	AudioStreamPlayer AsteroidHitSound = new AudioStreamPlayer();
	AudioStreamPlayer PlayerHitSound = new AudioStreamPlayer();
	int Score = 0;
	int Lives = 3;

	[Export]
	PackedScene AsteroidScene { get; set; }

	public override void _Ready()
	{
		SpawnPosition = GetNode<Node2D>("SpawnPosition");
		GameOverScreen = GetNode<Control>("UI/GameOverScreen");
		LaserSound = GetNode<AudioStreamPlayer>("LaserSound");
		AsteroidHitSound = GetNode<AudioStreamPlayer>("AsteroidHitSound");
		PlayerHitSound = GetNode<AudioStreamPlayer>("PlayerHitSound");
		Lasers = GetNode<Node>("Lasers");
		Asteroids = GetNode<Node>("Asteroids");
		Hud = GetNode<Hud>("UI/HUD");
		Hud.SetScore(0);
		Hud.SetLives(Lives);

		Player = GetNode<Player>("Player");
		Player.LaserFired += OnLaserFired;
		Player.Died += OnPlayerDied;
		OnAsteroidTimerExpired();
	}

    public override void _Process(double delta)
    {
        if (Input.IsActionJustPressed("Restart"))
		{
			GetTree().ReloadCurrentScene();
		}
    }

	public void OnAsteroidTimerExpired()
	{
		Vector2 screenSize = GetTree().Root.Size;
		float x = (float)GD.RandRange(0, screenSize.X);
		float y = (float)GD.RandRange(0, screenSize.Y);
		SpawnAsteroid(new Vector2(x, y), AsteroidSize.Large);
	}

    public void OnLaserFired(Laser laser)
	{
		LaserSound.Play();
		Lasers.AddChild(laser);
	}

	public void OnPlayerDied()
	{
		PlayerHitSound.Play();
		Lives--;
		Hud.SetLives(Lives);

		if (Lives <= 0) 
		{
			Player.QueueFree();
			GameOverScreen.Visible = true;
		}
		else 
		{
			Player.Respawn(SpawnPosition.GlobalPosition);
		}
	}

	public void OnAsteroidExploded(Asteroid asteroid)
	{
		AsteroidHitSound.Play();
		
		switch (asteroid.Size)
		{
			case AsteroidSize.Large:
				SpawnAsteroid(asteroid.Position, AsteroidSize.Medium);
				SpawnAsteroid(asteroid.Position, AsteroidSize.Medium);
				Score += 50;
				break;
			case AsteroidSize.Medium:
				Score += 100;
				SpawnAsteroid(asteroid.Position, AsteroidSize.Small);
				SpawnAsteroid(asteroid.Position, AsteroidSize.Small);
				break;
			case AsteroidSize.Small:
				Score += 150;
				break;
		}
		Hud.SetScore(Score);
	}

	public void SpawnAsteroid(Vector2 position, AsteroidSize size)
	{
		Asteroid asteroid = AsteroidScene.Instantiate<Asteroid>();
		asteroid.GlobalPosition = position;
		asteroid.Size = size;
		asteroid.AsteroidExploded += OnAsteroidExploded;
		Asteroids.CallDeferred("add_child", asteroid);
	}
}
