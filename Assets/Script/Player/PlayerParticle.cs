using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParticle : MonoBehaviour
{
    public ParticleSystem[] ps;
    public Player player;
public ParticleSystem a;
    // 加入一个变量，记录上一帧是否在地面
    private bool lastGrounded;

    void Start()
    {
        foreach (var item in ps)
        {
            item.Stop();
        }
        lastGrounded = false;
        a.Play();
    }

    void Update()
    {
        bool currentGrounded = player._isGrounded&&player.horizontalInput!=0;

        // 只有 从“不在地面”变成“在地面”时，才播放一次
        if (currentGrounded && !lastGrounded)
        {
            foreach (var item in ps)
            {
                item.Play();
            }

        }
        // 只有 从“在地面”变成“不在地面”时，才停止一次
        else if (!currentGrounded && lastGrounded)
        {
            foreach (var item in ps)
            {
                item.Stop(true);
            }

        }
        if (player.horizontalInput==1)
        {

        }
        else if (player.horizontalInput == -1)
        {

        }
        // 更新状态
        lastGrounded = currentGrounded;
    }
}