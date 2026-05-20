using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{

        public bool _isBoom;
                [Tooltip("爆炸产生速度")]
        public float boomSpeed;
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

                Destroy(other.gameObject);
            }
            if (other.CompareTag("Spike"))
            {
                Destroy(other.gameObject);
            }
            if (other.CompareTag("Fragile"))
            {
                Destroy(other.gameObject);
            }
            if (other.CompareTag("Mine"))
            {
                Debug.Log("爆炸产生速度");
                //获取rd
                Rigidbody2D rd = other.GetComponent<Rigidbody2D>();
//根据位置，判断相对方向
                Vector2 relativePosition = other.transform.position - transform.position;
//根据相对方向，产生相对的速度
                rd.velocity = new Vector2(relativePosition.x * boomSpeed, rd.velocity.y);
            }
        }
        
    }
}
