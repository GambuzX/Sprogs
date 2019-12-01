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

    public override void disableComponents() {
        GetComponent<GroundMovement>().enabled = false;
        GetComponent<ShooterBehaviour>().enabled = false;
        this.enabled = false;
    }
}
