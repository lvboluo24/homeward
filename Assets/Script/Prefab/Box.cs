using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    [Tooltip("箱子路径点，第一个为初始点，最后一个为终点")]
    public List<GameObject> Nodes = new List<GameObject>();


    [Tooltip("箱子移动速度")]
    public float speed;

    [Tooltip("箱子当前路径索引")]
    public int index;

    [Tooltip("箱子移动类型,0,自动往返，1，根据世界移动，2,切换一次变化")]
    public int type;

    [Tooltip("箱子世界类型,0,和平前往终点，1，战争前往终点")]
    public int worldType;

    [Tooltip("箱子目标,0,前往初始点,1,前往目标点")]
    public int goal;

    [Tooltip("0，两世界显示，1，和平显示，战争隐藏，2，和平隐藏，战争显示")]
    public int display;
    [Tooltip("是否传送回初始点")]
    public bool _isReturn;
    [Tooltip("是否有重力")]
    public bool _isGravity;

    private List<Vector3> PathNodes = new List<Vector3>();//记录箱子路径点位置

    private Game game;
    public Collider2D coll;
    public Scope scope;
    public SpriteRenderer sr;
    public Rigidbody2D rb;

    void Awake()
    {

        game = GameObject.Find("GameManager").GetComponent<Game>();
        //记录路径点位置
        for (int i = 0; i < Nodes.Count; i++)
        {
            PathNodes.Add(Nodes[i].transform.position);

        }

    }
    void Start()
    {

    }

    void Update()
    {

        //移动逻辑
        if (_isGravity)
        {
            //计算x方向移动方向
            Vector2 moveDirection = (PathNodes[index] - transform.position).normalized;
            if (Vector3.Distance(transform.position, PathNodes[index]) < 0.1f)
            {
                moveDirection.x = 0;
            }
            //设置速度
            rb.velocity = new Vector2(moveDirection.x * speed, rb.velocity.y);


        }
        else
        {
            transform.position = Vector3.MoveTowards(
       transform.position,
       PathNodes[index],
       speed * Time.deltaTime);
        }

        //到达目标点逻辑
        if (Vector3.Distance(transform.position, PathNodes[index]) < 0.1f)
        {
            Round();

        }
        UpdateDisplay();
        //在范围按Q键
        if (type == 2)
        {
            if (scope._isPlayer && Input.GetKeyDown(KeyCode.Q))
            {
                Debug.Log("按Q键");
                if (goal == 1)
                {
                    goal = 0;
                    transform.position = PathNodes[0];
                    index = 0;
                }
                else if (goal == 0)
                {
                    goal = 1;
                }

            }
        }
            
    }
    public void UpdateWorld()
    {
        if (type!=0)
        {
              Round();
        }
      
    }
    public void Round()
    {
        //往返逻辑
        //0，自动往返
        if (type == 0)
        {
            if (goal == 0)
            {
                if (index == 0)
                {
                    goal = 1;
                    index += 1;
                }
                else
                {
                    index--;
                }
            }
            else if (goal == 1)
            {
                if (_isReturn)
                {
                    index = PathNodes.Count - 1;
                    //直接传送回初始点
                    transform.position = PathNodes[0];
                }
                else
                {
                    if (index == PathNodes.Count - 1)
                    {
                        goal = 0;
                        index -= 1;
                    }
                    else
                    {
                        index++;
                    }
                }

            }
        }
        //1，根据世界移动
        else if (type == 1)
        {
            //如果箱子世界类型为和平前往终点
            if (worldType == 0)
            {
                //如果为和平世界
                if (game.worldType == 0)
                {
                    //如果未到达终点
                    if (index < PathNodes.Count - 1)
                    {
                        index++;
                    }
                }
                //如果为战争世界
                else if (game.worldType == 1)
                {
                    if (_isReturn)
                    {
                        transform.position = PathNodes[0];
                        index = 0;
                    }
                    else
                    {
                        //如果未到达初始点
                        if (index > 0)
                        {
                            index--;
                        }
                    }

                }

            }
            //如果为战争前往终点
            else if (worldType == 1)
            {
                //如果为和平世界
                if (game.worldType == 0)
                {
                    if (_isReturn)
                    {
                        transform.position = PathNodes[0];
                        index = 0;
                    }
                    else
                    {
                        //如果未到达初始点
                        if (index > 0)
                        {
                            index--;
                        }
                    }

                }
                //如果为战争世界
                else if (game.worldType == 1)
                {

                    //如果未到达终点
                    if (index < PathNodes.Count - 1)
                    {
                        index++;
                    }


                }
            }

        }
        //2，激活一次变化形态
        else if (type == 2)
        {
            //如果目标点为终点
            if (goal == 1)
            {
                if (index < PathNodes.Count - 1)
                {
                    index++;
                }
            }
            //如果目标点为起点
            else if (goal == 0)
            {

            }

            
        }

    }
    //显示逻辑
    private void UpdateDisplay()
    {
        if (display == 0)
        {
            //两世界显示
        }
        else if (display == 1)
        {
            //和平显示
            if (game.worldType == 0)
            {
                coll.enabled = true;
                sr.enabled = true;
            }
            if (game.worldType == 1)
            {
                coll.enabled = false;
                sr.enabled = false;
            }
        }
        else if (display == 2)
        {
            //和平隐藏
            if (game.worldType == 0)
            {
                coll.enabled = false;
                sr.enabled = false;
            }
            if (game.worldType == 1)
            {
                coll.enabled = true;
                sr.enabled = true;
            }
        }
    }
}
