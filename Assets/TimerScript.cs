using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public bool stoptimer;
    public float time;
    int timerID;
    public Tree tree;
    public GameControl gamecontrol;
    public GameObject[] timer = new GameObject[4];
    public Slider sliderproperty;
    public RectTransform rectTransform;
    void Awake()
    {
        if (this.name == "Timer 1")
        {
            timerID = 0;
        }
        if (this.name == "Timer 2")
        {
            timerID = 1;
        }
        if (this.name == "Timer 3")
        {
            timerID = 2;
        }
        if (this.name == "Timer 4")
        {
            timerID = 3;
        }
        stoptimer = false;
        this.rectTransform = timer[timerID].GetComponent<RectTransform>();
        timer[timerID].SetActive(false);
    }

    void Update()
    {
        if (!stoptimer)
        {
            time -= Time.deltaTime;
            sliderproperty.value = time;
        }
        CheckOvertime();
        if(stoptimer && !gamecontrol.chill)
        {
            tree.GameOver(timerID);
        }
    }
    public void ResetTime(int i)
    {
        time = sliderproperty.maxValue;
    }
    public void SetTimer(int players, int player, List<float> positionx)
    {
        float y = -600f;
        float x = positionx[player] * 125;
        this.rectTransform.anchoredPosition = new Vector2(x, y);
    }
    public void CheckOvertime()
    {
        if (time >= (sliderproperty.maxValue - 0.1f) && gamecontrol.again && !gamecontrol.chill)
        {
            gamecontrol.again = false;
            timer[timerID].SetActive(true);
        }
        if (time <= 0)
        {
            time = 0;
            stoptimer = true;
        }
        if (stoptimer)
        {
            timer[timerID].SetActive(false);
        }
    }
}
