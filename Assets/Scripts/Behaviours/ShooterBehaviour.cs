using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Fighter))]
public class ShooterBehaviour : MonoBehaviour
{
    [SerializeField] float fireRate = 1f;
    [SerializeField] bool usePhysics = false;

    public GameObject projectilePrefab;
    
    private bool shootLock;

    private Fighter frog;
    private Transform ShootingPosition;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        shootLock = false;
        frog = GetComponent<Fighter>();
        ShootingPosition = transform.Find("ShootingPosition").transform;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!shootLock && Input.GetButton(frog.FireButtonName())) {
            animator.SetTrigger("Shoot");
            SpawnProjectile();
        }            
    }

    void SpawnProjectile() {

        shootLock = true;

        bool lastMoveRight = transform.eulerAngles.y == 0;
        Vector2 direction = lastMoveRight ? Vector2.right : Vector2.left;

        GameObject projectile = Instantiate(projectilePrefab, ShootingPosition.position, projectilePrefab.transform.rotation);
        Projectile projectileComp = projectile.GetComponent<Projectile>();
        projectileComp.setSpeed(8f);
        projectileComp.setOrientation(lastMoveRight);
        projectileComp.setOrigin(frog.GetType().ToString());

        if(usePhysics) projectileComp.applyForce();
        else projectileComp.applyVelocity();

        Invoke("UnlockShoot", fireRate);
    }

    void UnlockShoot() {
        shootLock = false;
    }
}
