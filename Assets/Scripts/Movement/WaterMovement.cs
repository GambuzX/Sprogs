using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMovement : Movement
{

    private Animator animator;

    public GameObject jumpSpot;

    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        jumpSpot = GameObject.FindGameObjectWithTag("JumpSpot");
        animator = GetComponent<Animator>();
    }

    void FixedUpdate() {
        float moveHorizontal = Input.GetAxis(frog.HorizontalAxisName());
        animator.SetFloat("HorizontalMove",Mathf.Abs(moveHorizontal)) ;

        if (moveHorizontal > 0) {
            lastMoveRight = true;
            transform.eulerAngles = new Vector3(0.0f, 0, 0.0f);
        }
        else if (moveHorizontal < 0) {
            lastMoveRight = false;
            transform.eulerAngles = new Vector3(0.0f, 180, 0.0f);
        }

        rb.velocity = new Vector2(moveHorizontal * moveSpeed * Time.deltaTime, rb.velocity.y);

        if (grounded && Input.GetButton(frog.JumpButtonName())) {
            rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
            grounded = false;
        }

        if (grounded && Input.GetButton(frog.EnterWaterName()))
        {
            gameObject.GetComponentInChildren<Collider2D>().enabled = false;
            grounded = false;
            Invoke("JumpFromSpot", 2);
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        switch(collision.transform.tag) {
            case "Ground":
                fullLockMovement();
                levelController.GameOver(this.gameObject.GetComponent<Fighter>());
                break;

            case "Water":
                grounded = true;
                break;
        }
    }

    void JumpFromSpot()
    {
        gameObject.transform.position = jumpSpot.transform.position;
        rb.velocity = Vector2.zero;
        rb.AddForce(Vector2.up*10, ForceMode2D.Impulse);
        Invoke("ResetCollider", 2f);
    }

    void ResetCollider()
    {
        gameObject.GetComponentInChildren<Collider2D>().enabled = true;
    }
}
