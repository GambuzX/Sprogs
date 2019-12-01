using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(WaterMovement))]
[RequireComponent(typeof(ShooterBehaviour))]
[RequireComponent(typeof(DashBehaviour))]
public class WaterFrog : Frolien
{
    public override void disableComponents() {
        GetComponent<WaterMovement>().enabled = false;
        GetComponent<ShooterBehaviour>().enabled = false;
        GetComponent<DashBehaviour>().enabled = false;
        this.enabled = false;
    }
}
