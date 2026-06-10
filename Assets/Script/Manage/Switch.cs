using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    //切换世界类型
    private Game game;
    void Awake()
    {
        game = GameObject.Find("GameManager").GetComponent<Game>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //切换事件
    public void SwitchWorldType()
    {
        StartCoroutine(SwitchWorldTypeCoroutine());
    }

    //协程
    private IEnumerator SwitchWorldTypeCoroutine()
    {
        yield return new WaitForSeconds(0.5f);
    }

}
