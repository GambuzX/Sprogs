using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GroundMovement))]
[RequireComponent(typeof(ShooterBehaviour))]
public class Tada : Sprog
{
    public override void disableComponents() {
        GetComponent<GroundMovement>().enabled = false;
        GetComponent<ShooterBehaviour>().enabled = false;
        this.enabled = false;
    }
}
