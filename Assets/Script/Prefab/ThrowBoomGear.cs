using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBoomGear : MonoBehaviour
{
    [Tooltip("爆炸时间")]
    public float time;
    public Bomb bomb;
    //图像
    public SpriteRenderer spriteRenderer;
    //音效组件
    public Sound sound;
    //粒子系统
    public Particle particle;

    public bool isBoom;
    void Start()
    {
        StartCoroutine(Boom());
    }

    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

        }
        else
        {
            
            bomb._isBoom = true;
         
            StartCoroutine(BoomFalse());
        }

    }
    //协程
    private IEnumerator Boom()
    {
              
        yield return new WaitForSeconds(time);
        bomb._isBoom = true;
        Debug.Log("爆炸");
   
        StartCoroutine(BoomFalse());

    }
    private IEnumerator BoomFalse()
    {
        if (!isBoom)
        {
               isBoom = true;
               //播放音效
        sound.PlaySound(0,0);
        //播放粒子系统
        particle.play=true;
        yield return new WaitForSeconds(0.02f);
        spriteRenderer.enabled = false;
       yield return new WaitForSeconds(1f);
       Destroy(gameObject);
        }
        
    }
}
