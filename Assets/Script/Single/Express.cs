using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Express : MonoBehaviour
{
    //图片素材,0,问号，1，感叹号，2，生气
public Sprite[] sprites;
//sp组件
public SpriteRenderer sr;
//动画组件
public Animator animator;
    void Start()
    {
  sr.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ExpAppear()
    {
                 sr.enabled = true;
        sr.sprite = sprites[1];
        animator.Play("ExpAppear");
    }
     public void ExpAno()
    {
        sr.enabled = false;
        //停止播放
        
    }
     public void ExpAngry()
    {
        sr.enabled = true;
        sr.sprite = sprites[2];
        animator.Play("ExpAnger");

    }


    
}
