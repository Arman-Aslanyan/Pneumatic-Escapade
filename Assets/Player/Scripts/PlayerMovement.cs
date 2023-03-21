using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Internal is public, but its hidden in Unity
    internal Rigidbody2D rb;
    internal Collider2D collider;

    //Movement & dashing
    public float moveSpeed = 5f;
    private Vector2 movement;
    public bool canMove = true;
    public float dashTime;
    public float dashCooldown;
    public bool canDash = true;
    private float time = 0;

    public ParticleSystem iFrameSmoke;

    internal Combat combat;
    //private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        combat = GetComponent<Combat>();
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
        //animator = GetComponent<Animator>();
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
        
        //Dashing
        if (canDash && time <= dashTime / 2 && Input.GetKey(KeyCode.LeftShift))
        {
            combat.SetI_Frames(true);
            iFrameSmoke.Play();

            time += Time.deltaTime;
        }
        else
        {
            combat.SetI_Frames(false);
            canDash = false;
            StartCoroutine(DashCooldown());
        }

        //animator.SetFloat("Horizontal", movement.x);
        //animator.SetFloat("Vertical", movement.y);
        //animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    private IEnumerator DashCooldown()
    {
        yield return new WaitForSeconds(dashCooldown/2);

        time = 0;
        canDash = true;
    }
}
