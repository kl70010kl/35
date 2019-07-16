using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DroneController : MonoBehaviour
{
    public float speed = 3.0f;
    Rigidbody2D rd;
    public GameObject block;
    private int blockCreateCount;
    public GameObject camera;

    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
        //blockCreateCount = 0;
        blockCreateCount = Block.blockCount;
    }

    // Update is called once per frame
    void Update()
    {
        blockCreateCount = Block.blockCount;
        if (blockCreateCount <= 2)
        {
            if (Input.GetKeyDown(KeyCode.B))
            {
                Instantiate(block, transform.position + new Vector3(0, -0.16f, 0), transform.rotation);
                blockCreateCount++;
            }
        }
    }

    private void FixedUpdate()
    {
        float droneCameraPos = this.transform.position.x - camera.transform.position.x;
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.RightArrow) && droneCameraPos == 0)
        {
            h = 1;

        }
        else if (Input.GetKey(KeyCode.LeftArrow) && droneCameraPos == 0)
        {
            h = -1;
        }
        else
        {
            h = 0;
        }

        if (Input.GetKey(KeyCode.UpArrow) && droneCameraPos == 0)
        {
            v = 1;
        }

        else if (Input.GetKey(KeyCode.DownArrow) && droneCameraPos == 0)
        {
            v = -1;
        }
        else
        {
            v = 0;
        }



        rd.velocity = new Vector3(h * speed, v * speed, 0);
    }
}
