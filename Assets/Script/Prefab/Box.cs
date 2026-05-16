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

    [Tooltip("箱子移动类型,0,自动往返，1，根据世界移动，")]
    public int type;

    [Tooltip("箱子初始目标,0,前往初始点,1,前往目标点")]
    public int goal;//1，前往初始点,1,前往目标点，
    private List<Vector3> PathNodes = new List<Vector3>();//记录箱子路径点位置
    private Rigidbody2D rb;
        private Game game;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        game = GameObject.Find("GameManager").GetComponent<Game>();
        //记录路径点位置
        for (int i = 0; i < Nodes.Count; i++)
        {
            PathNodes.Add(Nodes[i].transform.position);
            Debug.Log(PathNodes[i]);
        }

    }
    void Start()
    {

    }

    void Update()
    {
        if (type == 0)
        {
            //自动往返
            transform.position = Vector3.MoveTowards(
            transform.position,
            PathNodes[index],
            speed * Time.deltaTime
        );
            //如果到达目标点
            if (Vector3.Distance(transform.position, PathNodes[index]) < 0.1f)
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
        else if (type == 1)
        {
            //根据世界移动
        }

    }
}
