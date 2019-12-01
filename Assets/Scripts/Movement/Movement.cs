using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Fighter))]
[RequireComponent(typeof(Animator))]

public abstract class Movement : MonoBehaviour
{
    [SerializeField] protected float moveSpeed = 200f;
    [SerializeField] protected float jumpForce = 6f;

    protected bool grounded;
    protected bool lastMoveRight;
    protected bool movementLocked;

    protected Rigidbody2D rb;
    protected Fighter frog;
    protected LevelController levelController;
    protected Animator animator;

    // Start is called before the first frame update
    protected void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        frog = GetComponent<Fighter>();
        grounded = true;
        movementLocked = false;
        levelController = GameObject.FindObjectOfType<LevelController>();
        animator = GetComponent<Animator>();
    }

    public void lockMovement() {
        rb.velocity = Vector2.zero;
        movementLocked = true;
        this.enabled = false;
    }

    public void unlockMovement() {
        movementLocked = false;
        this.enabled = true;
    }

    protected void fullLockMovement() {
        rb.velocity = Vector2.zero;
        rb.gravityScale = 0;
    }
}
