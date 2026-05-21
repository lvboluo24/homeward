using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BellButton : MonoBehaviour
{
    // Start is called before the first frame update
    [Tooltip("玩家在互动范围内")]
    public bool _isPlayer;
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
        //按键1
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (_isPlayer && game.gear[3] >= 1)
            {
                game.clockStatus++;
                game.gear[3]--;
                game.StartCoroutine(game.Clock());
                Debug.Log("钟摆状态为1");
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _isPlayer = true;

        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _isPlayer = false;
        }
    }
}
