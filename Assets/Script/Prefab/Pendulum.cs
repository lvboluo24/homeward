using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum : MonoBehaviour
{
    [Header("旋转中心点")]
    public Transform centerPoint;

    [Header("最大摆动角度")]
    public float maxAngle = 45f;

    [Header("摆动周期（秒）")]
    public float swingTime = 2f;

    private float _timer;
[Header("是否摆动")]
public bool isSwing = false;


    void Update()
    {
        if (!isSwing)
        {
            return;
        }
        // 累计时间
        _timer += Time.deltaTime;

        // 用正弦曲线生成 -1 ~ 1 的平滑值（时间控制）
        float smoothValue = Mathf.Sin(_timer * Mathf.PI / swingTime);

        // 计算目标角度
        float targetAngle = smoothValue * maxAngle;

        // 绕 Z 轴旋转到目标角度（RotateAround 2D专用）
        Vector3 forward = Vector3.forward;
        transform.RotateAround(centerPoint.position, forward, targetAngle - transform.localEulerAngles.z);
    }
}
