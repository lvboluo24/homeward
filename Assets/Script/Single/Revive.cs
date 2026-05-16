using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revive : MonoBehaviour
{
    [Tooltip("复活点在地图x，y坐标")]
    public int x,y;
    private Game game;
    void Awake()
    {
        game = GameObject.Find("GameManager").GetComponent<Game>();
        if (game.level == 1)
        {
            //x为玩家x位置除以17.77777f的整数
            x = (int)((transform.position.x+8.88888f)/17.77777f);
            //y为玩家y位置除以10的整数
            y = (int)((transform.position.y+5)/10);
        }
    }
    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
