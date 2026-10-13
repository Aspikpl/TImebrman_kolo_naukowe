using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UIElements;

public class ModeManager : MonoBehaviour
{
    public GameControl gamecontrol;
    public GameObject Mode;
    public Pbtable pbtable;
    public Tree tree;
    public ButtonSoundManager buttonsound;
    public Player player;
    public TimerScript[] timerscript = new TimerScript[2];
    void Awake()
    {
        Time.timeScale = 0f;
    }
    public void Chill()
    {
        buttonsound.RandomBranchSound();
        pbtable.currentMode = "Chill";
        gamecontrol.chill = true;
        Mode.SetActive(false);
        if (!GameControl.treeprepared)
        {
            tree.SpawnTree();
            GameControl.treeprepared = true;
        }
        gamecontrol.StartPosition();
        for (int i = 0; i < GameControl.players; i++)
        {
            tree.Again(i);
        }
    }
    public void Easy()
    {
        buttonsound.RandomBranchSound();
        pbtable.currentMode = "Easy";
        gamecontrol.chill = false;
        for(int i = 0; i < 4; i++)
        {
            timerscript[i].time = 10f;
            timerscript[i].sliderproperty.maxValue = 10f;
        }
        Mode.SetActive(false);
        if (!GameControl.treeprepared)
        {
            tree.SpawnTree();
            GameControl.treeprepared = true;
        }
        Time.timeScale = 1f;
        for (int i = 0; i < GameControl.players; i++)
        {
            timerscript[i].timer[i].SetActive(true);
        }
        gamecontrol.StartPosition();
        for(int i = 0; i < GameControl.players; i++)
        {
            tree.Again(i);
        }
    }
    public void Medium()
    {
        buttonsound.RandomBranchSound();
        pbtable.currentMode = "Medium";
        gamecontrol.chill = false;
        for (int i = 0; i < 4; i++)
        {
            timerscript[i].time = 5f;
            timerscript[i].sliderproperty.maxValue = 5f;
        }
        Mode.SetActive(false);
        if (!GameControl.treeprepared)
        {
            tree.SpawnTree();
            GameControl.treeprepared = true;
        }
        Time.timeScale = 1f;
        for (int i = 0; i < GameControl.players; i++)
        {
            timerscript[i].timer[i].SetActive(true);
        }
        gamecontrol.StartPosition();
        for (int i = 0; i < GameControl.players; i++)
        {
            tree.Again(i);
        }
    }
    public void Hard()
    {
        buttonsound.RandomBranchSound();
        pbtable.currentMode = "Hard";
        gamecontrol.chill = false;
        for (int i = 0; i < 4; i++)
        {
            timerscript[i].time = 3f;
            timerscript[i].sliderproperty.maxValue = 3f;
        }
        Mode.SetActive(false);
        if (!GameControl.treeprepared)
        {
            tree.SpawnTree();
            GameControl.treeprepared = true;
        }
        Time.timeScale = 1f;
        for (int i = 0; i < GameControl.players; i++)
        {
            timerscript[i].timer[i].SetActive(true);
        }
        gamecontrol.StartPosition();
        for (int i = 0; i < GameControl.players; i++)
        {
            tree.Again(i);
        }
    }
    public void VaxMerstappen()
    {
        buttonsound.RandomBranchSound();
        pbtable.currentMode = "VaxMerstappen";
        gamecontrol.chill = false;
        for (int i = 0; i < 4; i++)
        {
            timerscript[i].time = 1.17f;
            timerscript[i].sliderproperty.maxValue = 1.17f;
        }
        Mode.SetActive(false);
        if (!GameControl.treeprepared)
        {
            tree.SpawnTree();
            GameControl.treeprepared = true;
        }
        Time.timeScale = 1f;
        for (int i = 0; i < GameControl.players; i++)
        {
            timerscript[i].timer[i].SetActive(true);
        }
        gamecontrol.StartPosition();
        for (int i = 0; i < GameControl.players; i++)
        {
            tree.Again(i);
        }
    }
}
