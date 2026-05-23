using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    public Animator anim;
    public Player player;
    [Tooltip("是否正在移动")]
    public bool _isrun;
    [Tooltip("是否正在梯子")]
    public bool _isLadder;
    [Tooltip("是否跳跃向上")]
    public bool _isJumpUp;
    [Tooltip("是否跳跃向下")]
    public bool _isJumpDown;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("horizontal", player.horizontalInput);
        anim.SetFloat("vertical", player.verticalInput);
        anim.SetBool("isrun", _isrun);
        anim.SetBool("isLadder", player._isLadder);
        anim.SetBool("isJumpUp", _isJumpUp);
        anim.SetBool("isJumpDown", _isJumpDown);
        anim.SetBool("isGrounded", player._isGrounded);
        if (player._isGrounded&&!player._isLadder&&player.horizontalInput!=0)
        {
            _isrun = true;
        }
        else
        {
            _isrun = false;
        }
        //如果player物体速度向上
        if (!player._isGrounded&&player.rb.velocity.y>=0&&!player._isLadder)
        {
            _isJumpUp = true;
        }
        else
        {
            _isJumpUp = false;
        }
        //如果player物体速度向下
        if (!player._isGrounded&&player.rb.velocity.y<=0&&!player._isLadder)
        {
            _isJumpDown = true;
        }
        else
        {
            _isJumpDown = false;
        }
    }
}
