using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;

    public float movementSpeed;

    Vector3 direction;
    bool isMovingToEnd = true;

    void Update()
    {
        if (isMovingToEnd)
        {
            direction = endPoint.position - transform.position;

            if (Vector2.Distance(transform.position, endPoint.position) <= 0.25f)
            {
                isMovingToEnd = false;
            }
        }
        else
        {
            direction = startPoint.position - transform.position;

            if (Vector2.Distance(transform.position, startPoint.position) <= 0.25f)
            {
                isMovingToEnd = true;
            }
        }

        direction.Normalize();
        transform.position += direction * movementSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(null);
        }
    }
}
