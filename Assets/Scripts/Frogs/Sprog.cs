using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Sprog : Fighter
{
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
