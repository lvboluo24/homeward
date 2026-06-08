using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public GameObject peaceBackground;
    public GameObject warBackground;
        private Game game;
        //获取sr
        public SpriteRenderer peaceBackgroundSr;
        
            void Awake()
    {

        game = GameObject.Find("GameManager").GetComponent<Game>();
               Shader grayShader = Shader.Find("Sprites/Default");
        
        Material mat = new Material(grayShader);
        mat.color = new Color(0.299f, 0.587f, 0.114f, 1); // 真实黑白公式
        
        peaceBackgroundSr.material = mat;
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
