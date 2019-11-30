using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] float moveSpeed = 1f;
    [SerializeField] float fireRate = 1f;

    public GameObject projectilePrefab;
    private bool shootLock;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        shootLock = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!shootLock && Input.GetButton("EnemyFire")) {
            SpawnProjectile();
        }
    }

    void FixedUpdate() {
        float horizontal = Input.GetAxis("HorizontalEnemy");
        float vertical = Input.GetAxis("VerticalEnemy"); 

        rb.velocity = new Vector2(horizontal * moveSpeed * Time.deltaTime, vertical * moveSpeed * Time.deltaTime);
    }

    void SpawnProjectile() {

        shootLock = true;

        Vector2 direction = new Vector2(0f, 1f);

        GameObject projectile = Instantiate(projectilePrefab, this.transform.position, Quaternion.identity);
        projectile.GetComponent<Rigidbody2D>().velocity = direction;

        Invoke("UnlockShoot", fireRate);
    }

    void UnlockShoot() {
        shootLock = false;
    }
}
