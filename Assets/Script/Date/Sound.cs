using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    [Tooltip("音效组件")]
    public AudioSource audioSource;
    [Tooltip("总音量")]
    public float volume;
    [Tooltip("音效素材列表")]
    public List<AudioClip> soundList;
    [Tooltip("单独音量列表")]
    public List<float> volumeList;
    [Tooltip("当前播放音效索引")]
    public int index;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     //播放音效，循环
     public void PlaySoundLoop(int ix)
     {
        audioSource.loop = true;
        audioSource.PlayOneShot(soundList[ix]);
     }
     //播放音效，不循环
     public void PlaySound(int ix)
     {
        audioSource.loop = false;
        audioSource.PlayOneShot(soundList[ix]);

     }
     //暂停音效
     public void PauseSound()
     {
        audioSource.Pause();
     }
     //停止音效
     public void StopSound()
     {
        audioSource.Stop();
     }
     
}
