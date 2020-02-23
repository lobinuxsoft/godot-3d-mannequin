using Godot;
using Godot.Collections;
using System;

public class CsSpringArm : SpringArm
{
    [Export] private Vector2 _lengthRange = new Vector2(3, 6);
    [Export] private float _zoom = .5f;

    private Vector3 _positionStart = Vector3.Zero;

    public override void _Ready()
    {
        _positionStart = Translation;
    }

    public void SetLengthRange(Vector2 value)
    {
        value.x = Mathf.Max(value.x, 0);
        value.y = Mathf.Max(value.y, 0);
        _lengthRange.x = Mathf.Min(value.x, value.y);
        _lengthRange.y = Mathf.Max(value.x, value.y);
        SetZoom(_zoom);
    }

    public void SetZoom(float value)
    {
        if (value >= 0 && value <= 1)
        {
            _zoom = value;
            SpringLength = _lengthRange.y + _lengthRange.x - Mathf.Lerp(_lengthRange.x, _lengthRange.y, _zoom);
        }
    }
}
