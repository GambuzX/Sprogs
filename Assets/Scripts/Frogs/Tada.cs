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
        if (Input.GetButtonDown(base.LightAttackName())) {
            animator.SetTrigger("Punch");
        }
    }

    public override void toggleComponents(bool enabled) {
        GetComponent<GroundMovement>().enabled = enabled;
        GetComponent<ShooterBehaviour>().enabled = enabled;
        this.enabled = enabled;
    }
}
