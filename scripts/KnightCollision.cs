using Godot;
using System;

public partial class KnightCollision : CollisionShape2D
{
	private Vector2 _pos = new Vector2(-0.05f, 7);
	private Vector2 _mirroredPos = new Vector2(8, 7);
	
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		AnimatedSprite2D knight = GetNode<AnimatedSprite2D>("./Knight");
		CollisionShape2D collisionShape = GetNode<CollisionShape2D>("CollisionShape2D");

		if (knight.FlipH)
		{
			collisionShape.GlobalPosition = _pos;
		}
		else
		{
			collisionShape.GlobalPosition = _mirroredPos;
		}
	}
}
