using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Block : MonoBehaviour
{
    private Rigidbody2D rd2DBlock;
    float timer;
    public static int blockCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        rd2DBlock = GetComponent<Rigidbody2D>();
        blockCount++;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer>5)
        {
            blockCount--;
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Stage") ||
            collision.gameObject.CompareTag("Block"))
        {
            rd2DBlock.constraints = RigidbodyConstraints2D.FreezePositionX;
        }
    }
}
