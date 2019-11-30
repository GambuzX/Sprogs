using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float speed = 1f;
    private float damage = 10f;
    
    private string origin;
    
    public void SelfDestruct() {
        Destroy(this.gameObject);
    }

    public void setDirection(Vector2 direction) {
        GetComponent<Rigidbody2D>().velocity = direction * speed;
    }

    public void setSpeed(float speed) {
        this.speed = speed;
    }

    public void setOrientation(bool right) {        
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
        if (!collider.GetComponentInParent<Fighter>())
            SelfDestruct();
    }
}
