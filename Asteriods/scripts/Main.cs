using Godot;

public partial class Main : Node
{
	Node Lasers = new Node();
	Player Player = new Player();

	public override void _Ready()
	{
		Lasers = GetNode<Node>("Lasers");

		Player = GetNode<Player>("Player");
		Player.LaserFired += OnLaserFired;
	}

    public override void _Process(double delta)
    {
        if (Input.IsActionJustPressed("Restart"))
		{
			GetTree().ReloadCurrentScene();
		}
    }

    public void OnLaserFired(Laser laser)
	{
		Lasers.AddChild(laser);
	}
}
