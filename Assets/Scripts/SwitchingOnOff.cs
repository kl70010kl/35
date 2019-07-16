using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchingOnOff : MonoBehaviour
{
    private GameObject switchParent;
    private SwitchController switchController;

    // Start is called before the first frame update
    void Start()
    {
        switchParent = transform.root.gameObject;
        switchController = switchParent.GetComponent<SwitchController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Block")
        {
            if (switchController.HitTop(collision.gameObject.transform.position))
            {
                switchController.SwitchOn();
            }
        }
    }
}
