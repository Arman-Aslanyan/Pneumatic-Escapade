using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Internal is public, but its hidden in Unity
    internal Rigidbody2D rb;
    internal Collider2D collider;
    public float moveSpeed = 5f;
    //private Animator animator;
    private Vector2 movement;
    public bool canMove = true;
    public float dashTime;
    private ParticleSystem iFrameSmoke;

    internal Combat combat;

    // Start is called before the first frame update
    void Start()
    {
        combat = GetComponent<Combat>();
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
        //animator = GetComponent<Animator>();
        iFrameSmoke = GetComponent<ParticleSystem>();
    }

    // Update called once per frame
    void Update()
    {
        if (canMove)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            if (!movement.Equals(Vector2.zero))
            {
                var targetPos = transform.position;
                targetPos.x += movement.x;
                targetPos.y += movement.y;

                transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            }

        }

        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            combat.SetI_Frames(true);
            float time = 0;
            time += Time.deltaTime;

            iFrameSmoke.Play();

            if (time >= dashTime)
            {
                combat.SetI_Frames(false);
            }
        }

        //animator.SetFloat("Horizontal", movement.x);
        //animator.SetFloat("Vertical", movement.y);
        //animator.SetFloat("Speed", movement.sqrMagnitude);
    }
}
