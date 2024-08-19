using Godot;
using System;

public partial class Car : CharacterBody2D
{
    [Export] public InputEventKey ForwardKey { get; set; }

    [Export] public InputEventKey ReverseKey { get; set; }

    [Export] public InputEventKey RightKey { get; set; }

    [Export] public InputEventKey LeftKey { get; set; }

    [Export] public string PlayerName { get; set; }

    [Export] public float Friction = -55f;

    [Export] public float Drag = -0.06f;

    [Export] public float Braking = -450f;

    [Export] public float MaxSpeedReverse = 250f;

    [Export] public float EnginePower = 900.0f;

    [Export] public float RotationSpeed = 6.0f;

    private StringName Left { get; set; }
    private StringName Right { get; set; }
    private StringName Forward { get; set; }
    private StringName Reverse { get; set; }

    private Vector2 Acceleration = Vector2.Zero;
    private const float SteeringAngle = 15;
    private const float WheelBase = 70;

    public override void _Ready()
    {
        Left = new StringName(PlayerName + "_left");
        Right = new StringName(PlayerName + "_right");
        Forward = new StringName(PlayerName + "_forward");
        Reverse = new StringName(PlayerName + "_reverse");
        InputMap.AddAction(Left);
        InputMap.AddAction(Right);
        InputMap.AddAction(Forward);
        InputMap.AddAction(Reverse);
        InputMap.ActionAddEvent(Left, LeftKey);
        InputMap.ActionAddEvent(Right, RightKey);
        InputMap.ActionAddEvent(Forward, ForwardKey);
        InputMap.ActionAddEvent(Reverse, ReverseKey);
    }

    public override void _PhysicsProcess(double delta)
    {
        SetAcceleration((float)delta);
        SetSteering((float)delta);

        Velocity += Acceleration * (float)delta;

        MoveAndSlide();
    }

    private void SetSteering(float delta)
    {
        Vector2 rearWheel = Position - Transform.X * WheelBase / 2.0f;
        Vector2 frontWheel = Position + Transform.X * WheelBase / 2.0f;
        rearWheel += Velocity * delta;

        float steerDirection = GetSteerDirection();
        frontWheel += Velocity.Rotated(steerDirection) * delta;
        Vector2 newHeading = (frontWheel - rearWheel).Normalized();
        float dot = newHeading.Dot(Velocity.Normalized());
        if (dot > 0)
        {
            Velocity = newHeading * Velocity.Length();
        }
        else
        {
            Velocity = -newHeading * Mathf.Min(Velocity.Length(), MaxSpeedReverse);
        }

        Rotation = newHeading.Angle();
    }

    private float GetSteerDirection()
    {
        float turn = Input.GetAxis(Left, Right);
        float steerDirection = turn * Mathf.DegToRad(SteeringAngle);
        return steerDirection;
    }

    private void SetAcceleration(float delta)
    {
        Acceleration = Vector2.Zero;
        if (Input.IsActionPressed(Forward))
        {
            Acceleration = Transform.X * EnginePower;
        }

        if (Input.IsActionPressed(Reverse))
        {
            Acceleration = Transform.X * Braking;
        }

        if (Acceleration == Vector2.Zero && Velocity.Length() < 50)
        {
            Velocity = Vector2.Zero;
        }

        Vector2 frictionForce = Velocity * Friction * delta;
        Vector2 dragForce = Velocity * Velocity.Length() * Drag * delta;
        Acceleration += dragForce + frictionForce;
    }
}