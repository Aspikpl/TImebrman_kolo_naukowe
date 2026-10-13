using UnityEngine;

public class Buttonintro : MonoBehaviour
{
    public GameObject[] panels = new GameObject[5];
    int currentpanel = 0;
    void Start()
    {
        for(int i = 0; i <= 4; i++)
        {
            panels[i].SetActive(false);
        }
        panels[0].SetActive(true);
    }
    public void moreonclick()
    {
        currentpanel++;
        if (currentpanel < 5)
        {
            panels[currentpanel].SetActive(true);
            panels[currentpanel - 1].SetActive(false);
        }
        if(currentpanel == 5)
        {
            currentpanel = 0;
            panels[currentpanel].SetActive(true);
            panels[4].SetActive(false);
        }
    }
    public void lessonclick()
    {
        currentpanel--;
        if (currentpanel >= 0)
        {
            panels[currentpanel].SetActive(true);
            panels[currentpanel + 1].SetActive(false);
        }
        if(currentpanel == -1)
        {
            currentpanel = 4;
            panels[currentpanel].SetActive(true);
            panels[0].SetActive(false);
        }
    }
}
