using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowMineGear : MonoBehaviour
{
    [Tooltip("爆炸时间")]
    public float time;
    public Mine mine;
    public bool isBoom;
    //图像
    public SpriteRenderer spriteRenderer;
    //音效组件
    public Sound sound;
    //粒子系统
    public Particle particle;
    void Start()
    {
        StartCoroutine(Boom());
    }

    // Update is called once per frame
    void Update()
    {

    }
    private IEnumerator Boom()
    {
        yield return new WaitForSeconds(time);
        mine._isBoom = true;
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
            gameObject.SetActive(false);
        }

    }
}
