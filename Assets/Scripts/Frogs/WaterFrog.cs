using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(WaterMovement))]
[RequireComponent(typeof(ShooterBehaviour))]
[RequireComponent(typeof(DashBehaviour))]
public class WaterFrog : Frolien
{
    public override void toggleComponents(bool enabled) {
        GetComponent<WaterMovement>().enabled = enabled;
        GetComponent<ShooterBehaviour>().enabled = enabled;
        GetComponent<DashBehaviour>().enabled = enabled;
        this.enabled = enabled;
    }
}
