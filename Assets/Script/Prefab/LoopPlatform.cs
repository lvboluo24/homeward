using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopPlatform : MonoBehaviour
{

    [Tooltip("平台速度")]
    public float platformSpeed;
    [Tooltip("平台路径节点")]
    public List<GameObject> PathNodes=new List<GameObject>();
    [Tooltip("目标点索引,0,起点，1，终点")]
    public int index = 0;
    [Tooltip("启动")]
    public bool _isStart;
    [Tooltip("平台类型,2,两世界显示，0，和平世界显示，1，战争世界显示")]
    public int display;
    //sp图像
    public SpriteRenderer spRenderer;
    //碰撞体
    public Collider2D collider1;
    Game game;
     void Awake()
    {
        game = GameObject.Find("GameManager").GetComponent<Game>();

    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (_isStart)
        {
        transform.position = Vector3.MoveTowards(
        transform.position,
        PathNodes[index].transform.position,
        platformSpeed * Time.deltaTime);
        }
         if (Vector3.Distance(transform.position, PathNodes[index].transform.position) < 0.1f)
        {
            //如果到达目标点,摧毁
            Destroy(gameObject);

        }
        if (display==0)
        {
            //如果为和平世界
            if (game.worldType == 1)
            {
               //隐藏平台
               spRenderer.enabled = false;
               //隐藏碰撞体
               collider1.enabled = false;
            }
            else if (game.worldType == 0)
            {
               spRenderer.enabled = true;
               collider1.enabled = true;
            }
        }
        else if (display==1)
        {
            //如果为战争世界
            if (game.worldType == 0)
            {
               //隐藏平台
               spRenderer.enabled = false;
               //隐藏碰撞体
               collider1.enabled = false;
            }
            else if (game.worldType == 1)
            {
               spRenderer.enabled = true;
               collider1.enabled = true;
            }
        }

    }
    //进入
    private void OnTriggerEnter2D(Collider2D other)
    {
        
    }
}
