using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
   [Tooltip("音效组件")]
   public List<AudioSource> audioSource;
   [Tooltip("总音量")]
   public float volume;
   [Tooltip("音效素材列表")]
   public List<AudioClip> soundList;
   [Tooltip("单独音量列表")]
   public List<float> volumeList;
   [Tooltip("是否播放音效")]
   public List<bool> isPlayList;
   [Tooltip("音效类型，0，持续检测，循环，1，播放一下")]
   public List<int> soundType;
   void Start()
   {

   }

   // Update is called once per frame
   void Update()
   {
      for (int i = 0; i < audioSource.Count; i++)
      {
         audioSource[i].volume = volume * volumeList[i] / 10000;
      }
      for (int i = 0; i < audioSource.Count; i++)
      {
         if (soundType[i] == 0)
         {
            if (isPlayList[i])
            {
               if (!audioSource[i].isPlaying)
               {
                  audioSource[i].Play();
               }

            }
            else
            {
               audioSource[i].Stop();
            }
         }
         else if (soundType[i] == 1)
         {

         }

      }
   }
   //播放音效，循环
   public void PlaySoundLoop(int soundIndex, int index)
   {

      audioSource[soundIndex].loop = true;
      audioSource[soundIndex].clip = soundList[index];
      isPlayList[soundIndex] = true;
   }
   //播放音效，不循环
   public void PlaySound(int soundIndex, int index)
   {
      audioSource[soundIndex].loop = false;
      audioSource[soundIndex].clip = soundList[index];
      audioSource[soundIndex].Play();

   }
   //暂停音效
   public void PauseSound(int soundIndex)
   {
      audioSource[soundIndex].Pause();
      isPlayList[soundIndex] = false;
   }
   //停止音效
   public void StopSound(int soundIndex)
   {
      audioSource[soundIndex].Stop();
      isPlayList[soundIndex] = false;
   }

}
