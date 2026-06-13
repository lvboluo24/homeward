using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Air : MonoBehaviour
{


    [Tooltip("喷气推力大小")]
    public float pushForce;
    [Tooltip("是否喷气")]
    public bool _isAir;
    [Tooltip("喷气需要的激活数量")]
    public int demandnumber;
    [Tooltip("喷气当前激活数量")]
    public int number;
    [Tooltip("类型,0,按钮激活，1，和平激活，2，战争激活")]
    public int type;
    //粒子系统
    public ParticleSystem particleSystem1;
public int index;


    public bool _a;
    Game game;

    private void Awake()
    {
        game = FindObjectOfType<Game>();
        particleSystem1.Stop();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (type == 0)
        {
            if (number >= demandnumber)
            {
                _isAir = true;
            }
            else
            {
                _isAir = false;
            }
        }
        else if (type == 1)
        {
            if (game.worldType == 0)
            {
                _isAir = false;
            }
            else
            {
                _isAir = true;
            }
        }
        else if (type == 2)
        {
            if (game.worldType == 1)
            {
                _isAir = false;
            }
            else
            {
                _isAir = true;
            }
        }
        if (_isAir&&index==0)
        {
            //显示粒子
            particleSystem1.Play();
            index = 1;
        }
        else if (!_isAir&&index==1)
        {
            //隐藏粒子
            particleSystem1.Stop();
            particleSystem1.Clear();
            index = 0;
        }
        

    }
    // 当物体进入触发器
    private void OnTriggerEnter2D(Collider2D other)
    {

    }

    // 当物体停留在触发器里 —— 每帧执行
    private void OnTriggerStay2D(Collider2D other)
    {
        if (_isAir)
        {
            //如果物体有Rigidbody2D
            if (other.tag != "Chase")
            {
                if (other.GetComponent<Rigidbody2D>() != null)
                {
                    Rigidbody2D itemRb = other.GetComponent<Rigidbody2D>();
                    itemRb.velocity = new Vector2(itemRb.velocity.x, pushForce);
                    Debug.Log(other.gameObject.name);
                    Debug.Log(itemRb.velocity);
                }
            }

        }

    }

    // 当物体离开触发器
    private void OnTriggerExit2D(Collider2D other)
    {

    }
}
