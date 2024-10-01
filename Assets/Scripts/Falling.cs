using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling : MonoBehaviour
{
    private Rigidbody2D rb_body;

    private void Start()
    {
        rb_body = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Player")){

            Invoke("PlatformDrop", 0.5f);
            Destroy(gameObject, 1f);
        }
    }

    void PlatformDrop()
    {
        rb_body.isKinematic = false;
    }
}
