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
    private Player player;
    private MainCamera mainCamera;
    void Awake()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        mainCamera = GameObject.Find("Main Camera").GetComponent<MainCamera>();

    }
    void Start()
    {

    }

    void Update()
    {
        CheckPlayerPosition();
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
            //打印玩家位置
            Debug.Log($"玩家在地图x，y坐标为：{player.transform.position.x},{player.transform.position.y}");
            //打印玩家在地图x，y坐标
            Debug.Log($"玩家在地图x，y坐标为：{x},{y}");
        }
        mainCamera.x = x;
        mainCamera.y = y;
    }
}
