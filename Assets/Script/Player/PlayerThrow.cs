using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(LineRenderer))]
public class ThrowItem2D : MonoBehaviour
{
    [Header("投掷基础")]
    public GameObject throwPrefab;
    [Tooltip("投掷力度")]
    public float throwForce = 12f;
    [Tooltip("投掷物生成点向前偏移距离")]
    public float spawnOffset = 0.6f;

    [Header("轨迹设置")]
    public int trajectorySteps = 35;
    public float timeStep = 0.05f;

    [Tooltip("是否开始投掷")]
    public bool isThrowBoom = false;

    private LineRenderer line;
    private Vector2 aimDir;
    private Game game;

    void Awake()
    {
        line = GetComponent<LineRenderer>();
        line.positionCount = trajectorySteps;
        game = GameObject.Find("GameManager").GetComponent<Game>();
    }

    void Update()
    {
        // 1. 获取鼠标瞄准方向
        Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        aimDir = (mouseWorldPos - (Vector2)transform.position).normalized;

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (!isThrowBoom)
            {
                isThrowBoom = true;
            }
            else
            {
                isThrowBoom = false;
            }
        }

        if (isThrowBoom)
        {
            // 2. 更新抛物线轨迹
            UpdateTrajectoryLine();

            // 3. 左键投掷
            if (Input.GetMouseButtonDown(0) && game.gear[1] > 0)
            {
                ThrowObject();
                game.gear[1]--;
            }
            //显示瞄准范围
            line.enabled = true;
        }
        else
        {
            //隐藏瞄准范围
            line.enabled = false;
        }


    }

    // 投掷逻辑
    void ThrowObject()
    {
        if (throwPrefab == null) return;

        // 向前偏移算出真实生成位置
        Vector2 spawnPos = (Vector2)transform.position + aimDir * spawnOffset;

        // 实例化
        GameObject throwObj = Instantiate(throwPrefab, spawnPos, Quaternion.identity);
        Rigidbody2D rb = throwObj.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            rb.velocity = aimDir * throwForce;
        }
    }

    // 计算绘制抛物线轨迹
    void UpdateTrajectoryLine()
    {
        List<Vector2> points = new List<Vector2>();
        // 轨迹起点也从偏移位置开始，视觉对齐
        Vector2 startPos = (Vector2)transform.position + aimDir * spawnOffset;
        Vector2 vel = aimDir * throwForce;
        Vector2 curPos = startPos;

        for (int i = 0; i < trajectorySteps; i++)
        {
            curPos += vel * timeStep;
            vel += Physics2D.gravity * timeStep;
            points.Add(curPos);
        }

        for (int i = 0; i < points.Count; i++)
        {
            line.SetPosition(i, points[i]);
        }
    }


}