using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Fighter))]
[RequireComponent(typeof(AudioSource))]
public class DashBehaviour : MonoBehaviour
{
    [SerializeField] private Transform dashEffect;
    [SerializeField] float dashDistance = 5f;

    public AudioClip dashSound;

    private float direction = 1;

    private bool dashLock;
    private Fighter frog;

    private Rigidbody2D rb;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        dashLock = false;
        frog = GetComponent<Fighter>();

        rb = frog.gameObject.GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
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

            audioSource.clip = dashSound;
            audioSource.Play();

            float maxDashDistance = GetMaxDashDistance(beforeDashPosition);
            frog.transform.Translate(new Vector2(maxDashDistance, 0));
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

    private float GetMaxDashDistance(Vector3 beforeDashPosition)
    {
        float maxDashDistance = dashDistance;

        if(direction == 1)
        {
            Vector3 startPosition = new Vector3(beforeDashPosition.x+1f, beforeDashPosition.y, 0);
            RaycastHit2D hit = Physics2D.Raycast(startPosition, new Vector2(1, 0), dashDistance);
            if(hit.collider != null)
            {
                maxDashDistance = hit.distance;
            }
        }
        else if(direction == -1)
        {
            Vector3 startPosition = new Vector3(beforeDashPosition.x-1f, beforeDashPosition.y, 0);
            RaycastHit2D hit = Physics2D.Raycast(startPosition, new Vector2(-1, 0), dashDistance);
            if (hit.collider != null)
            {
                maxDashDistance = hit.distance;
            }
        }
        
        return maxDashDistance;
    }
}