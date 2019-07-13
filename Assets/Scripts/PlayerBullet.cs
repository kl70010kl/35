using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public GameObject bullet;
    public GameObject player;
    private bool isCreate;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        isCreate = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (isCreate == false)
            {
                CreateBullet();
                isCreate = true;
            }
        }

        if (isCreate)
        {
            timer += Time.deltaTime;
            if(timer >= 1.0f)
            {
                isCreate = false;
                timer = 0;
            }
        }
    }

    

    public void CreateBullet()
    {
        Instantiate(bullet, player.transform.position, player.transform.rotation);
    }
}
