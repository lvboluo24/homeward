using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Black : MonoBehaviour
{
    // Start is called before the first frame update
    //image
    [Tooltip("ui图片")]
    public Image Image;
    [Tooltip("隐藏时间")]
    public float hideTime;

    Game game;
void Awake()
{
    game = FindObjectOfType<Game>();
        if (game.level != 0)
        {
            ShowBlack();
        }
        else
        {
            HideBlack();
        }
    HideBlack();
}

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    //直接显示
    public void ShowBlack()
    {
        Image.enabled = true;
    }
    //直接隐藏
    public void HideBlack()
    {
        Image.enabled = false;
    }
    //逐渐显示
    public void ShowBlackSlow()
    {
        StartCoroutine(IShowBlack());
    }
    //逐渐隐藏
    public void HideBlackSlow()
    {
        StartCoroutine(IHideBlack());
    }



    //协程,慢慢隐藏
    IEnumerator IHideBlack()
    {
        Color startColor = Image.color;
        Image.enabled = true;

        // 已经过的时间
        float elapsedTime = 0f;

        // 在总时长内循环执行
        while (elapsedTime < hideTime)
        {
            elapsedTime += Time.deltaTime;

            // 计算透明度：从1 线性过渡到 0
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / hideTime);

            // 赋值新颜色
            Image.color = new Color(startColor.r, startColor.g, startColor.b, alpha);

            // 等待一帧，继续循环
            yield return null;
        }

        // 最后确保完全透明
        Image.color = new Color(startColor.r, startColor.g, startColor.b, 0f);

        // 可选：完全消失后隐藏物体
        Image.enabled = false;
    }
    //协程,慢慢显示
    IEnumerator IShowBlack()
    {
        
        Color startColor = Image.color;
        // 已经过的时间
        float elapsedTime = 0f;
        Image.color = new Color(startColor.r, startColor.g, startColor.b, 0f);
        Image.enabled = true;
        // 在总时长内循环执行
        while (elapsedTime < hideTime)
        {
            elapsedTime += Time.deltaTime;

            // 计算透明度：从1 线性过渡到 0
            float alpha = Mathf.Lerp(0f, 1f, elapsedTime / hideTime);

            // 赋值新颜色
            Image.color = new Color(startColor.r, startColor.g, startColor.b, alpha);

            // 等待一帧，继续循环
            yield return null;
        }

        Image.color = new Color(startColor.r, startColor.g, startColor.b, 1f);
        
    }


}
