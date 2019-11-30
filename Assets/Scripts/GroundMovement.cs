﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class GroundMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 200f;
    [SerializeField] float jumpForce = 6f;
    private bool grounded;

    private bool lastMoveRight;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        grounded = true;
    }

    void FixedUpdate() {
        float moveHorizontal  = Input.GetAxis("FrolienHorizontal");

        if (moveHorizontal > 0) {
            lastMoveRight = true;
            transform.eulerAngles = new Vector3(0.0f, 0, 0.0f);
        }
        else if (moveHorizontal < 0) {
            lastMoveRight = false;
            transform.eulerAngles = new Vector3(0.0f, 180, 0.0f);
        }

        rb.velocity = new Vector2(moveHorizontal * moveSpeed * Time.deltaTime, rb.velocity.y);

        if (grounded && Input.GetButton("FrolienJump")) {
            //animator.SetTrigger("jump");
            rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
            grounded = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if(collision.transform.tag == "Ground") {
            grounded = true;
        }
    }
}