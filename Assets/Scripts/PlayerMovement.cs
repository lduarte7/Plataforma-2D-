using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    float DirX;

    private SpriteRenderer player;

    public float speed = 7f;
    public float jumpForce = 14f;

    private BoxCollider2D coll;
    [SerializeField] private LayerMask jumpableGround;

    [SerializeField] private AudioSource jumpSound;

    private enum movementState { idle, run, jump, fall }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        player = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        DirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(DirX * speed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            jumpSound.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        UpdateAnimation();
    }

    private void UpdateAnimation()
    {
        movementState state;
        if (DirX > 0f)
        {
            state = movementState.run;
            player.flipX = false;
        }
        else if (DirX < 0f)
        {
            state = movementState.run;
            player.flipX = true;
        }
        else
        {
            state = movementState.idle;
        }

        if (rb.velocity.y > .1f)
        {
            state = movementState.jump;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = movementState.fall;
        }

        anim.SetInteger("state", (int)state);
    }

    private bool isGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);

    }


}
