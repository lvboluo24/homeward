using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scope : MonoBehaviour
{

    public bool _isPlayer;
    [Tooltip("玩家图层")]
    public LayerMask targetLayer;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
if (other.CompareTag("Player"))
        {
            _isPlayer = true;
            Debug.Log("玩家进入范围");
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _isPlayer = false;
            Debug.Log("玩家离开范围");
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        

    }
}
