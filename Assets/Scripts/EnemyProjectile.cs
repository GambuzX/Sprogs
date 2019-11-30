using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("SelfDestruct", 8f);
    }
    
    void SelfDestruct() {
        Destroy(this.gameObject);
    }
}
