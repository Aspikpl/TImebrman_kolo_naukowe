using NUnit.Framework;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class GameControl : MonoBehaviour
{
    public bool again = false;
    public bool chill = false;
    public static bool treeprepared = false;
    public static int players;
    public GameObject playerpanel;
    public Pbtable pbtable;
    public Tree tree;
    public Player[] player = new Player[4];
    public TimerScript[] timerscript = new TimerScript[4];
    public GameObject[] pointstextgm = new GameObject[4];
    public List<float> playersposition = new List<float>();
    public void Numofplayers1()
    {
        tree.DestroyTrees();
        players = 1;
        playerpanel.SetActive(false);
        tree.SpawnTree();
        treeprepared = true;
        for(int i = 0; i < players; i++)
        {
            timerscript[i].SetTimer(1, i, tree.timerPlacementByPlayersNum);
        }
        PointsNeeded(1);
    }
    public void Numofplayers2()
    {
        tree.DestroyTrees();
        players = 2;
        playerpanel.SetActive(false);
        tree.SpawnTree();
        treeprepared = true;
        for (int i = 0; i < players; i++)
        {
            timerscript[i].SetTimer(2, i, tree.timerPlacementByPlayersNum);
        }
        PointsNeeded(2);
    }
    public void Numofplayers3()
    {
        tree.DestroyTrees();
        players = 3;
        playerpanel.SetActive(false);
        tree.SpawnTree();
        treeprepared = true;
        for (int i = 0; i < players; i++)
        {
            timerscript[i].SetTimer(3, i, tree.timerPlacementByPlayersNum);
        }
        PointsNeeded(3);
    }
    public void Numofplayers4()
    {
        tree.DestroyTrees();
        players = 4;
        playerpanel.SetActive(false);
        tree.SpawnTree();
        treeprepared = true;
        for (int i = 0; i < players; i++)
        {
            timerscript[i].SetTimer(4, i, tree.timerPlacementByPlayersNum);
        }
        PointsNeeded(4);
    }
    public void StartPosition()
    {
        int players = GameControl.players;
        for(int i = 0; i < players; i++)
        {
            if (!player[i].facingright)
            {
                player[i].Flip();
            }
            player[i].player[i].transform.position = new Vector2(playersposition[i], -3.7f);
            player[i].animator.SetBool("Attacks", false);
        }
    }
    public void PlayersPositions()
    {
        playersposition.Clear();
        int players = GameControl.players;
        for (int i = 0; i < players; i++)
        {
            playersposition.Add(Tree.treeParts[i][0].transform.position.x - 1.5f);
        }
    }
    public void PointsNeeded(int players)
    {
        for(int i = 0; i < 4; i++)
        {
            pointstextgm[i].SetActive(false);
        }
        for (int i = 0; i < players; i++)
        {
            pointstextgm[i].SetActive(true);
        }
    }
}
