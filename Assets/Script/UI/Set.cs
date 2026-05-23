using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Set : MonoBehaviour
{
    [Tooltip("0,设置菜单，1角色键位教学，2，怀表ui教学，3，普通小齿轮教学，4，手雷齿轮，5，地雷齿轮，6，大齿轮")]
    public List<GameObject> node = new List<GameObject>();
    [Tooltip("音乐大小")]
    public float musicvolume;
    [Tooltip("音效大小")]
    public float soundvolume;
    public Slider musicSlider;
    public Slider soundSlider;
    void Awake()
    {
        node[0].SetActive(false);
    }
    void Start()
    {
        musicSlider.onValueChanged.AddListener(setmusicvolume);
        soundSlider.onValueChanged.AddListener(setsoundvolume);
    }

    // Update is called once per frame
    void Update()
    {
        //点击ESC键，关闭设置
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (node[0].activeSelf)
            {
                closeall();
            }
            else
            {
                node[0].SetActive(true);
            }
        }
    }
    //关闭设置
    public void closeall()
    {
        for (int i = 0; i < node.Count; i++)
        {
            node[i].SetActive(false);
        }
    }
    //点击设置菜单
    public void open(int index)
    {
        node[index].SetActive(true);
    }
    //点击设置菜单
    public void close(int index)
    {
        node[index].SetActive(false);
    }
    //调整音乐大小
    public void setmusicvolume(float volume)
    {
        musicvolume = volume;
    }
    //调整音效大小
    public void setsoundvolume(float volume)
    {
        soundvolume = volume;
    }
}
