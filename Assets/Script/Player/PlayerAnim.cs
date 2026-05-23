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
    [Tooltip("是否跳跃")]
    public bool _isJump;
    [Tooltip("是否空中移动")]
    public bool _isAirMove;



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
        anim.SetBool("isJump", _isJump);
        anim.SetBool("isGrounded", player._isGrounded);
        anim.SetBool("isAirMove", _isAirMove);
        if (player._isGrounded&&!player._isLadder&&player.horizontalInput!=0)
        {
            _isrun = true;
        }
        else
        {
            _isrun = false;
        }
        if (!player._isGrounded&&!player._isLadder)
        {
            _isJump = true;
        }
        else
        {
            _isJump = false;
        }
        if (player.horizontalInput!=0)
        {
            _isAirMove = true;
        }
        else
        {
            _isAirMove = false;
        }


    }
}
