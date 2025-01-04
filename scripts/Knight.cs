using Godot;
using System;

public partial class Knight : CharacterBody2D
{
    public const float Speed = 125.0f;
    public const float JumpVelocity = -175.0f;
    
    // Animation Handler
    private AnimatedSprite2D _animatedSprite2D;
    [Export] bool isSpriteFlipped = false;

    public override void _Ready()
    {
        _animatedSprite2D = GetNode<AnimatedSprite2D>("Knight");
    }
    
    public override void _PhysicsProcess(double delta)
    {
        // Movement
        Vector2 velocity = Velocity;

        // Add the gravity.
        if (!IsOnFloor())
        {
            velocity += GetGravity() * (float)delta;
        }

        // Handle Jump.
        if (Input.IsActionJustPressed("jump") && IsOnFloor())
        {
            velocity.Y = JumpVelocity;
        }
        
        
        
        Vector2 direction = Input.GetVector("walk_left", "walk_right", "ui_up", "ui_down");
        if (direction != Vector2.Zero)
        {
            if (direction < Vector2.Zero)
            {
                _animatedSprite2D.FlipH = true; 
                isSpriteFlipped = true;
            }
            else
            {
                _animatedSprite2D.FlipH = false;
                isSpriteFlipped = false;
            }
            
            _animatedSprite2D.Play("run");
            velocity.X = direction.X * Speed;
        }
        else
        {
            _animatedSprite2D.Play("idle");
            velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
        }

        Velocity = velocity;
        MoveAndSlide();
    }
}