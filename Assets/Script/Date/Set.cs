using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Set : MonoBehaviour
{
    [Tooltip("0,设置菜单，1角色键位教学，2，怀表ui教学，3，普通小齿轮教学，4，手雷齿轮，5，地雷齿轮，6,菜单本身")]
    public List<GameObject> node = new List<GameObject>();
    [Tooltip("音乐大小")]
    public float musicvolume;
    [Tooltip("音效大小")]
    public float soundvolume;
    public Slider musicSlider;
    public Slider soundSlider;

    public Music music;
    public List<Sound> sound = new List<Sound>();

    public Game game;

    public Sound uiSound;
    void Awake()
    {
        closeall();
        //获取所有音效组件
        sound = new List<Sound>(FindObjectsOfType<Sound>());
        //获取游戏组件
        game = FindObjectOfType<Game>();
        music = FindObjectOfType<Music>();
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
            Debug.Log("打开设置菜单");
            if (node[0].activeSelf)
            {
                closeall();
                uiSound.PlaySound(0,3);
            }
            else
            {
                node[0].SetActive(true);
uiSound.PlaySound(0,3);
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
        uiSound.PlaySound(0,0);
    }
    //点击设置菜单
    public void close(int index)
    {
              uiSound.PlaySound(0,0);
        node[index].SetActive(false);
    }
    //调整音乐大小
    public void setmusicvolume(float volume)
    {
        music.volume = volume;
    }
    //调整音效大小
    public void setsoundvolume(float volume)
    {
        for (int i = 0; i < sound.Count; i++)
        {
            sound[i].volume = volume;
        }
    }
    //重玩游戏
    public void restart()
    {
        uiSound.PlaySound(0,0);
        if (game.level == 1)
            {
                SceneManager.LoadScene("Lv1");
            }
            else if (game.level == 2)
            {
                SceneManager.LoadScene("Lv2");
            }
            else if (game.level == 3)
            {
                SceneManager.LoadScene("Lv3");
            }
    }
    //返回主菜单
    public void back()
    {
        uiSound.PlaySound(0,0);
        SceneManager.LoadScene("main");
    }

}
