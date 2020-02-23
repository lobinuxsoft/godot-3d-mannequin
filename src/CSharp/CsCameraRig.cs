using Godot;

[Tool]
public class CsCameraRig : Spatial
{
    [Export] private NodePath _interpolatedCameraPath;
    [Export] private NodePath _csSpringArmPath;
    [Export] private NodePath _aimRayPath;
    [Export] private NodePath _aimTargetPath;
    [Signal] public delegate void AimFired(Vector3 targetPosition);

    InterpolatedCamera _interpolatedCamera;
    CsSpringArm _csSpringArm;
    RayCast _aimRay;
    Sprite3D _aimTarget;

    KinematicBody _player;

    float _zoom = .5f;
    Vector3 _positionStart = Vector3.Zero;

    // Called when the node enters the scene tree for the first time.
    public override async void _Ready()
    {
        _positionStart = Translation;
        SetAsToplevel(true);
        
        await ToSignal(Owner, "ready");

        _player = (KinematicBody)Owner;
        
        _interpolatedCamera = GetNode<InterpolatedCamera>(_interpolatedCameraPath);
        _csSpringArm = GetNode<CsSpringArm>(_csSpringArmPath);
        _aimRay = GetNode<RayCast>(_aimRayPath);
        _aimTarget = GetNode<Sprite3D>(_aimTargetPath);
    }

    public void SetZoom(float value)
    {
        _zoom = Mathf.Clamp(value, 0f, 1f);
        _csSpringArm.SetZoom(_zoom);
    }

    public override string _GetConfigurationWarning()
    {
        return (_player == null) ? "Missing player node" : "";
    }
}
