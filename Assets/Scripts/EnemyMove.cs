using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    //エネミーの状態
    public enum EnemyState
    {
        Walk,
        Wait,
        Chase,
    };

    //エネミーのリジッドボディ
    Rigidbody2D rd2DEnemy;
    //左右移動切り替えようタイマー
    private float timer;
    //現在の移動方向が右向きかどうか
    private bool isRight;
    //エネミーの状態用State
    private EnemyState state;
    //追いかけるターゲット
    public GameObject player;
    //追いかける速度
    private Vector2 velocityDirection;
    //プレイヤーとエネミーの距離
    private float distance;

    public GameObject WarningSliderCtr;
    private WarnigUI warnigUI;

    float enemyVel;

    private void Start()
    {
        //初期化処理
        timer = 0;
        isRight = true;
        rd2DEnemy = GetComponent<Rigidbody2D>();
        state = EnemyState.Walk;
        velocityDirection = Vector2.zero;
        rd2DEnemy.constraints = RigidbodyConstraints2D.FreezeRotation;
        warnigUI = WarningSliderCtr.GetComponent<WarnigUI>();

        enemyVel = WarnigUI.enemySpeed;
    }

    private void Update()
    {
        if (state == EnemyState.Walk)
        {
            //タイマーを動かす
            timer += Time.deltaTime;

            //2秒以上になったら、
            if (timer >= 2.0f)
            {
                //右向きかどうかのフラグを反転
                isRight = !isRight;
                //タイマーを0に
                timer = 0;
            }
            
        }
        //画像が回転しなようにRotationを固定
        transform.localRotation = new Quaternion(0,0,0,0);

        distance = Vector2.Distance(player.transform.position, transform.position);
        if (state == EnemyState.Chase)
        {
            if (distance >= 1.5f)
            {
                state = EnemyState.Walk;
            }
        }
    }

    private void FixedUpdate()
    {
        enemyVel = WarnigUI.enemySpeed;

        //現在の状態がWalkなら、
        if (state == EnemyState.Walk)
        {
            //現在が右向き移動なら、
            if (isRight)
            {
                //右向きにvelocityをする
                rd2DEnemy.velocity = new Vector2(0.5f, 0);
            }
            //左向き移動なら、
            else
            {
                //左向きにvelocityをする
                rd2DEnemy.velocity = new Vector2(-0.5f, 0);
            }
        }
        //現在の状態がChaseなら
        if(state == EnemyState.Chase)
        {
            //プレイヤーとエネミーの位置からおおよその向きを計算
            velocityDirection.x = gameObject.transform.position.x - player.transform.position.x;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(player.transform.position - transform.position), 0.3f);
            if(velocityDirection.x >= 0)
            {
                //rd2DEnemy.position += Vector2.left / 100;
                rd2DEnemy.position += Vector2.left / (150 - enemyVel);
            }
            else if(velocityDirection.x < 0)
            {
                //rd2DEnemy.position += Vector2.right / 100;
                rd2DEnemy.position += Vector2.right / (150 - enemyVel);
            }
        }
    }

    public void SetEnemyState(EnemyState state)
    {
        this.state = state;
    }

    public EnemyState GetEnemyState()
    {
        return state;
    }
}

