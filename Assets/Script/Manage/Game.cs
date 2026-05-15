using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    // 游戏主逻辑
    [Tooltip("当前关卡")]
    public int level;
    [Tooltip("玩家在地图x，y坐标")]
    public int x,y;

    [Tooltip("和平（0）/战争（1）世界")]
    public int worldType;
    private Player player;
    private MainCamera mainCamera;
    private Grid grid;
    void Awake()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        mainCamera = GameObject.Find("Main Camera").GetComponent<MainCamera>();
        grid = GameObject.Find("GridManager").GetComponent<Grid>();
    }
    void Start()
    {

    }

    void Update()
    {
        CheckPlayerPosition();
        CheckWorldType();
    }
    //检测玩家位置
    public void CheckPlayerPosition()
    {
        if (level == 1)
        {
            //x为玩家x位置除以17.77777f的整数
            x = (int)((player.transform.position.x+8.88888f)/17.77777f);
            //y为玩家y位置除以10的整数
            y = (int)((player.transform.position.y+5)/10);
        }
        mainCamera.x = x;
        mainCamera.y = y;
    }
    //检查世界类型
    public void CheckWorldType()
    {
//如果按键q，切换世界类型为和平
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (worldType == 0)
            {
                worldType = 1;
            }
            else if (worldType == 1)
            {
                worldType = 0;
            }
            grid.CheckWorldType();
        }
    }
}
