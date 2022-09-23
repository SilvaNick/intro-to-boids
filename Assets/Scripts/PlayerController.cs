using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;

    private float moveSpeed = 3f;
    private float jumpForce = 60f;
    private bool isJumping = false;
    private float moveHorizontal;
    private float moveVertical;
    private bool jumpButton;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");

    }

    private void FixedUpdate()
    {
        if (moveHorizontal >  0.1f || moveHorizontal < -0.1f)
        {
            rb2d.AddForce(new Vector2(moveHorizontal * moveSpeed, 0), ForceMode2D.Impulse);
        }
        if (moveVertical > 0.1f && !isJumping)
        {
            rb2d.AddForce(new Vector2(0, moveVertical * jumpForce), ForceMode2D.Impulse);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Platform"))
        {
            isJumping = false;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Platform"))
        {
            isJumping = true;
        }
    }
}
