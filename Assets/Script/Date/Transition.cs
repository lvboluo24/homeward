using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Transition : MonoBehaviour
{
    [Tooltip("0,关卡节点，1，过场节点")]
    public List<GameObject> node = new List<GameObject>();
    [Tooltip("是否有过场场景")]
    public bool _istransition;
    [Tooltip("0,过场背景图")]
    public List<Image> Image = new List<Image>();
    [Tooltip("谈化时间")]
    public float fadetime;
    [Tooltip("打字速度")]
    public float typeSpeed = 0.05f;
    [Tooltip("文本")]
    public List<string> Text = new List<string>();
    [Tooltip("文本索引")]
    public int textIndex;
    [Tooltip("文字索引")]
    public int charIndex;
    [Tooltip("是否在打字")]
    public bool isTyping;
    [Tooltip("文本组件")]
    public TextMeshProUGUI tmpText;

    void Awake()
    {
        if (_istransition)
        {
            node[1].SetActive(true);
        }
        else
        {
            node[1].SetActive(false);
        }
        tmpText.text = "";
        textIndex = 0;
        charIndex = 0;
    }
    void Start()
    {

    }

    void Update()
    {
        //如果点击左键
        if (Input.GetMouseButtonDown(0) && _istransition)
        {
            //如果不在打字中
            if (!isTyping)
            {
                //如果文本索引小于文本数量
                if (textIndex < Text.Count)
                {
                    StartCoroutine(typing());
                }
                else
                {
                    StartCoroutine(FadeOut());
                    Debug.Log("点击左键，过场场景结束");
                }
            }
        }
    }

    //打字
    public IEnumerator typing()
    {
        isTyping = true;
        tmpText.text = "";
        int a=0;
        while (charIndex < Text[textIndex].Length)
        {
            yield return new WaitForSeconds(typeSpeed);
            tmpText.text += Text[textIndex][charIndex];
            charIndex++;
            a++;
            if (a>1000000)
            {
                break;
            }
        }
        textIndex++;
        charIndex = 0;
        isTyping = false;
        Debug.Log(a);
    }
    //淡化过场场景协程
    public IEnumerator FadeOut()
    {
        //文字隐藏
        tmpText.gameObject.SetActive(false);
// 获取图片当前颜色
        Color startColor = Image[0].color;
        // 记录已经过的时间
        float elapsedTime = 0f;

        // 在 duration 时间内平滑降低 alpha
        while (elapsedTime < fadetime)
        {
            elapsedTime += Time.deltaTime;
            // 计算当前透明度（从 1 线性降到 0）
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadetime);
            
            // 赋值新颜色
            Image[0].color = new Color(startColor.r, startColor.g, startColor.b, alpha);
            
            // 等待一帧，继续循环
            yield return null;
        }

        // 最后确保完全透明
        Image[0].color = new Color(startColor.r, startColor.g, startColor.b, 0f);
        _istransition = false;

    }
}
