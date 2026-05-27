using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Looping : MonoBehaviour
{
    [Tooltip("平台出生位置")]
    public GameObject platformStart;
    [Tooltip("平台终点位置")]
    public GameObject platformEnd;
    [Tooltip("平台速度")]
    public float platformSpeed;

    [Tooltip("平台方向，0，起点到终点，1，从终点到起点")]
    public int platformType;
    [Tooltip("平台预制体")]
    public GameObject platformPrefab;
    [Tooltip("生成时间")]
    public float generateTime;


        [Tooltip("平台预制体父节点")]
    public GameObject platformPrefabParent;
    [Tooltip("平台显示，0，两世界显示，1，和平显示，2，战争显示")]
    public int display;



    void Start()
    {
        //生成预制体协程
        StartCoroutine(GeneratePlatform());
    }


    void Update()
    {

    }
    //生成预制体协程
    private IEnumerator GeneratePlatform()
    {
        while (true)
        {
            //每间隔时间生成一个预制体
            yield return new WaitForSeconds(generateTime);
            //生成预制体，并获取脚本组件
            if (platformType == 0)
            {
                GameObject platformObj = Instantiate(platformPrefab, platformStart.transform.position, platformStart.transform.transform.rotation, platformPrefabParent.transform);
                LoopPlatform platform1 = platformObj.GetComponent<LoopPlatform>();
                platform1.platformSpeed = platformSpeed;
                platform1.display = display;
                platform1.PathNodes.Add(platformStart);
                platform1.PathNodes.Add(platformEnd);
                platform1.index = 1;
                //设置启动
                platform1._isStart = true;



            }
            else if (platformType == 1)
            {
                GameObject platformObj = Instantiate(platformPrefab, platformEnd.transform.position, platformEnd.transform.transform.rotation, platformPrefabParent.transform);
                LoopPlatform platform2 = platformObj.GetComponent<LoopPlatform>();
                platform2.platformSpeed = platformSpeed;
                platform2.display = display;
                platform2.PathNodes.Add(platformStart);
                platform2.PathNodes.Add(platformEnd);
                platform2.index = 0;
                //设置启动
                platform2._isStart = true;


            }
        }
    }
    //找到父节点下的所有子节点
    public void FindAllChildren()
    {

        foreach (Transform child in platformPrefabParent.transform)
        {
           //获取子节点的脚本组件
           LoopPlatform platform = child.GetComponent<LoopPlatform>();
           if (platform != null)
           {
               if (platform.index == 0)
               {
                   platform.index = 1;
               }
               else if (platform.index == 1)
               {
                   platform.index = 0;
               }
           }
        }
    }
}
