using Godot;
using System;

public partial class Player : Node3D
{

    [Export]
    public Marker3D CameraRig;
    [Export]
    public Marker3D CameraXPivot;

    [Export]
    public Camera3D camera;

    [Export]
    public PackedScene BallScene;

    [Export]
    public Marker3D BallSpawnPosition;

    [Export]
    public float StrikeVelocity;

    [Export]
    public float CameraChaseSpeed = 1.0f;

    [Export]
    public float MouseSensitivity = 10f;

    public float gravity = ProjectSettings.GetSetting("physics/3d/default_gravity").AsSingle();


    public override void _Ready()
    {
        if (!IsMultiplayerAuthority()) { return; }
        //CameraRig.TopLevel = true;
        Input.MouseMode = Input.MouseModeEnum.Captured;
        //camera.Current = true;
        camera.Current = true;
        //base._Ready();
    }

    public override void _EnterTree()
    {
        SetMultiplayerAuthority(int.Parse(Name));
        base._EnterTree();
    }

    public override void _Input(InputEvent @event)
    {
        if (!IsMultiplayerAuthority()) { return; }
        if (@event is InputEventMouseMotion)
        {
            var mouseEvent = (InputEventMouseMotion)@event;
            this.RotateY(-Mathf.DegToRad(mouseEvent.Relative.X * this.MouseSensitivity));
            //CameraRig.RotateY(-Mathf.DegToRad(mouseEvent.Relative.X * this.MouseSensitivity));
            // I don't think I want the players to look up and down since old golf games just kept the camera straight
            // and maybe allowed for a pivot to point in a new direction
            //CameraXPivot.RotateX(-Mathf.DegToRad(mouseEvent.Relative.Y * this.MouseSensitivity));


            //CameraRig.RotateCameraRig.CameraRig.GlobalPosition.Slerp(GlobalPosition, 0.1f);
            //CameraRig.GlobalPosition = RotateAround(CameraRig.GlobalTransform, GlobalPosition, 2f, 2f);
        }
        if (@event is InputEventMouseButton)
        {
            var clickEvent = (InputEventMouseButton)@event;
            if (clickEvent.ButtonIndex == MouseButton.Left && clickEvent.Pressed)
            {
                SpawnBall();
            }
        }
    }

    public void SpawnBall()
    {
        var b = GD.Load<PackedScene>(BallScene.ResourcePath);
        var ball = b.Instantiate();

        AddChild(ball);
        (ball as Ball).Position = BallSpawnPosition.Position;
        (ball as Ball).ChangeVelocity(StrikeVelocity * (Vector3.Forward + Vector3.Up).Normalized());
    }

    public override void _UnhandledInput(InputEvent @event)
    {
        if (!IsMultiplayerAuthority()) { return; }
        if (@event is InputEventKey eventKey)
        {
            if (eventKey.Pressed && eventKey.Keycode == Key.Escape)
            {
                //TODO bring up menu
                //GetTree().Quit();
            }
        }
    }

    // public override void _PhysicsProcess(double delta)
    // {
    //     Vector3 velocity = Velocity;

    //     // Add the gravity.
    //     if (!IsOnFloor())
    //     {
    //         velocity.Y -= gravity * (float)delta;
    //     }

    // }
}
