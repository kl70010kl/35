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

    private bool isMove;

    private bool isAttack;

    enum GunDirection
    {
        Right,
        Left,
    }

    GunDirection gunDirection;

    void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rig2d = GetComponent<Rigidbody2D>();

        isMove = true;
        isAttack = false;
        gunDirection = GunDirection.Right;
    }

    void Update()
    {
        float axis = Input.GetAxis("Horizontal");
        bool isDown = Input.GetAxisRaw("Vertical") < 0;

        if (isMove)
        {
            Vector2 velocity = rig2d.velocity;
            if (Input.GetButtonDown("Jump"))
            {
                velocity.y = 5;
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
                animator.SetTrigger("Gun");
            }

            

        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        animator.SetTrigger(hashDamage);
    }

    public void SetIsMove(bool isMove)
    {
        this.isMove = isMove;
    }
}
