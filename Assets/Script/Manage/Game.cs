using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    // 游戏主逻辑
    [Tooltip("当前关卡")]
    public int level;
    [Tooltip("玩家在地图x，y坐标")]
    public int x, y;

    [Tooltip("和平（0）/战争（1）世界")]
    public int worldType;

    [Tooltip("当前拥有的齿轮数量，0，小齿轮，1，手雷齿轮，2，地雷齿轮，3，大齿轮")]
    public List<int> gear = new List<int>() { 0, 0, 0, 0 };

    [Tooltip("是否持有怀表")]
    public bool _isWatch;
    [Tooltip("钟摆状态，0，无，1，钟摆自动摆动，2，间隙摆动")]
    public int clockStatus;
    [Tooltip("钟摆摆动时间")]
    public float clockTime;
    [Tooltip("钟摆间隙时间")]
    public float clockGapTime;
    public List<Box> boxes = new List<Box>();

    private Player player;
    private MainCamera mainCamera;
    private Grid grid;
    //音效
    public Sound sound;

    void Awake()
    {
        if (level != 0)
        {
            player = FindObjectOfType<Player>();
            mainCamera = FindObjectOfType<MainCamera>();
            grid = FindObjectOfType<Grid>();
            boxes = new List<Box>(Object.FindObjectsOfType<Box>());
        }



    }
    void Start()
    {
        if (level == 3 && clockStatus == 1)
        {
            //启动钟摆协程
            StartCoroutine(Clock());
        }
    }

    void Update()
    {
        CheckPlayerPosition();
        CheckWorldType();
    }
    //检测玩家位置
    public void CheckPlayerPosition()
    {
        if (level != 0)
        {
            if (level == 1)
            {
                //x为玩家x位置除以17.77777f的整数
                x = (int)((player.transform.position.x + 8.88888f) / 17.77777f);
                //y为玩家y位置除以10的整数
                y = (int)((player.transform.position.y + 5) / 10);
            }
            else if (level == 2)
            {
                x = (int)((player.transform.position.x + 8.88888f) / 17.77777f);
                y = (int)((player.transform.position.y + 5) / 10);
            }
            else if (level == 3)
            {
                x = (int)((player.transform.position.x + 8.88888f) / 17.77777f);
                y = (int)((player.transform.position.y + 5) / 10);
            }
            mainCamera.x = x;
            mainCamera.y = y;
        }

    }
    //检查世界类型
    public void CheckWorldType()
    {
        //如果按键q，切换世界类型为和平
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (level <= 2)
            {
                if (_isWatch && gear[3] > 0)
                {
                    ConvertWorldType();
                }
            }
        }
    }
    //转换世界逻辑
    public void ConvertWorldType()
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
        foreach (Box box in boxes)
        {
            box.UpdateWorld();
        }
        //播放音效
        sound.PlaySound(1,5);

    }

    //检查齿轮
    public void CheckGear()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (gear[1] > 0)
            {
                gear[1]--;
            }
        }
    }
    //协程
    public IEnumerator Clock()
    {
        int count = 0;
        while (count < 9999999)
        {
            //如果钟摆状态为1，自动摆动
            if (clockStatus == 1)
            {
                //经过2秒
                yield return new WaitForSeconds(2f);
                ConvertWorldType();
            }
            count++;
        }
    }
}
