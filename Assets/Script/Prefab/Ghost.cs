using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    [Tooltip("移动速度")]
    public float moveSpeed;
    [Tooltip("类型，0，和平追，战争停，1，和平停")]
    public int type;
    private Game game;
    private Player player;
    public Scope scope;
    private Rigidbody2D rb;

    void Start()
    {
        game = GameObject.Find("GameManager").GetComponent<Game>();
        player = GameObject.Find("Player").GetComponent<Player>();
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {

    }
    void FixedUpdate()
    {
        if (scope._isPlayer)
        {
            if (type == 0 && game.worldType == 0 || type == 1 && game.worldType == 1)
            {
                Vector2 moveDirection = (player.transform.position - transform.position).normalized;
                rb.velocity = new Vector2(moveDirection.x * moveSpeed, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y);
            }

        }

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        //如果接触尖刺
        if (other.collider.CompareTag("Spike"))
        {
            gameObject.SetActive(false);
            other.gameObject.SetActive(false);
        }
    }
}
