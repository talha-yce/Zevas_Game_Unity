
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    public float jumpForce = 10f; // Zýplama kuvveti

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D playerRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();

            if (playerRigidbody != null)
            {
                Vector2 jumpDirection = Vector2.up;
                playerRigidbody.velocity = jumpDirection * jumpForce;
            }
        }
    }
}
