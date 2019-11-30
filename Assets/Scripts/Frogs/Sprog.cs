using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public abstract class Sprog : Fighter
{
    public Health health;

    public override string HorizontalAxisName() {
        return "SprogHorizontal";
    }
    public override string VerticalAxisName() {
        return "SprogVertical";
    }
    public override string JumpButtonName() {
        return "SprogJump";
    }
    public override string FireButtonName() {
        return "SprogFire";
    }
}
