using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Cover : MonoBehaviour
{
    //遮盖
    [Tooltip("0,从小到大，1，从大到小")]
    public int type;
    [Tooltip("缩放到最大大小")]
    public float maxSizeScale;
    [Tooltip("缩放时间")]
    public float scaleTime;
    void Start()
    {
        CoverTile();
    }

    // Update is called once per frame
    void Update()
    {

    }
    //遮盖逻辑
    public void CoverTile()
    {
        StartCoroutine(CoverTileCoroutine());
    }
    //协程
    public IEnumerator CoverTileCoroutine()
    {
        if (type == 0)
        {
            //初始尺寸为0
            transform.localScale = Vector3.zero;
            //慢慢变大
            transform.DOScale(new Vector3(maxSizeScale, maxSizeScale, maxSizeScale), scaleTime);
            yield return new WaitForSeconds(scaleTime);
            //摧毁
            Destroy(gameObject);
        }
        else if (type == 1)
        {
            //初始尺寸为最大尺寸
            transform.localScale = new Vector3(maxSizeScale, maxSizeScale, maxSizeScale);
            //慢慢变小
            transform.DOScale(new Vector3(0, 0, 0), scaleTime);
            yield return new WaitForSeconds(scaleTime);
            //摧毁
            Destroy(gameObject);
        }




    }
}
