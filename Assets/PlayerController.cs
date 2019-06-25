using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 3.0f;
    public float jumpForce = 10;
    private bool isJump;
    private Rigidbody2D rdPlayer;
    // Start is called before the first frame update
    void Start()
    {
        isJump = true;
        rdPlayer = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (isJump)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                rdPlayer.AddForce(Vector2.up * jumpForce,
                    ForceMode2D.Force);
                print(1);
            }
        }


        float h = Input.GetAxis("Horizontal");
        rdPlayer.velocity = new Vector2(speed * h,
        rdPlayer.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Stage"))
        {
            isJump = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Stage"))
        {
            isJump = false;
        }
    }
}
