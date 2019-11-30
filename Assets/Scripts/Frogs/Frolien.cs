using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public abstract class Frolien : Fighter
{
    public Health health;

    public override string HorizontalAxisName() {
        return "FrolienHorizontal";
    }
    public override string VerticalAxisName() {
        return "FrolienVertical";
    }
    public override string JumpButtonName() {
        return "FrolienJump";
    }
    public override string FireButtonName() {
        return "FrolienFire";
    }
    public override string DashButtonName() {
        return "FrolienDash";
    }
}
