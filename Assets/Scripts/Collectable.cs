using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Collider2D collider = GetComponent<Collider2D>();
            collider.enabled = false;
            Animator animator = GetComponent<Animator>();
            animator.Play("Collect");
        }
    }

    public void Remove()
    {
        Destroy(gameObject);
    }
}
