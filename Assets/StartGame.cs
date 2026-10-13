using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.Rendering.DebugUI;

public class StartGame : MonoBehaviour
{
    public GameObject panel;
    public GameObject startbutton;
    public GameObject reviewsbutton;
    void Awake()
    {
        panel.SetActive(false);
    }
    public void ButtonOnClickStart()
    {
        SceneManager.LoadScene("Game");
    }
    public void OpenReviewspanel()
    {
        panel.SetActive(true);
        startbutton.SetActive(false);
        reviewsbutton.SetActive(false);
    }
    public void CloseReviewpanel()
    {
        panel.SetActive(false);
        startbutton.SetActive(true);
        reviewsbutton.SetActive(true);
    }
}
