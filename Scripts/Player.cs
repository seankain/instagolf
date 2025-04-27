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
    public float CameraChaseSpeed = 1.0f;

    [Export]
    public float MouseSensitivity = 10f;

    public override void _Ready()
    {
        if (!IsMultiplayerAuthority()) { return; }
        CameraRig.TopLevel = true;
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
            CameraRig.RotateY(-Mathf.DegToRad(mouseEvent.Relative.X * this.MouseSensitivity));
            CameraXPivot.RotateX(-Mathf.DegToRad(mouseEvent.Relative.Y * this.MouseSensitivity));


            //CameraRig.RotateCameraRig.CameraRig.GlobalPosition.Slerp(GlobalPosition, 0.1f);
            //CameraRig.GlobalPosition = RotateAround(CameraRig.GlobalTransform, GlobalPosition, 2f, 2f);
        }
        if (@event is InputEventMouseButton)
        {
            var clickEvent = (InputEventMouseButton)@event;
            GD.Print(clickEvent.ButtonIndex);
            if (clickEvent.ButtonIndex == MouseButton.Left)
            {

            }
        }
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
}
