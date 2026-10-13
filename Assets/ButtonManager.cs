using JetBrains.Annotations;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public Tree tree;
    public Player player;
    public GameObject mainmenu;
    public GameObject gameoverpanel;
    public GameObject modepanel;
    public GameObject playerpanel;
    public GameControl gamecontrol;
    public ButtonSoundManager buttonsound;
    void Awake()
    {
        mainmenu.SetActive(false);
        gameoverpanel.SetActive(false);
    }
    public void Again()
    {
        buttonsound.RandomBranchSound();
        for(int i = 0; i < GameControl.players; i++)
        {
            tree.Again(i);
        }
        gamecontrol.StartPosition();
    }
    public void GameMode()
    {
        gameoverpanel.SetActive(false);
        modepanel.SetActive(true);
    }
    public void MainMenu()
    {
        buttonsound.RandomBranchSound();
        mainmenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void openmenu()
    {
        buttonsound.RandomBranchSound();
        mainmenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Back()
    {
        buttonsound.RandomBranchSound();
        mainmenu.SetActive(false);
        if (!gamecontrol.chill)
        {
            Time.timeScale = 1f;
        }
    }
    public void PlayerPanel()
    {
        playerpanel.SetActive(true);
    }
}
