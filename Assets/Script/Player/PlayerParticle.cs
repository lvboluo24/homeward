using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParticle : MonoBehaviour
{
    public ParticleSystem ps;
    public Player player;

    // 加入一个变量，记录上一帧是否在地面
    private bool lastGrounded;

    void Start()
    {
        ps.Stop();
        lastGrounded = false;
    }

    void Update()
    {
        bool currentGrounded = player._isGrounded&&player.horizontalInput!=0;

        // 只有 从“不在地面”变成“在地面”时，才播放一次
        if (currentGrounded && !lastGrounded)
        {
            ps.Play();
            Debug.Log("播放粒子");
        }
        // 只有 从“在地面”变成“不在地面”时，才停止一次
        else if (!currentGrounded && lastGrounded)
        {
            ps.Stop(true);
            Debug.Log("停止粒子");
        }
        if (player.horizontalInput==1)
        {
            //旋转x轴为90度
            
            Debug.Log("旋转x轴为90度");
        }
        else if (player.horizontalInput == -1)
        {
            //旋转x轴为-90度
            
            Debug.Log("旋转x轴为-90度");
        }
        // 更新状态
        lastGrounded = currentGrounded;
    }
}