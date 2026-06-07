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

    [Tooltip("隐藏时间")]
    public float hideTime;
[Tooltip("是否测试")]
public bool isTest;



    Game game;
    Music music;

    Black black;


    void Awake()
    {
        game = FindObjectOfType<Game>();
        music = FindObjectOfType<Music>();
        black = FindObjectOfType<Black>();
        //获取视频时间

        //判断是否播放视频
        if (game.level == 1&&!isTest)
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

        StartCoroutine(CheckVideoEnd());
    }
    //协程
    private IEnumerator CheckVideoEnd()
    {
        black.ShowBlack();
        yield return new WaitForSeconds(0.5f);
        videoEndnode.SetActive(true);
        videoPlayer.Play();
        yield return new WaitForSeconds(0.1f);
        black.HideBlack();
        yield return new WaitForSeconds(time);
        black.HideBlackSlow();
        yield return new WaitForSeconds(0.1f);
        videoEndnode.SetActive(false);
       
        music.PlayMusic();
    }

}
