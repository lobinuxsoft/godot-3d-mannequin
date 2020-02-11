using Godot;
using System;

public class Player : KinematicBody
{
    public override void _Ready()
    {
        
    }

    public override String _GetConfigurationWarning(){
        return $"Missing camera node...";
    }

    // func _get_configuration_warning() -> String:
    // 	return "Missing camera node" if not camera else ""
}
