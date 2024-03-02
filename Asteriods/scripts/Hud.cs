using Godot;

public partial class Hud : Control
{
	Label Score = new Label();

	public override void _Ready()
	{
		Score = GetNode<Label>("Score");
	}

	public void SetScore(int score)
	{
		Score.Text = "SCORE: " + score.ToString();
	}
}
