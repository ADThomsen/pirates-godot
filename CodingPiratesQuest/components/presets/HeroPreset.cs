using Godot;
using CodingPiratesQuest.components.attack;
using CodingPiratesQuest.components.player;

public partial class HeroPreset : CharacterBody2D
{
    public AnimationNodeStateMachinePlayback StateMachine { get; set; }

    public Sprite2D Sprite { get; set; }

    public override void _Ready()
    {
        StateMachine =
            (AnimationNodeStateMachinePlayback)GetNode<AnimationTree>("AnimationTree").Get("parameters/playback");
        Sprite = GetNode<Sprite2D>("Sprite2D");
    }

    public override void _PhysicsProcess(double delta)
    {
        Velocity = Input.GetVector("MoveLeft", "MoveRight", "MoveUp", "MoveDown") * PlayerProperties.Instance.RunSpeed;

        Sprite.FlipH = Velocity.X < 0;

        if (Velocity.Length() > 0)
        {
            StateMachine.Travel("walk");
        }
        else
        {
            StateMachine.Travel("idle");
        }

        MoveAndSlide();
    }

    public void OnHeroAttacked(Attack attack)
    {
    }
}