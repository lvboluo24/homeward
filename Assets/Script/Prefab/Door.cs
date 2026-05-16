using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    //定义collider组件
    private Collider2D coll;
    //定义sr组件
    private SpriteRenderer sr;
    void Awake()
    {
        
        sr = GetComponent<SpriteRenderer>();
        coll = GetComponent<Collider2D>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    //打开门
    public void OpenDoor()
    {
        //关闭碰撞体
        coll.enabled = false;
        //设置sr组件的渲染为false
        sr.enabled = false;
    }
    //关闭门
    public void CloseDoor()
    {
        //开启碰撞体
        coll.enabled = true;
        //设置sr组件的渲染为true
        sr.enabled = true;
    }
}
