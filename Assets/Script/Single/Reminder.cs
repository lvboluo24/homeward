using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Reminder : MonoBehaviour
{
    public bool _isPlayer;
    public int index;
    //文字组件
    public Text reminderText;
    void Start()
    {
        index = 0;
        reminderText.enabled = false;
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
            if (index == 0)
            {
                StartCoroutine(ReminderCo());
            }

        }
    }
    //协程
    private IEnumerator ReminderCo()
    {
        reminderText.enabled = true;
        index = 1;
        //文字透明度为0
        reminderText.color = new Color(reminderText.color.r, reminderText.color.g, reminderText.color.b, 0f);
        reminderText.DOFade(1, 2f);
        yield return new WaitForSeconds(3f);
        reminderText.DOFade(0, 2f);
        yield return new WaitForSeconds(2f);
        reminderText.enabled = false;
    }
}
