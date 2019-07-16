using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour
{
    public List<GameObject> enemys; //スイッチを押したときに動きを止めるエネミー
    private GameObject switchOff; //スイッチオフ状態のオブジェクト
    private GameObject switchOn; //スイッチオン状態のオブジェクト
    private Rigidbody2D rd2DSwitchOn;
    private Rigidbody2D rd2DSwitchOff;

    //スイッチの状態
    public enum SwitchState
    {
        On,
        Off,
    }

    private SwitchState switchState;

    // Start is called before the first frame update
    void Start()
    {
        //子オブジェクトからスイッチのオブジェクトを取得
        switchOn = transform.GetChild(0).gameObject;
        switchOff = transform.GetChild(1).gameObject;
        //子オブジェクトのアクティブ（初期状態はオフのオブジェクトがアクティブ）
        switchOn.SetActive(false);
        switchOff.SetActive(true);
        //スイッチの状態（初期状態はオフ）
        switchState = SwitchState.Off;
        //各スイッチのリジッドボディ取得
        rd2DSwitchOn = switchOn.GetComponent<Rigidbody2D>();
        rd2DSwitchOff = switchOff.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(switchState == SwitchState.On)
        {
            EnemyStop();
        }
    }
    

    public bool HitTop(Vector2 otherPos)
    {
        float positionX = otherPos.x - gameObject.transform.position.x;
        float positionY = otherPos.y - gameObject.transform.position.y;
        print(positionX);
        if (positionY >= 0 &&
            (positionX < 0.4f &&
            positionX > -0.2f))
        {
            return true;
        }
        return false;
    }

    public void SwitchOn()
    {
            if (switchState == SwitchState.Off)
            {
                switchOff.SetActive(false);
                rd2DSwitchOn.position = rd2DSwitchOff.position;
                switchOn.SetActive(true);
                switchState = SwitchState.On;
            }
    }

    private void EnemyStop()
    {
        if(switchState == SwitchState.On)
        {
            foreach(var enemy in enemys)
            {
                EnemyMove enemyMove = enemy.GetComponent<EnemyMove>();
                enemyMove.SetEnemyState(EnemyMove.EnemyState.Stop);
            }
        }
    }
}
