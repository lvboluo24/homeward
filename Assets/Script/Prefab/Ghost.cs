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
    //当前位置
    private Vector2 currentPosition;
    public bool _isReset;
        public Sound sound;

    void Start()
    {
        game = GameObject.Find("GameManager").GetComponent<Game>();
        player = GameObject.Find("Player").GetComponent<Player>();
        rb = GetComponent<Rigidbody2D>();
        currentPosition = transform.position;
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
                //播放音效
                sound.PlaySoundLoop(0,3);
            }
            else
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y);
                //停止音效
                sound.StopSound(0);
            }

        }
        else
        {
            sound.StopSound(0);
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
        //如果接触玩家
        if (other.collider.CompareTag("Player"))
        {
            StartCoroutine(ResetPosition());
        }
    }
    private IEnumerator ResetPosition()
    {
        if (!_isReset)
        {
            _isReset = true;
            yield return new WaitForSeconds(1f);
            Debug.Log("重置位置");
            transform.position = currentPosition;
            _isReset = false;
        }

    }
}
