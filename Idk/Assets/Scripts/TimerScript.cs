using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerScript : MonoBehaviour
{
    [SerializeField]
    TMP_Text timerHUD;
    public int minutes;
    public int seconds;
    public float startTime;
    public bool isGameOver;

    // Start is called before the first frame update
    void Start()
    {
        startTime = 0;
        isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver)
        {
            TimeUpdate();
        }
    }

    void TimeUpdate()
    {
        //increment the time.
        startTime += Time.deltaTime;
        minutes = Mathf.FloorToInt(startTime/60);
        seconds = Mathf.FloorToInt(startTime%60);

        if(seconds > 9)
        {
            timerHUD.text = $"{minutes}:{seconds}";
        }
        else
        {
            timerHUD.text = $"{minutes}:0{seconds}";
        }
    }
}
