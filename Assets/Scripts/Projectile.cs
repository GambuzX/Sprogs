using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SelfDestruct", 8f);
    }
    
    void SelfDestruct() {
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
}
