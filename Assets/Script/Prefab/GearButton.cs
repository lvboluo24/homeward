using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GearButton : MonoBehaviour
{
    [Tooltip("齿轮需求数")]
    public int gear;

    [Tooltip("玩家在互动范围内")]
    public bool _isPlayer;
    [Tooltip("激活状态")]
    public bool _isActivate;
    [Tooltip("齿轮消失")]
    public bool _isDisappear;
    [Tooltip("控制的门")]
    public Door door;
    [Tooltip("控制的空气机关")]
    public Air air;
    [Tooltip("控制的循环平台")]
    public Looping looping;
    
    public SpriteRenderer spRenderer;
    //碰撞体
    public Collider2D collider1;
    [Tooltip("平台显示，0，两世界显示，1，和平显示，2，战争显示")]
    public int display;

    private Game game;


    void Awake()
    {

        game = GameObject.Find("GameManager").GetComponent<Game>();

    }
    void Start()
    {

    }

    void Update()
    {
        //按键1
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (_isPlayer && !_isActivate && game.gear[0] >= gear)
            {
                _isActivate = true;
                game.gear[0] -= gear;
                if (door != null)
                {
                    door.number++;
                }
                if (air != null)
                {
                    air.number++;
                }
                if (looping != null)
                {
                    if (looping.platformType == 0)
                    {
                        looping.platformType = 1;
                    }
                    else
                    {
                        looping.platformType = 0;
                    }
                    //找到所有子节点
                    looping.FindAllChildren();
                }
                if (_isDisappear)
                {
                    gameObject.SetActive(false);
                }
            }
        }
        if (display == 1)
        {
            //如果为和平世界
            if (game.worldType == 0)
            {
                spRenderer.enabled = true;
                collider1.enabled = true;
            }
            else if (game.worldType == 1)
            {
                spRenderer.enabled = false;
                collider1.enabled = false;
            }

        }
        else if (display == 2)
        {
            //如果为战争世界
            if (game.worldType == 0)
            {
                spRenderer.enabled = false;
                collider1.enabled = false;
            }
            else if (game.worldType == 1)
            {
                spRenderer.enabled = true;
                collider1.enabled = true;
            }
        }
     
    }
    //激活逻辑


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _isPlayer = true;

        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _isPlayer = false;
        }
    }
}
