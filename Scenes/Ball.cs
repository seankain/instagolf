using Godot;
using System;

public partial class Ball : CharacterBody3D
{
    //kg
    public float Mass = 0.04593f;

    public override void _PhysicsProcess(double delta)
    {
        MoveAndCollide(this.Velocity);
    }

    public void ChangeVelocity(Vector3 velocity)
    {
        this.Velocity = velocity;
    }

}
