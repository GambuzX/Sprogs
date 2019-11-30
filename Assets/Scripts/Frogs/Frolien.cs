using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Frolien : Fighter
{
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
}
