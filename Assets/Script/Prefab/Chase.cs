using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour
{
    [Tooltip("移动速度")]
    public float moveSpeed = 5f;
    private Game game;
    private Player player;
    public Scope scope;
    private Rigidbody2D rb;
void Awake()
    {
        game = GameObject.Find("GameManager").GetComponent<Game>();
        player = GameObject.Find("Player").GetComponent<Player>();
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
    }


    void Update()
    {

    }
    void FixedUpdate()
    {
        if (scope._isPlayer)
        {
            Vector2 moveDirection = (player.transform.position - transform.position).normalized;

            // 2. 2D物理移动：固定速度追踪玩家（无惯性、平滑追踪）
            rb.velocity = moveDirection * moveSpeed;
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }
}
