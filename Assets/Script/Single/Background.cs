using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public GameObject peaceBackground;
    public GameObject warBackground;
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
        CheckBackgroundWorldType();
    }
    //检测背景世界类型
    public void CheckBackgroundWorldType()
    {
        if (game.worldType == 0)
        {
            peaceBackground.SetActive(true);
            warBackground.SetActive(false);
        }
        else if (game.worldType == 1)
        {
            peaceBackground.SetActive(false);
            warBackground.SetActive(true);
        }
    }
}
