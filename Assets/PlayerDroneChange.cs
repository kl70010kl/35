using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDroneChange : MonoBehaviour
{
    private GameObject player;
    public GameObject drone;
    private MoveCharacterAction characterAction;
    private bool isPlayer;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        characterAction = player.GetComponent<MoveCharacterAction>();
        isPlayer = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            isPlayer = !isPlayer;
            if (isPlayer)
            {
                PlayerMove();
                print(0);
            }
            else if (isPlayer == false)
            {
                DroneCreate();
                print(1);
            }
        }
        

    }

    void DroneCreate()
    {
        drone.SetActive(true);
        drone.transform.position = player.transform.position + new Vector3(1, 0, 0);
        characterAction.SetIsMove(false);
        
    }

    void PlayerMove()
    {
        characterAction.SetIsMove(true);
        drone.SetActive(false);
    }
}
