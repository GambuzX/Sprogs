using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Fighter))]
[RequireComponent(typeof(DashBehaviour))]
public class WaterMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 200f;
    [SerializeField] float jumpForce = 10f;

    public GameObject jumpSpot;

    private bool grounded;

    private bool lastMoveRight;

    private Rigidbody2D rb;
    private Fighter frog;
    private LevelController levelController;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        frog = GetComponent<Fighter>();
        grounded = true;

        jumpSpot = GameObject.FindGameObjectWithTag("JumpSpot");
        levelController = GameObject.FindObjectOfType<LevelController>();
    }

    void FixedUpdate() {
        float moveHorizontal = Input.GetAxis(frog.HorizontalAxisName());

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
            Invoke("JumpFromSpot", 2);
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        switch(collision.transform.tag) {
            case "Ground":
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
        Debug.Log(gameObject.transform.position);
        rb.velocity = Vector2.zero;
        rb.AddForce(Vector2.up*10, ForceMode2D.Impulse);
        Invoke("ResetCollider", 2f);
    }

    void ResetCollider()
    {
        gameObject.GetComponentInChildren<Collider2D>().enabled = true;
    }
}
