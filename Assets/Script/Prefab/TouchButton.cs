using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchButton : MonoBehaviour
{
    [Tooltip("物体按住")]
    public bool _isTouch;
    [Tooltip("激活状态")]
    public bool _isActivate;
    [Tooltip("0,永久激活，1，按住激活，不按不激活")]
    public int type;

        [Tooltip("控制的门")]
    public Door door;
    [Tooltip("控制的喷气")]
    public Air air;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (type == 0)
        {
            _isActivate = true;
            if (door != null)
            {
                //打开门
                door.number++;
            }
            if (air != null)
            {
                //打开喷气
                air.number++;
            }
        }
        if (type == 1)
        {
            _isTouch = true;
            if (door != null)
            {
                //打开门
                door.number++;
            }
            if (air != null)
            {
                //打开喷气
                air.number++;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (type == 1)
        {
            _isTouch = false;
            if (door != null)
            {
                //关闭门
                door.number--;
            }
            if (air != null)
            {
                //关闭喷气
                air.number--;
            }
        }
    }
    
}
