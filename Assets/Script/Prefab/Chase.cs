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
    //当前位置
    private Vector2 currentPosition;
    public bool _isReset;

    //音效组件
    public Sound sound;
    public Express express;
    int isExp = 0;
    public Animator animator;
    void Awake()
    {
        game = GameObject.Find("GameManager").GetComponent<Game>();
        player = GameObject.Find("Player").GetComponent<Player>();
        rb = GetComponent<Rigidbody2D>();
        currentPosition = transform.position;
    }
    void Start()
    {

        animator.speed = 0;
    }


    void Update()
    {
        if (isExp == 0&&scope._isPlayer)
        {
            express.ExpAngry();
            animator.Play("MonIdle");
            animator.speed = 1;
            isExp = 1;
            
        }
        if (!scope._isPlayer)
        {
            isExp = 0;
            express.ExpAno();
            animator.speed = 0;

        }
        if (scope._isPlayer)
        {

            
        }
    }
    void FixedUpdate()
    {
        if (scope._isPlayer)
        {
            Vector2 moveDirection = (player.transform.position - transform.position).normalized;

            // 2. 2D物理移动：固定速度追踪玩家（无惯性、平滑追踪）
            rb.velocity = moveDirection * moveSpeed;
            //播放音效
            sound.PlaySoundLoop(0,3);
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
            //停止音效
            sound.StopSound(0);
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        //如果接触玩家
        if (other.collider.CompareTag("Player"))
        {
            StartCoroutine(ResetPosition());
        }
    }
    //协程
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
