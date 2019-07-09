using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject player;
    private MoveCharacterAction characterAction;
    public GameObject Drone;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        characterAction = player.GetComponent<MoveCharacterAction>();
    }

    // Update is called once per frame
    void Update()
    {
        if (characterAction.GetPlayerState() ==
            MoveCharacterAction.PlayerState.Active)
        {
            gameObject.transform.position = player.transform.position + new Vector3(0, 0, -1);
        }
        else if(characterAction.GetPlayerState() ==
            MoveCharacterAction.PlayerState.DroneControl)
        {
            gameObject.transform.position = Drone.transform.position + new Vector3(0, 0, -1);
        }
    }
}
