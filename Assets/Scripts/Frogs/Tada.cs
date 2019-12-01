using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GroundMovement))]
[RequireComponent(typeof(ShooterBehaviour))]
public class Tada : Sprog
{

    private Animator animator;

    private void Start() {
        animator = GetComponent<Animator>();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.T)) {
            animator.SetTrigger("Punch");
        }
    }

    public override void toggleComponents(bool enabled) {
        GetComponent<GroundMovement>().enabled = enabled;
        GetComponent<ShooterBehaviour>().enabled = enabled;
        this.enabled = enabled;
    }
}
