using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [Tooltip("0,和平，1，和平黑白，2，战争，3，战争黑白")]
    public List<GameObject> node = new List<GameObject>();
    [Tooltip("sr组件")]
    public List<SpriteRenderer> sr = new List<SpriteRenderer>();
    private Game game;
    //获取sr


    void Awake()
    {

        game = FindObjectOfType<Game>();
        //获取sr组件
        for (int i = 0; i < node.Count; i++)
        {
            sr.Add(node[i].GetComponent<SpriteRenderer>());
        }

    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //直接检查背景世界类型
    public void CheckBackgroundWorldType()
    {
        if (game.worldType == 0)
        {
            sr[0].enabled = true;
            sr[1].enabled = false;
        }
        else if (game.worldType == 1)
        {
            sr[0].enabled = false;
            sr[1].enabled = true;
        }
    }
    //遮罩前事件
    public void CoverTile1()
    {
        sr[0].enabled = true;
        sr[1].enabled = true;
        if (game.worldType == 0)
        {
            sr[0].maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
            sr[1].maskInteraction = SpriteMaskInteraction.VisibleOutsideMask;
            sr[0].sortingOrder = -1;
            sr[1].sortingOrder = 0;
        }
        else if (game.worldType == 1)
        {
            sr[0].maskInteraction = SpriteMaskInteraction.VisibleOutsideMask;
            sr[1].maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
            sr[1].sortingOrder = -1;
            sr[0].sortingOrder = 0;

        }

    }
    //遮罩后事件
    public void CoverTile2()
    {
        sr[0].maskInteraction = SpriteMaskInteraction.None;
        sr[1].maskInteraction = SpriteMaskInteraction.None;
        CheckBackgroundWorldType();

    }

}
