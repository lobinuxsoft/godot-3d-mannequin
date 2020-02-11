using Godot;
using System;

public class CameraRig : Spatial
{
    [Export] NodePath interpolatedCameraPath;
    [Export] NodePath springArmPath;
    [Export] NodePath rayCastPath;
    [Export] NodePath sprite3DPath;
    [Signal] public delegate void AimFired(Vector3 target_position);

    InterpolatedCamera interpolatedCamera;
    SpringArm springArm;
    RayCast rayCast;
    Sprite3D sprite3D;

    KinematicBody player;

    float zoom = .5f;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        interpolatedCamera = GetNode<InterpolatedCamera>(interpolatedCameraPath);
        springArm = GetNode<SpringArm>(springArmPath);
        rayCast = GetNode<RayCast>(rayCastPath);
        sprite3D = GetNode<Sprite3D>(sprite3DPath);

        SetAsToplevel(true);
    }

    public void SetZoom(float value){
        zoom = Mathf.Clamp(value, 0f, 1f);
	    //springArm. = zoom;
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
