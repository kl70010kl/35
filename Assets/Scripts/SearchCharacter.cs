using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchCharacter : MonoBehaviour
{
    private GameObject enemy;
    private EnemyMove enemyMove;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        enemyMove = enemy.GetComponent<EnemyMove>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            enemyMove.SetEnemyState(EnemyMove.EnemyState.Chase);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            enemyMove.SetEnemyState(EnemyMove.EnemyState.Walk);
        }
    }
}
