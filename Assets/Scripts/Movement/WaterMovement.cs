using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMovement : Movement
{

    public GameObject jumpSpot;

    private bool diveLocked;

    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        diveLocked = false;
        jumpSpot = GameObject.FindGameObjectWithTag("JumpSpot");
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
            animator.SetTrigger("Jump");
            animator.ResetTrigger("Dive");
            animator.SetBool("Grounded", false);
        }

        if (!diveLocked && grounded && (Input.GetButton(frog.EnterWaterName()) || Input.GetAxis(frog.VerticalAxisName()) == -1))
        {
            frog.toggleComponents(false);
            animator.SetTrigger("Dive");
            grounded = false;
            diveLocked = true;
            Invoke("UnlockDive", 2f);
            Invoke("JumpFromSpot", 2f);
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
                animator.SetBool("Grounded", true);
                break;
        }
    }

    void JumpFromSpot()
    {
        gameObject.transform.position = jumpSpot.transform.position;
        animator.SetTrigger("Resurface");
        rb.velocity = Vector2.zero;
        rb.AddForce(Vector2.up*10, ForceMode2D.Impulse);
        Invoke("ResetCollider", 0.5f);
        grounded = false;
        animator.SetBool("Grounded", false);
    }

    void ResetCollider()
    {
        gameObject.GetComponentInChildren<Collider2D>().enabled = true;
        frog.toggleComponents(true);
    }

    void UnlockDive() {
        diveLocked = false;
    }
}
