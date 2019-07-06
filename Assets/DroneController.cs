using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneController : MonoBehaviour
{
    public float speed = 3.0f;
    Rigidbody2D rd;
    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.RightArrow))
        {
            h = 1;
            
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            h = -1;
        }
        else
        {
            h = 0;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            v = 1;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
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
