using Godot;
using System;

public partial class knight : AnimatedSprite2D
{
	[Export] private float speed = 150f;
	[Export] private float jumpPower = 100f;
	[Export] private float resetTimer = 1f;
	
	private Vector2 LinearVelocity = new Vector2(0,0);
	
	private Vector2 movementThisFrame = new Vector2();
	private Vector2 jumpImpulse = new Vector2();
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		movementThisFrame.Y = speed;
		jumpImpulse.Y = -jumpPower;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public override void _PhysicsProcess(double delta)
	{
		movementThisFrame.Y = LinearVelocity.Y;
		LinearVelocity = movementThisFrame;
	}
	
	public override void _Input(InputEvent @event)
	{
		if (@event is InputEventKey eventKey && (eventKey.Keycode == Key.W || eventKey.Keycode == Key.Up))
		{
			jump();
		}
	}

	private void jump()
	{
		movementThisFrame.Y = jumpImpulse.Y;
		LinearVelocity = movementThisFrame;
	}
	
}
