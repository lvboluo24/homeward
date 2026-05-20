using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [Tooltip("箭移动速度")]
    public float moveSpeed;
        [Tooltip("箭移动方向")]
    public Vector2 moveDirection;
    private Rigidbody2D rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //朝移动方向移动
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        // 如果碰到物体，销毁箭

            Destroy(gameObject);
        
    }
}
