using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Fighter))]
public class ShooterBehaviour : MonoBehaviour
{
    [SerializeField] float fireRate = 1f;

    public GameObject projectilePrefab;
    
    private bool shootLock;

    private Fighter frog;

    // Start is called before the first frame update
    void Start()
    {
        shootLock = false;
        frog = GetComponent<Fighter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!shootLock && Input.GetButton(frog.FireButtonName())) {
            SpawnProjectile();
        }            
    }

    void SpawnProjectile() {

        shootLock = true;

        bool lastMoveRight = transform.eulerAngles.y == 0;
        Vector2 direction = lastMoveRight ? Vector2.right : Vector2.left;

        GameObject projectile = Instantiate(projectilePrefab, this.transform.position, projectilePrefab.transform.rotation);
        Projectile projectileComp = projectile.GetComponent<Projectile>();
        projectileComp.setSpeed(8f);
        projectileComp.setOrientation(lastMoveRight);
        projectileComp.setOrigin(frog.GetType().ToString());
        projectileComp.applyForce();
        Invoke("UnlockShoot", fireRate);
    }

    void UnlockShoot() {
        shootLock = false;
    }
}
