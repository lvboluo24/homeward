using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPut : MonoBehaviour
{
    [Tooltip("预制体")]
    public GameObject Prefab;
    [Tooltip("是否在单向平台上")]
    public bool _isOne;
        [Tooltip("生成点向下偏移距离")]
    public float spawnOffset = 0.5f;

    private Game game;

    void Start()
    {
        game = GameObject.Find("GameManager").GetComponent<Game>();
    }

    // Update is called once per frame
    void Update()
    {
         if (Input.GetKeyDown(KeyCode.Alpha3)&& game.gear[2] > 0)
        {
            if (_isOne)
            {
                Instantiate(Prefab, transform.position + Vector3.down * spawnOffset, Prefab.transform.rotation);
            }
            else
            {
                Instantiate(Prefab, transform.position, Prefab.transform.rotation);
            }
            game.gear[2]--;
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("One"))
        {
            _isOne = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("One"))
        {
            _isOne = false;
        }
    }
}
