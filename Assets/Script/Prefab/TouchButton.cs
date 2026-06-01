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
//图像组件
    public SpriteRenderer renderer1;
//图片
    public Sprite[] sprite1;



    
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        //如果物体按住
        if (_isTouch)
        {
            //缩放y轴
            renderer1.sprite = sprite1[1];
            
        }
        else
        {
            //缩放
            renderer1.sprite = sprite1[0];
           
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        //如果不是标签为scope的物体，直接返回
        if (other.tag != "Scope")
        {
            if (type == 0)
            {
                _isTouch = true;
                if (!_isActivate)
                {
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
                
                _isActivate = true;
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

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag != "Scope")
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

}
