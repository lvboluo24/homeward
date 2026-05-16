using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [Tooltip("门需要的激活数量")]
public int demandnumber;
    [Tooltip("门当前激活数量")]
public int number;

    [Tooltip("门是否打开")]
public bool _isOpen;
    private Collider2D coll;
    private SpriteRenderer sr;
    void Awake()
    {
        
        sr = GetComponent<SpriteRenderer>();
        coll = GetComponent<Collider2D>();
        number = 0;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        UpdateDoor();
    }
    //门开关逻辑
     public void UpdateDoor()
    {
        if (number >= demandnumber)
        {
            _isOpen = true;
        }
        else
        {
            _isOpen = false;
        }
        if (_isOpen)
        {
            coll.enabled = false;
            sr.enabled = false;
        }
        else
        {
            coll.enabled = true;
            sr.enabled = true;
        }
    }
    
}
