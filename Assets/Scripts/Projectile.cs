﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{    
    private float speed = 1f;
    private float damage = 10f;

    private string origin = "";
    private bool moveRight = true;

    private Rigidbody2D rb;
    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    public void SelfDestruct() {
        Destroy(this.gameObject);
    }

    public void applyVelocity() {
        rb.gravityScale = 0;
        rb.velocity = (moveRight ? Vector2.right : Vector2.left) * speed;
    }

    public void applyForce() {
        Vector2 direction = (Vector2.up + (moveRight ? Vector2.right : Vector2.left)).normalized;
        rb.AddForce(direction * speed, ForceMode2D.Impulse);
    }

    public void setSpeed(float speed) {
        this.speed = speed;
    }

    public void setOrientation(bool right) {
        moveRight = right;        
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, (right ? 0f : 180f), transform.eulerAngles.z);
    }

    public void setOrigin(string origin) {
        this.origin = origin;
    }

    public string getOrigin() {
        return origin;
    }

    public float getDamage() {
        return damage;
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if (!collider.GetComponentInParent<Fighter>()){
            SelfDestruct();
        }
    }
}
