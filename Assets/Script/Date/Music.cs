using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    [Tooltip("音乐组件")]
    public AudioSource audioSource;
    [Tooltip("总音量")]
    public float volume;
    [Tooltip("音乐素材列表,0,")]
    public List<AudioClip> musicList;
    [Tooltip("单独音量列表")]
    public List<float> volumeList;
    [Tooltip("当前播放音乐索引")]
    public int index;
    [Tooltip("是否播放音乐")]
    public bool isPlay = true;

    
Save save;
Game game;
void Awake()
    {

        game = FindObjectOfType<Game>();
        save = FindObjectOfType<Save>();

    }
   void Start()
    {
        PlayMusic();
    }

    // Update is called once per frame
    void Update()
    {
//调整音量
        audioSource.volume = volume * volumeList[index]/10000;

    }
    //播放音乐
    public void PlayMusic()
    {
        if (game.level == 1)
        {
            index = 1;
        }
        else if (game.level == 2)
        {
            index = 2;
        }
        audioSource.clip = musicList[index];
        audioSource.Play();
        
        
    }
    //暂停音乐
    public void PauseMusic()
    {
        audioSource.Pause();
    }
    
}
