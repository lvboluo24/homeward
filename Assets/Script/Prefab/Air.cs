using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Air : MonoBehaviour
{
    List<GameObject> item = new List<GameObject>();
    Rigidbody2D playerRb;
    [Tooltip("喷气推力大小")]
    public float pushForce = 15f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // 当物体进入触发器
    private void OnTriggerEnter2D(Collider2D other)
    {
        // 检测是否是玩家
        if(other.CompareTag("Player"))
        {
            playerRb = other.GetComponent<Rigidbody2D>();
        }
    }

    // 当物体停留在触发器里 —— 每帧执行
    private void OnTriggerStay2D(Collider2D other)
    {
        // 如果有玩家刚体，就持续施加向上的力
        if(playerRb != null)
        {
            // 2D 向上推力（AddForce 适合平滑上升）
            playerRb.velocity = new Vector2(playerRb.velocity.x, pushForce);
        }
    }

    // 当物体离开触发器
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            playerRb = null;
        }
    }
}
