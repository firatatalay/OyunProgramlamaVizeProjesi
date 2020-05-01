using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class top : MonoBehaviour
{
    Rigidbody2D rb;
    public float moveSpeed = 10f;
    public oyuncu oyuncu;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("ikisaniye", 2);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<AudioSource>().Play();
    }

    void ikisaniye()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(1, 0) * moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        oyuncu.SkorYap();
    }
}
