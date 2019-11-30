using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Fighter))]
public class DashBehaviour : MonoBehaviour
{
    [SerializeField] private Transform dashEffect;
    [SerializeField] float dashDistance = 300f;

    private float direction = 1;

    private bool dashLock;
    private Fighter frog;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        dashLock = false;
        frog = GetComponent<Fighter>();

        rb = frog.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!dashLock && Input.GetButton(frog.DashButtonName()))
        {
            float moveHorizontal = Input.GetAxis(frog.HorizontalAxisName());
            if (moveHorizontal > 0)
            {
                direction = 1f;
            }
            else if (moveHorizontal < 0)
            {
                direction = -1f;
            }

            Vector3 beforeDashPosition = transform.position;
            rb.AddForce(new Vector2(direction * dashDistance, 0), ForceMode2D.Impulse);
            Transform dashEffectTransform = Instantiate(dashEffect, beforeDashPosition, Quaternion.identity);
            dashEffectTransform.eulerAngles = new Vector3(0, rb.transform.eulerAngles.y, 0);

            dashLock = true;

            Invoke("UnlockDash", 2);
        }
    }

    public void UnlockDash()
    {
        dashLock = false;
    }
}