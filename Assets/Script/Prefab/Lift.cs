using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lift : MonoBehaviour
{
    public Scope scope;
    private List<Vector3> PathNodes = new List<Vector3>();//记录箱子路径点位置
    [Tooltip("箱子路径点，第一个为初始点，最后一个为终点")]
    public List<GameObject> Nodes = new List<GameObject>();
    [Tooltip("箱子移动速度")]
    public float speed;
    void Start()
    {
        for (int i = 0; i < Nodes.Count; i++)
        {
            PathNodes.Add(Nodes[i].transform.position);

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (scope._isPlayer)
        {
            transform.position = Vector3.MoveTowards(
      transform.position,
      PathNodes[1],
      speed * Time.deltaTime);
        }
        else
        {
             transform.position = Vector3.MoveTowards(
      transform.position,
      PathNodes[0],
      speed * Time.deltaTime);
        }

    }
}
