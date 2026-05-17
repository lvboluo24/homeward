using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBoomGear : MonoBehaviour
{
    [Tooltip("爆炸时间")]
    public float time;
    public Bomb bomb;
    void Start()
    {
        StartCoroutine(Boom());
    }

    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

        }
        else
        {
            bomb._isBoom = true;
            StartCoroutine(BoomFalse());
        }

    }
    //协程
    private IEnumerator Boom()
    {
        yield return new WaitForSeconds(time);
        bomb._isBoom = true;
        Debug.Log("爆炸");
        StartCoroutine(BoomFalse());

    }
    private IEnumerator BoomFalse()
    {
        yield return new WaitForSeconds(0.02f);
        gameObject.SetActive(false);
    }
}
