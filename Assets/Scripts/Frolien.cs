using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frolien : MonoBehaviour
{

    [SerializeField] float moveSpeed = 200f;
    [SerializeField] float fireRate = 1f;
    [SerializeField] float jumpForce = 6f;
    [SerializeField] float jumpCooldown = 1f;

    public GameObject projectilePrefab;
    private bool shootLock;
    private bool attackLock;
    private bool grounded;

    private bool lastMoveRight;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        grounded = true;
        shootLock = false;
        attackLock = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!shootLock && Input.GetButton("FrolienFire")) {
            SpawnProjectile();
        }
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

        if (!attackLock)
            rb.velocity = new Vector2(moveHorizontal * moveSpeed * Time.deltaTime, rb.velocity.y);

        if (grounded && Input.GetButton("FrolienJump")) {
            //animator.SetTrigger("jump");
            rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
            grounded = false;
            Invoke("UnlockJump", jumpCooldown);
        }
    }

    void SpawnProjectile() {

        shootLock = true;

        Vector2 direction = lastMoveRight ? Vector2.right : Vector2.left;

        GameObject projectile = Instantiate(projectilePrefab, this.transform.position, projectilePrefab.transform.rotation);
        Projectile projectileComp = projectile.GetComponent<Projectile>();
        projectileComp.setSpeed(8f);
        projectileComp.setDirection(direction);
        projectileComp.setOrientation(lastMoveRight);

        Invoke("UnlockShoot", fireRate);
    }

    void UnlockShoot() {
        shootLock = false;
    }

    void UnlockAttack() {
        attackLock = false;
    }

    void UnlockJump() {
        grounded = true;
    }
}
