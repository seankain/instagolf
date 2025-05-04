using Godot;
using System;

public partial class Ball : RigidBody3D
{
    //kg
    //public float Mass = 0.04593f;

    public override void _Ready()
    {
        base._Ready();
    }


    // public override void _PhysicsProcess(double delta)
    // {
    //     MoveAndCollide(this.Velocity);
    // }

    public void ChangeVelocity(Vector3 velocity)
    {
        this.ApplyImpulse(velocity);
    }

}
