using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Grid : MonoBehaviour
{

    public List<Tile> tiles = new List<Tile>();
    public List<Background> backgrounds = new List<Background>();
    private Game game;
    [Tooltip("遮盖预制体")]
    public GameObject Cover;
    Player player;
        [Tooltip("正在转换")]
    public bool isConverting;
    void Awake()
    {

        game = FindObjectOfType<Game>();
        player = FindObjectOfType<Player>();
        //获取所有瓦片组件
        tiles = new List<Tile>(FindObjectsOfType<Tile>());
        //获取所有背景组件
        backgrounds = new List<Background>(FindObjectsOfType<Background>());
    }
    void Start()
    {
        CheckWorldType();
    }

    // Update is called once per frame
    void Update()
    {

    }
    //检测瓦片世界类型
    public void CheckWorldType()
    {
        StartCoroutine(CheckWorldTypeCoroutine());
    }
    //协程
    public IEnumerator CheckWorldTypeCoroutine()
    {
        //生成预制体
        isConverting = true;
        GameObject throwObj = Instantiate(Cover, player.transform.position, Quaternion.identity);
        Cover cover = throwObj.GetComponent<Cover>();
        cover.type = 0;
        cover.CoverTile();
        //变化瓦片遮盖状态
        foreach (Tile tile in tiles)
        {
            tile.ChangeCoverType1();
        }
        foreach (Background background in backgrounds)
        {
            background.CoverTile1();
        }
        yield return new WaitForSeconds(0.5f);
        foreach (Tile tile in tiles)
        {
            tile.ChangeCoverType2();
        }
        foreach (Background background in backgrounds)
        {
            background.CoverTile2();
        }
        yield return new WaitForSeconds(0.6f);
        isConverting = false;
    }


}
