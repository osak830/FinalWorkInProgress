using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    float xMove;
    Rigidbody2D rb;
    public float jumpSpeed;
    bool isJumping;
    bool canJump = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        xMove = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && canJump == true)
        {
            isJumping = true;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(xMove * speed * Time.deltaTime, rb.velocity.y);

        if (isJumping)
        {
            canJump = false;
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            isJumping = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {

            canJump = true;

        }

        if (collision.gameObject.tag == "Bell")
        {

            SceneManager.LoadScene("GameScene 2");


        }
    }

  /*  private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bell")
        {
            SceneManager.LoadScene("GameScene 2");

        }


    } */
}

