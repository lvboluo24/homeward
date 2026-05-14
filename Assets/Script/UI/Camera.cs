using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera: MonoBehaviour
{
    // Start is called before the first frame update
    [Tooltip("地图x，y坐标")]
    public int x,y;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(x*17.77777f,y*10,-10);
    }
}
