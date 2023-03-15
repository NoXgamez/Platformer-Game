using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    public float jumpForce = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D body = collision.gameObject.GetComponent<Rigidbody2D>();
            if(transform.rotation.z != 0)
            {
                body.velocity = Vector2.zero;
            }
            else
            {
            body.velocity = new Vector2(body.velocity.x, 0);
            }
            body.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}
