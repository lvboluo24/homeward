using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Tile : MonoBehaviour
{
    TilemapRenderer tilemapRenderer;

    TilemapCollider2D tilemapCollider2D;
    [Tooltip("0,和平，1，战争")]
    public int worldType;
    [Tooltip("类型，0,1正常，1，隐蔽瓦片")]
    public int tileType;
    Game game;
    void Awake()
    {
                tilemapRenderer = GetComponent<TilemapRenderer>();
        tilemapCollider2D = GetComponent<TilemapCollider2D>();
        game = FindObjectOfType<Game>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    //显示
    public void ShowTile()
    {
        tilemapRenderer.enabled = true;
        tilemapCollider2D.enabled = true;
    }
    //隐藏
    public void HideTile()
    {
        tilemapRenderer.enabled = false;
        tilemapCollider2D.enabled = false;
    }
    //遮罩类型改变
    public void ChangeCoverType1()
    {
        tilemapRenderer.enabled = true;
        
        if (game.worldType == worldType)
        {
            tilemapRenderer.maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
tilemapCollider2D.enabled = true;
        }
        else
        {
            tilemapRenderer.maskInteraction = SpriteMaskInteraction.VisibleOutsideMask;
            tilemapCollider2D.enabled = false;
        }
    }
    public void ChangeCoverType2()
    {
        tilemapRenderer.maskInteraction = SpriteMaskInteraction.None;
        if (game.worldType == worldType)
        {
            ShowTile();
        }
        else
        {
            HideTile();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && tileType == 1 && game.worldType == worldType)
        {
            tilemapRenderer.enabled = false;

        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && tileType == 1 && game.worldType == worldType)
        {
            tilemapRenderer.enabled = true;

        }
    }

}
