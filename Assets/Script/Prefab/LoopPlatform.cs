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
         if (Vector3.Distance(transform.position, PathNodes[index].transform.position) < 0.1f)
        {
            //如果到达目标点,摧毁
            Destroy(gameObject);

        }

    }
    //进入
    private void OnTriggerEnter2D(Collider2D other)
    {
        
    }
}
