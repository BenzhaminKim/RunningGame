using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBody : MonoBehaviour
{
    public float speed = 5f;
    public float moveHorizontal;
    public float moveVertical = 0f;
    public float jumpSpeed = 5f;
    private Rigidbody2D rigidbody;
    public Transform groundCheckPoint;
    public float groundCheckRadius;
    public LayerMask groundLayer;

    private bool isTouchingGround;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveUpDown();
        Jump();
    }
    void DashUpDown()
    {
        if (Input.GetButton("Jump"))
        {
            if (moveHorizontal != 0)
            {
                rigidbody.velocity = new Vector2(moveHorizontal * speed * jumpSpeed, rigidbody.velocity.y);
            }
            if (moveVertical != 0)
            {
                rigidbody.velocity = new Vector2(rigidbody.velocity.x, moveVertical * speed * jumpSpeed);
            }
        }
    }
    
    void Jump()
    {
        isTouchingGround = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundLayer);
        //Debug.Log(isTouchingGround);
        if (Input.GetButton("Jump") && isTouchingGround)
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpSpeed);
        }
    }
    void MoveUpDown()
    {
        rigidbody.velocity = new Vector2(moveHorizontal * speed, rigidbody.velocity.y);

       
    }
}
