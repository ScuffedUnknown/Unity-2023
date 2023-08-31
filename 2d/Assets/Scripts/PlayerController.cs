using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float h;
    public float v;
    Vector2 dir;
    Rigidbody2D rb2d;
    Animator anim;
    SpriteRenderer spr;
    bool facingLeft = false;
    public float jumpForce;
    public Transform groundCheckPosition;
    public float groundCheckRadius;
    public LayerMask groundMask;


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(dir * Time.deltaTime * 10);
        FlipPlayer();
    }

    public void MovePlayer(InputAction.CallbackContext ctx)
    {
        h = ctx.ReadValue<Vector2>().x;
        v = ctx.ReadValue<Vector2>().y;

        dir = new Vector2(h, 0);
    }

    void FlipPlayer()
    {
        if (h > 0 && facingLeft || h < 0 && !facingLeft)
        {
            facingLeft = !facingLeft;
            spr.flipX = facingLeft;
        }
    }

    public void Jump(InputAction.CallbackContext ctx)
    {

        if (ctx.performed)
        {
            Debug.Log("Space");
            if (GroundCheck())
            {
                Debug.Log("Space Ground check");
                rb2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                anim.SetBool("IsFlying", true);
            }
        }
    }
    bool GroundCheck()
    {
        RaycastHit2D groundCheckHit = Physics2D.CircleCast(groundCheckPosition.position, groundCheckRadius, Vector2.down, groundCheckRadius, groundMask);
        return groundCheckHit.collider;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheckPosition.position, groundCheckRadius);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 3 && GroundCheck())
        {
            anim.SetBool("IsFlying", false);
        }

        if (collision.gameObject.CompareTag("Weight"))
        {
            anim.SetTrigger("IsDead");
        }
    }
}
