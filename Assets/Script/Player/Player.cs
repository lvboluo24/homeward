using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Tooltip("玩家速度")]
    public float speed;
    [Tooltip("玩家跳跃高度")]
    public float jump;
    [Tooltip("射线向下长度")]
    public float rayDownLength = 0.3f;
    [Tooltip("左右移动输入值")]
    public float horizontalInput;
    [Tooltip("是否在地")]
    public bool _isGrounded;
    [Tooltip("射线起点偏移")]
    public Vector2 rayOffset;
    private Rigidbody2D rb;
    float scaleScale;

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

        horizontalInput = Input.GetAxisRaw("Horizontal");
        CheckGroundByTag();
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jump);
            Debug.Log("跳跃");
        }

        Flip();
    }
    void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);
    }
    void Flip()
    {
        if (horizontalInput > 0.1f)
            transform.localScale = new Vector3(-scaleScale * 1f, transform.localScale.y, transform.localScale.z);
        else if (horizontalInput < -0.1f)
            transform.localScale = new Vector3(scaleScale * 1f, transform.localScale.y, transform.localScale.z);
    }
    void CheckGroundByTag()
    {
        Vector2 rayStart = (Vector2)transform.position + rayOffset;
        // 向下发射射线
        RaycastHit2D hit = Physics2D.Raycast(rayStart, Vector2.down, rayDownLength);

        // 有碰撞体 且 标签是Ground
        _isGrounded = hit.collider != null && hit.collider.CompareTag("Ground");
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Vector2 start = (Vector2)transform.position + rayOffset;
        Vector2 end = start + Vector2.down * rayDownLength;
        Gizmos.DrawLine(start, end);
    }
}
