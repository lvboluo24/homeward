using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopPlatform : MonoBehaviour
{

    [Tooltip("平台速度")]
    public float platformSpeed;
    [Tooltip("平台路径节点")]
    public List<GameObject> PathNodes=new List<GameObject>();
    [Tooltip("目标点索引,0,起点，1，终点")]
    public int index = 0;
        [Tooltip("启动")]
    public bool _isStart;
    //sp图像
    public SpriteRenderer spRenderer;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (_isStart)
        {
        transform.position = Vector3.MoveTowards(
        transform.position,
        PathNodes[index].transform.position,
        platformSpeed * Time.deltaTime);
        }

    }
    //进入
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("LoopStart"))
        {
            if (index == 0)
            {
                //摧毁
                Destroy(gameObject);
            }

        }
        if (other.CompareTag("LoopEnd"))
        {
            if (index == 1)
            {
                //摧毁
                Destroy(gameObject);
            }
        }
        if (other.CompareTag("LoopDisplay"))
        {
            Debug.Log("显示");
            //显示
            spRenderer.enabled = true;
        }
        if (other.CompareTag("LoopHide"))
        {
            Debug.Log("隐藏");
            //隐藏
            spRenderer.enabled = false;
        }
    }
}
