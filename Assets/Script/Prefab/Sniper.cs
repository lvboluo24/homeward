using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniper : MonoBehaviour
{
    [Tooltip("狙击时间")]
    public float sniperTime;
    [Tooltip("当前玩家存在视野的时间")]
    public float currentSniperTime;
    [Tooltip("箭移动速度")]
    public float moveSpeed;
    public Scope scope;
    [Tooltip("箭预制体")]
    public GameObject arrowPrefab;
    [Tooltip("箭生成位置")]
    public Transform arrowSpawnPoint;
    
private Player player;
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (scope._isPlayer)
        {
            currentSniperTime += Time.deltaTime;
            if (currentSniperTime >= sniperTime)
            {
                currentSniperTime = 0;
                GameObject arrow = Instantiate(arrowPrefab, arrowSpawnPoint.position, arrowPrefab.transform.rotation);
                arrow.GetComponent<Arrow>().moveSpeed = moveSpeed;
                arrow.GetComponent<Arrow>().moveDirection = (player.transform.position - arrowSpawnPoint.position).normalized;
                //如果狙击手缩放为正，箭的缩放也为正，旋转角度也为正
                if (transform.localScale.x > 0)
                {
                    arrow.transform.localScale = new Vector3(arrow.transform.localScale.x, arrow.transform.localScale.y, arrow.transform.localScale.z);
                    arrow.transform.rotation = Quaternion.Euler(arrow.transform.eulerAngles.x, arrow.transform.eulerAngles.y, arrow.transform.eulerAngles.z);
                }
                else if (transform.localScale.x < 0)
                {
                    arrow.transform.localScale = new Vector3(-arrow.transform.localScale.x, arrow.transform.localScale.y, arrow.transform.localScale.z);
                    arrow.transform.rotation = Quaternion.Euler(arrow.transform.eulerAngles.x, arrow.transform.eulerAngles.y, - arrow.transform.eulerAngles.z);
                }
            }
        }
        else
        {
            currentSniperTime = 0;
        }
    }
}
