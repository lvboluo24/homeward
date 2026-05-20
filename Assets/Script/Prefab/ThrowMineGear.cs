using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowMineGear : MonoBehaviour
{
    [Tooltip("爆炸时间")]
    public float time;
    public Mine mine;
    void Start()
    {
        StartCoroutine(Boom());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator Boom()
    {
        yield return new WaitForSeconds(time);
        mine._isBoom = true;
        Debug.Log("爆炸");
        StartCoroutine(BoomFalse());
    }
    private IEnumerator BoomFalse()
    {
        yield return new WaitForSeconds(0.02f);
        gameObject.SetActive(false);
    }
}
