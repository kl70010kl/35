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

    private void Start()
    {
        //初期化処理
        timer = 0;
        isRight = true;
        rd2DEnemy = GetComponent<Rigidbody2D>();
        state = EnemyState.Walk;
        velocityDirection = Vector2.zero;
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
        print(rd2DEnemy.velocity);
        print(state);
    }

    private void FixedUpdate()
    {
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
            velocityDirection.x = player.transform.position.x - gameObject.transform.position.x;
            
            if(velocityDirection.x >= 0)
            {
                velocityDirection.x = 1;
            }
            else if(velocityDirection.x < 0)
            {
                velocityDirection.x = -1;
            }

            //velocityをchaseVelocityに
            rd2DEnemy.velocity = new Vector2(0.5f * velocityDirection.x, 0);
        }
    }

    public void SetEnemyState(EnemyState state)
    {
        this.state = state;
    }

}

