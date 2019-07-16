using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SearchCharacter : MonoBehaviour
{
    private GameObject enemy;
    private EnemyMove enemyMove;
    private float warningDigree;
    public GameObject warnngSliderCtr;
    private WarnigUI warnigUI;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        enemyMove = enemy.GetComponent<EnemyMove>();
        warningDigree = 12.5f;
        warnigUI = warnngSliderCtr.GetComponent<WarnigUI>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            enemyMove.SetEnemyState(EnemyMove.EnemyState.Chase);
            warnigUI.GetWarningDgree(warningDigree);
        }
    }
}
