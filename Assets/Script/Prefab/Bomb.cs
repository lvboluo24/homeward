using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public bool _isBoom;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (_isBoom)
        {
            if (other.CompareTag("Chase"))
            {
                // 爆炸时，与Chase标签碰撞的物体，会销毁
                Destroy(other.gameObject);
            }
            if (other.CompareTag("Spike"))
            {
                Debug.Log("爆炸时，与Spike标签碰撞的物体，会销毁");
                // 爆炸时，与Spike标签碰撞的物体，会销毁
                Destroy(other.gameObject);
            }
        }
        
    }
}
