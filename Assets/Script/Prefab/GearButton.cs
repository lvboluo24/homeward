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
[Tooltip("控制的门")]
    public Door door;

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
            if (_isPlayer && !_isActivate&&game.gear[0]>=gear)
            {
                _isActivate = true;
                game.gear[0] -= gear;
            }
        }
        UpdateActivate();
    }
    //激活逻辑
void UpdateActivate()
    {
        if (_isActivate)
        {
            if (door!=null)
            {
                //打开门
                door.OpenDoor();
            }
           
        }
        else
        {
            if (door!=null)
            {
                //关闭门
                door.CloseDoor();
            }
        }
    }

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
