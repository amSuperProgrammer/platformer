using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]float speed;
    float horizontalInput;
    Rigidbody2D playerRigidbody;
    Collider2D isGrounded;
    int platformLayer = 1 << 3;

    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapBox(new Vector2(transform.position.x, transform.position.y - (transform.localScale.y / 2)), new Vector2(transform.localScale.x / 2, 0), 0, platformLayer);
        horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector2.right * Time.deltaTime * horizontalInput * speed);

        if(Input.GetKeyDown(KeyCode.W) && isGrounded != null)
            playerRigidbody.AddForce(Vector2.up * 5, ForceMode2D.Impulse);

        if (Physics2D.OverlapBox(new Vector2(transform.position.x + (transform.localScale.x / 2), transform.position.y), new Vector2(0, transform.localScale.y), 0, platformLayer) && isGrounded == null)
            playerRigidbody.AddForce(new Vector2(-horizontalInput / 10, 0), ForceMode2D.Impulse);

        if (Physics2D.OverlapBox(new Vector2(transform.position.x - (transform.localScale.x / 2), transform.position.y), new Vector2(0, transform.localScale.y), 0, platformLayer) && isGrounded == null)
            playerRigidbody.AddForce(new Vector2(-horizontalInput / 10, 0), ForceMode2D.Impulse);
    }
}
