using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialBlock : MonoBehaviour
{
    public int hitsAllowed = 3;
    int currentHits;
    public Sprite usedSprite;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if(collision.contacts.Length > 0)
            {
                ContactPoint2D contactPoint = collision.contacts[0];

                if(Vector2.Dot(contactPoint.normal, Vector2.up) >= 0.9f)
                {
                    currentHits++;

                    if(currentHits < hitsAllowed)
                    {
                        //give player points, spawn new item, play sound effect, etc.
                    }
                    else
                    {
                        GetComponent<SpriteRenderer>().sprite = usedSprite;
                    }
                }
            }
        }
    }
}
