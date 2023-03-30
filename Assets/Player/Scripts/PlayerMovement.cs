using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Internal is public, but its hidden in Unity
    internal Rigidbody2D rb;

    //Movement & dashing
    public float moveSpeed = 5f;
    private Vector2 movement;
    public bool canMove = true;
    public float dashTime;
    public float dashCooldown;
    public bool canDash = true;
    private float time = 0;
    private Coroutine coroutineInstance; //Prevents the dashCooldown coroutine from running more than once at a time

    public ParticleSystem iFrameSmoke;

    internal Combat combat;
    private Animator animator;
    private SpriteRenderer spRend;

    public static PlayerMovement Instance;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        combat = GetComponent<Combat>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spRend = GetComponent<SpriteRenderer>();
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
        if (canDash)
        {
            if (Input.GetKey(KeyCode.LeftShift) && time <= dashTime)
            {
                time += Time.deltaTime;
                combat.SetI_Frames(true);
                iFrameSmoke.Play();
            }
            else if (time > dashTime)
                canDash = false;
        }
        else
        {
            //Makes the coroutine only run once, preventing a call everytime Update() is ran
            if (coroutineInstance == null)
                coroutineInstance = StartCoroutine(DashCooldown());
        }

        if (movement != Vector2.zero)
        {
            animator.SetTrigger("Walk");
        }
        else animator.SetTrigger("Idle");
        if (movement.x < 0)
            spRend.flipX = true;
        else spRend.flipX = false;
    }

    private IEnumerator DashCooldown()
    {
        combat.SetI_Frames(false);

        yield return new WaitForSeconds(dashCooldown);

        time = 0;
        canDash = true;
        coroutineInstance = null;
    }
}
