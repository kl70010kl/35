using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCharacterAction : MonoBehaviour
{
    static int hashSpeed = Animator.StringToHash("Speed");
    static int hashFallSpeed = Animator.StringToHash("FallSpeed");
    static int hashGroundDistance = Animator.StringToHash("GroundDistance");
    static int hashIsCrouch = Animator.StringToHash("IsCrouch");

    static int hashDamage = Animator.StringToHash("Damage");

    [SerializeField] private float characterHeightOffset = 0.2f;
    [SerializeField] LayerMask groundMask;

    [SerializeField, HideInInspector] Animator animator;
    [SerializeField, HideInInspector] SpriteRenderer spriteRenderer;
    [SerializeField, HideInInspector] Rigidbody2D rig2d;

    public int hp = 4;
    

    private bool isAttack; //攻撃したか
    private float AttackIntervalTimer; //攻撃間隔
    private float timer; //タイマー
    private bool isJump;
    
    //銃の撃つ向き
    public enum GunDirection
    {
        Right,
        Left,
    }

    public GunDirection gunDirection; //銃の向き
    
    //プレイヤーの状態
    public enum PlayerState
    {
        Active, //通常の状態
        DroneControl, //ドローン操作状態
        Stealth, //隠れている状態
    }

    PlayerState playerState; //プレイヤーの状態

    void Awake()
    {
        //初期化
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rig2d = GetComponent<Rigidbody2D>(); //リジッドボディ取得
        
        isAttack = false; //攻撃はしていないのでfalse
        gunDirection = GunDirection.Right; //初期状態は右向き
        playerState = PlayerState.Active; //初期状態は通常状態
        AttackIntervalTimer = 0.5f; //攻撃できるのは0.5秒間隔
        timer = AttackIntervalTimer; //攻撃間隔でタイマー初期化
        isJump = false;
    }

    void Update()
    {
        float axis = Input.GetAxis("Horizontal");
        bool isDown = Input.GetAxisRaw("Vertical") < 0;

        //Active(通常状態)ならプレイヤーに関する操作可
        if (playerState == PlayerState.Active)
        {
            Vector2 velocity = rig2d.velocity;
            if (Input.GetButtonDown("Jump"))
            {
                if (isJump == false)
                {
                    velocity.y = 5;
                    isJump = true;
                }
            }
            if (axis != 0)
            {
                spriteRenderer.flipX = axis < 0;
                velocity.x = axis * 2;
            }
            rig2d.velocity = velocity;

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                gunDirection = GunDirection.Right;
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                gunDirection = GunDirection.Left;
            }

            var distanceFromGround = Physics2D.Raycast(transform.position, Vector3.down, 1, groundMask);

            // update animator parameters
            animator.SetBool(hashIsCrouch, isDown);
            animator.SetFloat(hashGroundDistance, distanceFromGround.distance == 0 ? 99 : distanceFromGround.distance - characterHeightOffset);
            animator.SetFloat(hashFallSpeed, rig2d.velocity.y);
            animator.SetFloat(hashSpeed, Mathf.Abs(axis));
            if (Input.GetKeyDown(KeyCode.C))
            {
                if (isAttack == false)
                {
                    animator.SetTrigger("Gun");
                    isAttack = true;
                }
            }

            if (isAttack)
            {
                timer -= Time.deltaTime;
            }

            if(timer <= 0)
            {
                isAttack = false;
                timer = AttackIntervalTimer;
            }

        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        animator.SetTrigger(hashDamage);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Stage"))
        {
            isJump = false;
        }
    }

    public void SetPlayerState(PlayerState state)
    {
        playerState = state;
    }

    public PlayerState GetPlayerState()
    {
        return playerState;
    }

    public GunDirection GetGunDirection()
    {
        return gunDirection;
    }

    public bool IsJump()
    {
        return isJump;
    }
}
