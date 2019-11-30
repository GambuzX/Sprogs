using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterBehaviour : MonoBehaviour
{
    [SerializeField] float fireRate = 1f;

    public GameObject projectilePrefab;
    
    private bool shootLock;
    // Start is called before the first frame update
    void Start()
    {
        shootLock = false;        
    }

    // Update is called once per frame
    void Update()
    {
        if (!shootLock && Input.GetButton("FrolienFire")) {
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
        projectileComp.setDirection(direction);
        projectileComp.setOrientation(lastMoveRight);

        Invoke("UnlockShoot", fireRate);
    }

    void UnlockShoot() {
        shootLock = false;
    }
}
