using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    private GameObject player;
    Rigidbody2D rd2DBullet;
    private MoveCharacterAction characterAction;
    private Vector2 bulletVelocity;

    // Start is called before the first frame update
    void Start()
    {
        rd2DBullet = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        characterAction = player.GetComponent<MoveCharacterAction>();
        bulletVelocity = new Vector2(1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if ((characterAction.GetGunDirection() == MoveCharacterAction.GunDirection.Right) &&
            (characterAction.IsJump() == false))
        {
            bulletVelocity = new Vector2(1, 0);
        }
        if ((characterAction.GetGunDirection() == MoveCharacterAction.GunDirection.Right) &&
            (characterAction.IsJump() == true))
        {
            bulletVelocity = new Vector2(1, -1);
            bulletVelocity.Normalize();
        }
        if ((characterAction.GetGunDirection() == MoveCharacterAction.GunDirection.Left) &&
            (characterAction.IsJump() == false))
        {
            bulletVelocity = new Vector2(-1, 0);
        }
        if ((characterAction.GetGunDirection() == MoveCharacterAction.GunDirection.Left) &&
            (characterAction.IsJump() == true))
        {
            bulletVelocity = new Vector2(-1, -1);
            bulletVelocity.Normalize();
        }

    }

    private void FixedUpdate()
    {
        rd2DBullet.velocity = bulletVelocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
