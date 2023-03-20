using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float knockbackForce = 5;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if(collision.contacts.Length > 0)
            {
                ContactPoint2D contact = collision.contacts[0];
                //contact point.normal value will be between 1 and -1
                if(Vector2.Dot(contact.normal, Vector2.down) >= 0.9f)
                {
                    Destroy(gameObject);
                }
                else
                {
                    Rigidbody2D playerRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();
                    playerRigidbody.AddForce(-contact.normal * knockbackForce, ForceMode2D.Impulse);
                }
            }
        }
    }
}
