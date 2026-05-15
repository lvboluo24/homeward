using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Grid : MonoBehaviour
{
    [Tooltip("和平世界显示，战争世界隐藏节点")]
    public List<GameObject> PeaceNodes=new List<GameObject>();
    [Tooltip("战争世界显示，和平世界隐藏节点")]
    public List<GameObject> WarNodes=new List<GameObject>();
    

    private Game game;
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
        
    }
    //检测世界类型
    public void CheckWorldType()
    {
        if (game.worldType == 0)
        {
            for(int i=0;i<PeaceNodes.Count;i++)
            {
                //获取TilemapRenderer组件，设置显示为true
                TilemapRenderer tilemapRenderer = PeaceNodes[i].GetComponent<TilemapRenderer>();
                tilemapRenderer.enabled = true;
                //获取TilemapCollider2D组件，设置显示为true
                TilemapCollider2D tilemapCollider2D = PeaceNodes[i].GetComponent<TilemapCollider2D>();
                tilemapCollider2D.enabled = true;
            }
            for(int i=0;i<WarNodes.Count;i++)
            {
                //获取TilemapRenderer组件，设置显示为false
                TilemapRenderer tilemapRenderer = WarNodes[i].GetComponent<TilemapRenderer>();
                tilemapRenderer.enabled = false;
                //获取TilemapCollider2D组件，设置显示为false
                TilemapCollider2D tilemapCollider2D = WarNodes[i].GetComponent<TilemapCollider2D>();
                tilemapCollider2D.enabled = false;
            }
        }
        else if (game.worldType == 1)
        {
            for(int i=0;i<PeaceNodes.Count;i++)
            {
                //获取TilemapRenderer组件，设置显示为false
                TilemapRenderer tilemapRenderer = PeaceNodes[i].GetComponent<TilemapRenderer>();
                tilemapRenderer.enabled = false;
                //获取TilemapCollider2D组件，设置显示为false
                TilemapCollider2D tilemapCollider2D = PeaceNodes[i].GetComponent<TilemapCollider2D>();
                tilemapCollider2D.enabled = false;
            }
            for(int i=0;i<WarNodes.Count;i++)
            {
                //获取TilemapRenderer组件，设置显示为true
                TilemapRenderer tilemapRenderer = WarNodes[i].GetComponent<TilemapRenderer>();
                tilemapRenderer.enabled = true;
                //获取TilemapCollider2D组件，设置显示为true
                TilemapCollider2D tilemapCollider2D = WarNodes[i].GetComponent<TilemapCollider2D>();
                tilemapCollider2D.enabled = true;
            }
        }
    }
}
