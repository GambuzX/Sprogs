using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] float moveSpeed = 1f;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate() {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        //print(horizontal);
        //print(vertical);

        rb.velocity = new Vector2(horizontal * moveSpeed * Time.deltaTime, vertical * moveSpeed * Time.deltaTime);
    }

    void OnCollisionStay2D(Collision2D collision) {
        print("collision");
    }

    void OnTriggerStay2D(Collider2D collider) {
        print("trigger");
    }
}
