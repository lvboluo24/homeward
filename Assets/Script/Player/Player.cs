using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 状态枚举
public enum PlayerState
{
    Idle, Run, Jump, Fall, Climb
}
public class Player : MonoBehaviour
{
    [Tooltip("玩家速度")]
    public float speed;

    [Tooltip("玩家跳跃高度")]
    public float jump;

    [Tooltip("玩家攀爬速度")]
    public float climbSpeed;

    [Tooltip("射线向下长度")]
    public float rayDownLength = 0.3f;

    [Tooltip("左右移动输入值")]
    public float horizontalInput;
    [Tooltip("上下移动输入值")]
    public float verticalInput;

    [Tooltip("是否在地")]
    public bool _isGrounded;

    [Tooltip("射线起点偏移")]
    public Vector2 rayOffset;

    private float scaleScale;//玩家原缩放比例

    [Tooltip("是否在梯子")]
    public bool _isLadder;

    [Tooltip("是否跳跃")]
    public bool _isJump;




    private Rigidbody2D rb;
    public PlayerState currentState;

    void Start()
    {

    }
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        //获取玩家缩放比例
        scaleScale = transform.localScale.x;
    }


    void Update()
    {
        //移动检测
        HandleMovement();
        // 左右移动时，玩家方向改变
        if (horizontalInput > 0.1f)
        {

            transform.localScale = new Vector3(-scaleScale * 1f, transform.localScale.y, transform.localScale.z);
        }
        else if (horizontalInput < -0.1f)
        {
            transform.localScale = new Vector3(scaleScale * 1f, transform.localScale.y, transform.localScale.z);
        }
        // 状态机更新，射线画线
        UpdateStateMachine();
        CheckGroundByTag();
    }
    public void HandleMovement()
    {
        //左右上下移动控制
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        //空格跳跃控制
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_isGrounded)
            {
                _isJump = true;
            }
        }

        //重力控制
        if (_isLadder)
        {
            rb.gravityScale = 0;
        }
        else
        {
            rb.gravityScale = 3;
        }
    }
    void FixedUpdate()
    {


        //左右移动控制
        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);
        //跳跃控制
       
            if (_isJump)
            {
                rb.velocity = new Vector2(rb.velocity.x, jump);
                _isJump = false;
            }
        
        
        //上爬梯子控制
        if (_isLadder)
        {
            rb.velocity = new Vector2(rb.velocity.x, verticalInput * climbSpeed);
            
        }


    }


    //如果玩家接触到tag为Ladder的碰撞体，切换状态为Climb,持续检测
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Ladder"))
        {
            _isLadder = true;
            Debug.Log("在梯子上");
        }
    }
    //如果玩家离开tag为Ladder的碰撞体，切换状态为Run
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ladder"))
        {
            _isLadder = false;
            Debug.Log("不在梯子上");
        }
    }

    void UpdateStateMachine()
    {
        switch (currentState)
        {
            case PlayerState.Idle:
                UpdateIdle();
                break;

            case PlayerState.Run:
                UpdateRun();
                break;

            case PlayerState.Jump:
                UpdateJump();
                break;

            case PlayerState.Fall:
                UpdateFall();
                break;
            case PlayerState.Climb:
                UpdateClimb();
                break;
        }
    }
    void SwitchState(PlayerState newState)
    {
        currentState = newState;
    }
    void UpdateIdle()
    {
        // 空闲状态逻辑
    }
    void UpdateRun()
    {
        // 运行状态逻辑
    }
    void UpdateJump()
    {
        // 跳跃状态逻辑
        if (rb.velocity.y < 0)
            SwitchState(PlayerState.Fall);
    }
    void UpdateFall()
    {
        //


    }
    void UpdateClimb()
    {

        // 爬状态逻辑
    }

    public void CheckGroundByTag()
    {
        // 计算射线起点
        Vector2 rayStart = (Vector2)transform.position + rayOffset;
        // 向下发射射线
        RaycastHit2D hit = Physics2D.Raycast(rayStart, Vector2.down, rayDownLength);

        // 有碰撞体 且 标签是Ground
        _isGrounded = hit.collider != null && hit.collider.CompareTag("Ground");
    }

    public void OnDrawGizmosSelected()
    {
        // 绘制射线
        Gizmos.color = Color.green;
        Vector2 start = (Vector2)transform.position + rayOffset;
        Vector2 end = start + Vector2.down * rayDownLength;
        Gizmos.DrawLine(start, end);
    }
}
