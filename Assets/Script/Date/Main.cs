using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    Game game;
    public GameObject node;
    public GameObject maker;
    void Start()
    {
        game = FindObjectOfType<Game>();
        if (game.level==0)
        {
            node.SetActive(true);
        }
        else
        {
            node.SetActive(false);
        }
        maker.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //点击时，打印点击的物体名字
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null)
            {
                Debug.Log(hit.collider.name);
            }
            //如果节显示
            if (maker.activeSelf == true)
            {
                maker.SetActive(false);
            }
        }
    }
    //转到对应关卡
    public void Skip(int level)
    {
        if (level == 1)
        {
            SceneManager.LoadScene("Lv1");
        }
        else if (level == 2)
        {
            SceneManager.LoadScene("Lv2");
        }
        else if (level == 3)
        {
            SceneManager.LoadScene("Lv3");
        }
        else if (level == 4)
        {
            SceneManager.LoadScene("Lv4");
        }
    }
    //退出游戏
    public void Exit()
    {
        Application.Quit();
    
    }
    //显示节
    public void ShowMaker()
    {
        maker.SetActive(true);
    }
}
