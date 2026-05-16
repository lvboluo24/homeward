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
    public int goal;

[Tooltip("0，两世界显示，1，和平显示，战争隐藏，2，和平隐藏，战争显示")]
public int display;
    private List<Vector3> PathNodes = new List<Vector3>();//记录箱子路径点位置
    
    private Game game;
    public Collider2D coll;
    public SpriteRenderer sr;

    void Awake()
    {
        
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
UpdateDisplay();
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
