using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PocketWatch : MonoBehaviour
{
        [Tooltip("0，怀表ui，1，大齿轮，2-7，小齿轮1-6")]
    public List<GameObject> node = new List<GameObject>();
    [Tooltip("齿轮数量列表")]
    public List<int> listGear = new List<int>();
        [Tooltip("图片列表,0,大齿轮，1，小齿轮，2，手雷齿轮，3，地雷齿轮")]
    public Sprite[] images;
    Game game;

    void Start()
    {
        game = FindObjectOfType<Game>();

            node[0].SetActive(false);
        

    }

    // Update is called once per frame
    void Update()
    {
        //按键F，显示
        if (Input.GetKeyDown(KeyCode.F))
        {
            //如果节点0显示
            if (node[0].activeSelf)
            {
                node[0].SetActive(false);
            }
            else
            {
                node[0].SetActive(true);
            }
        }
        //清所有齿轮
        listGear.Clear();
        for (int i = 0; i < game.gear[0]; i++)
        {
            listGear.Add(0);
        }
         for (int i = 0; i < game.gear[1]; i++)
        {
            listGear.Add(1);
        }
        for (int i = 0; i < game.gear[2]; i++)
        {
            listGear.Add(2);
        }
        //大齿轮
        if (game.gear[3] > 0)
        {   
            //显示节点1
            node[1].SetActive(true);
            //获取节点1的uamge组件
            Image image = node[1].GetComponent<Image>();
            image.sprite = images[3];
        }
        else
        {
            //隐藏节点1
            node[1].SetActive(false);
        }
        //正常齿轮
        for (int i = 0; i < 6; i++)
        {
            if (listGear.Count > i)
            {
                //显示节点2-7
                node[i+2].SetActive(true);
                //获取节点2-7的uamge组件
                Image image = node[i+2].GetComponent<Image>();
                image.sprite = images[listGear[i]];
            }
            else
            {
                //隐藏节点2-7
                node[i+2].SetActive(false);
            }
        }
    }
}
