using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVals : MonoBehaviour
{
    public GameObject obj;
    public PlayerMovement movement;
    public Transform trans;
    public Rigidbody2D rb;
    public Collider2D coll;

    public PlayerVals()
    {
        obj = gameObject;
        movement = obj.GetComponent<PlayerMovement>();
        trans = obj.transform;
        rb = obj.GetComponent<Rigidbody2D>();
        coll = obj.GetComponent<Collider2D>();
    }
}

public class PlayerMovement : MonoBehaviour
{
    //Internal is public, but its hidden in Unity
    internal Rigidbody2D rb;
    internal Collider2D collider;

    public float moveSpeed = 5f;
    //private Animator animator;
    private Vector2 movement;
    public bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
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
        //animator.SetFloat("Horizontal", movement.x);
        //animator.SetFloat("Vertical", movement.y);
        //animator.SetFloat("Speed", movement.sqrMagnitude);
    }
}
