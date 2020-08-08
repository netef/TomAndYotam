using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript2D : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer spriteRenderer;
    private float x;
    private float velocity;
    private int coinCounter;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        velocity = 20;
        coinCounter = 0;
    }

    void Update()
    {
        x = Input.GetAxisRaw("Horizontal");
        anim.SetFloat("velocity", Mathf.Abs(rb.velocity.x));
        if (rb.velocity.x != 0)
            if (transform.localScale.x < 0 && rb.velocity.x < 0)
                transform.localScale = new Vector3(transform.localScale.x * rb.velocity.normalized.x, transform.localScale.y, transform.localScale.z);
            else if (transform.localScale.x > 0 && rb.velocity.x > 0)
                transform.localScale = new Vector3(transform.localScale.x * -rb.velocity.normalized.x, transform.localScale.y, transform.localScale.z);
    }
    void FixedUpdate() => rb.velocity = new Vector2(x, rb.velocity.y) * velocity;
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Collectible"))
        {
            Destroy(collider.gameObject);
            coinCounter++;
            if (coinCounter == 10)
                SceneManager.LoadScene("Level2");
        }
    }
}
