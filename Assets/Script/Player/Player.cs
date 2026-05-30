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

    [Tooltip("地面层掩码")]
    public LayerMask groundLayer;
    [Tooltip("是否死亡")]
    public bool _isDead;
    [Tooltip("是否在移动平台")]
    public bool _isMovingGround;
[Tooltip("当前移动平台")]
private Transform _currentPlatform;
    private float _lastPlatformX;
    public PlayerState currentState;

public PlayerAnim playerAnim;
    public Rigidbody2D rb;
    public Sound sound;
    private Game game;


    void Start()
    {

    }
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        game = GameObject.Find("GameManager").GetComponent<Game>();
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
        //
        // 状态机更新，射线画线
        UpdateStateMachine();
        CheckGroundByTag();
        // 移动平台
        if (_currentPlatform != null)
        {
 float platformDeltaX = _currentPlatform.position.x - _lastPlatformX;
            
            // 直接给玩家叠加X轴移动（只改X！）
            transform.position += new Vector3(platformDeltaX, 0, 0);
            
            // 更新记录值
            _lastPlatformX = _currentPlatform.position.x;
            
        }
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



    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Ladder"))
        {
            _isLadder = true;
            Debug.Log("在梯子上");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ladder"))
        {
            _isLadder = false;
            Debug.Log("不在梯子上");
            rb.velocity = new Vector2(rb.velocity.x, jump/4*3);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        //怀表
        if (other.collider.CompareTag("Watch"))
        {
            //隐藏
            other.gameObject.SetActive(false);
            game._isWatch = true;
        }
        //齿轮
        if (other.collider.CompareTag("Gear"))
        {
            //获取齿轮脚本
            Gear gearScript = other.collider.GetComponent<Gear>();
            game.gear[gearScript.type] += 1;
            other.gameObject.SetActive(false);

        }
        //尖刺
        if (other.collider.CompareTag("Spike"))
        {

            StartCoroutine(Death());
        }
        //追杀怪
        if (other.collider.CompareTag("Chase"))
        {
            StartCoroutine(Death());
        }
        //幽灵
        if (other.collider.CompareTag("Ghost"))
        {
            Ghost ghostScript = other.collider.GetComponent<Ghost>();
            if (ghostScript.type == game.worldType)
            {
                StartCoroutine(Death());
            }
        }
        //箭
        if (other.collider.CompareTag("Arrow"))
        {
            StartCoroutine(Death());
            Debug.Log("被箭射中");

        }
       //移动平台
        if (other.collider.CompareTag("MoveGround"))
        {
            _isMovingGround = true;
           _currentPlatform = other.transform;
            _lastPlatformX = _currentPlatform.position.x;
        }

    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.CompareTag("MoveGround"))
        {
_currentPlatform = null;
_isMovingGround = false;
        }
    }
    //死亡协程
    private IEnumerator Death()
    {
        if (!_isDead)
        {
            // 玩家死亡逻辑
            _isDead = true;
            playerAnim.anim.Play("die");
            yield return new WaitForSeconds(1f);
            _isDead = false;
            playerAnim.anim.Play("idle");
            //找到A节点
            GameObject ReviveNode = GameObject.Find("ReviveNode");
            //遍历A节点下的脚本Revive
            foreach (Transform child in ReviveNode.transform)
            {
                //获取脚本Revive
                Revive revive = child.GetComponent<Revive>();
                //判断是否是当前玩家的复活点
                if (revive.x == game.x && revive.y == game.y)
                {
                    //复活
                    transform.position = child.position;
                }
            }
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
        RaycastHit2D hit = Physics2D.Raycast(rayStart, Vector2.down, rayDownLength, groundLayer);

        // 有碰撞体,不是触发器 且 图层是Ground
        if (hit.collider != null && !hit.collider.isTrigger)
        {
            _isGrounded = true;
        }
        else
        {
            _isGrounded = false;
        }
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
