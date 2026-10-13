using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using static UnityEngine.Rendering.DebugUI;
using System.Linq;

public class Pbtable : MonoBehaviour
{
    public Tree tree;
    public TMP_Text[] pointstext = new TMP_Text[4];
    public GameObject points;
    public TMP_Text mode;
    public TMP_Text scoretext;
    public TMP_Text[] scoretexts = new TMP_Text[4];
    public GameObject scoretextgo;
    public GameObject pbtable;
    public TextMeshProUGUI[] score;
    public RectTransform[] recttransform = new RectTransform[4];
    public int[] point = new int[4];
    int maxscores = 10;
    public string currentMode;
    public Dictionary<string, List<int>> pb = new Dictionary<string, List<int>>();
    void Start()
    {
       for(int i = 0; i < 4; i++)
        {
            point[i] = 0;
        }
    }
    public void Score(int point)
    {
        if (!pb.ContainsKey(currentMode))
        {
            pb[currentMode] = new List<int>();
        }
        List<int> currentPb = pb[currentMode];
        currentPb.Add(point);
        pb[currentMode] = currentPb.OrderByDescending(s => s).ToList();
        if (pb[currentMode].Count > maxscores)
        {
            pb[currentMode].RemoveAt(maxscores);
        }
        UpdatePBtable();
    }
    void UpdatePBtable()
    {
        List<int> currentScores = new List<int>();
        if(currentMode == "Chill")
        {
            mode.text = "Chill";
        }
        if(currentMode == "Easy")
        {
            mode.text = "Easy";
        }
        if (currentMode == "Medium")
        {
            mode.text = "Medium";
        }
        if (currentMode == "Hard")
        {
            mode.text = "Hard";
        }
        if (currentMode == "VaxMerstappen")
        {
            mode.text = "Vax Merstappen";
        }
        if (pb.ContainsKey(currentMode))
        {
            currentScores = pb[currentMode];
        }
        for (int i = 0; i < score.Length; i++)
        {
            if (i < currentScores.Count)
            {
                score[i].text = $"{i + 1}. {currentScores[i]}";
            }
            else
            {
                score[i].text = $"{i + 1}. 0";
            }
        }
    }
    public void AddPoint(int i)
    {
        point[i]++;
        pointstext[i].text = "Points: " + point[i];
    }
    public void ResetTable()
    {
        for(int i = 0; i < 4; i++)
        {
            point[i] = 0;
            pointstext[i].text = "Points: " + point[i];
        }
    }
    public void ShowScore(int i)
    {
        scoretexts[i].text = "Score: " + point[i];
    }
    public void ShowScore1player()
    {
        scoretext.text = "Score: " + point[0];
    }
    public void SetPointPosition(int i)
    {
        recttransform[i].anchoredPosition = new Vector2(tree.PositionofPoints[i] * 120, 550f);
    }
}
