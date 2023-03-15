using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float movementSpeed;
    public float jumpForce;
    float horizontal, vertical;

    private Rigidbody2D body;
    Vector2 horizontalForce, verticalForce;
    bool isOnGround;
    public float maxSlope = 0.5f;
    public int maxJumps = 2;
    int currentJumps;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        verticalForce.y = jumpForce;
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        horizontalForce.x = horizontal * movementSpeed * Time.deltaTime;

        body.AddForce(horizontalForce);

        if(Input.GetKeyDown(KeyCode.Space) && CanJump())
        {
            if (currentJumps < maxJumps)
            {
                body.AddForce(verticalForce, ForceMode2D.Impulse);
                isOnGround = false;
                currentJumps++;
            }
        }
    }

    bool CanJump()
    {
        return isOnGround || currentJumps < maxJumps;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        CheckIfOnGround(collision);
    }

    void CheckIfOnGround(Collision2D collision)
    {
        if (!isOnGround)
        {
            if (collision.contacts.Length > 0)
            {
                ContactPoint2D contact = collision.contacts[0];
                //how close does the normal match the up direction
                float dot = Vector2.Dot(contact.normal, Vector2.up);

                isOnGround = dot >= maxSlope;

                if(isOnGround)
                    currentJumps = 0;
            }
        }
    }
}