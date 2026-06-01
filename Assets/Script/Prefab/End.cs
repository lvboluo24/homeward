using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    public int Level;
    Transition transition;
    public bool _isEnd;
    public Game game;

    void Start()
    {
        transition = FindObjectOfType<Transition>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (Level == 2)
            {
                SceneManager.LoadScene("Lv2");
            }
            else if (Level == 3)
            {
                SceneManager.LoadScene("Lv3");
            }
            else if (Level == 4&&!_isEnd)
            {
                _isEnd = true;
                
                transition.playlevelend(4);
                Debug.Log("Lv4");
            }
        }

    }
}

