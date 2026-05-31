using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class Video : MonoBehaviour
{
    [Tooltip("视频播放组件")]
    public VideoPlayer videoPlayer;

    [Tooltip("视频节点")]
    public GameObject videoEndnode;
    [Tooltip("视频时间")]
    public float time;
    [Tooltip("是否播放视频")]
    public bool _isPlayVideo;
    [Tooltip("ui图片")]
    public Image Image;
[Tooltip("隐藏时间")]
public float hideTime;
Game game;  


    void Awake()
    {
        game = FindObjectOfType<Game>();
        if (game.level == 1)
        {
            PlayVideo();
        }
        else
        {
            videoEndnode.SetActive(false);

        }
    }

    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

    }
    //播放视频
    public void PlayVideo()
    {
        Image.enabled = false;
        videoEndnode.SetActive(true);
        videoPlayer.Play();
        StartCoroutine(CheckVideoEnd());
    }
    //协程
    private IEnumerator CheckVideoEnd()
    {
        Color startColor = Image.color;
        yield return new WaitForSeconds(time);
        //停止视频播放
        videoPlayer.Stop();
        Image.enabled = true;
        //显示图片组件
        // 记录开始时的颜色（保留RGB，只修改透明度）


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
        Image.enabled = true;
        videoEndnode.SetActive(false);
    }

}
