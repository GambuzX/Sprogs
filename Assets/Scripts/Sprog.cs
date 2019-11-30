using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprog : MonoBehaviour
{

    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if(horizontal != 0 || vertical != 0)
        {
            for(int i = 0; i < Input.GetJoystickNames().Length; i++)
            {
                Debug.Log(i);
            }
        }
 
        if (horizontal < 0)
        {
            this.gameObject.transform.Translate(new Vector3(-1, 0, 0)*speed);
        }
        else if(horizontal > 0)
        {
            this.gameObject.transform.Translate(new Vector3(1, 0, 0) * speed);
        }

        if(vertical < 0)
        {
            this.gameObject.transform.Translate(new Vector3(0, -1, 0) * speed);
        }
        else if (vertical > 0)
        {
            this.gameObject.transform.Translate(new Vector3(0, 1, 0) * speed);
        }
    }
}
