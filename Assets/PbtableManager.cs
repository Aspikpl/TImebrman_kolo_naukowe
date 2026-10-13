using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using static UnityEngine.Rendering.DebugUI;
using System.Linq;

public class PbtableManager : MonoBehaviour
{
    Tree tree;
    TMP_Text points;
    public GameObject pbtable;
    public TextMeshProUGUI[] score;
    public int point;
    int maxscores = 10;
    List<int> pb = new List<int>();
    void Awake()
    {
        tree = GameObject.Find("TreeManager").GetComponent<Tree>();
        points = GameObject.Find("Points").GetComponent<TMP_Text>();
        pbtable = GameObject.Find("PB table");
        pbtable.SetActive(false);
    }
    public void Score(int point)
    {
        pbtable.SetActive(true);
        pb.Add(point);
        pb = pb.OrderByDescending(a => a).ToList();
        if (pb.Count > maxscores)
        {
            pb.RemoveAt(maxscores);
        }
        UpdatePBtable();
        point = 0;
        points.text = "Points: " + point;
    }
    void UpdatePBtable()
    {
        for (int i = 0; i < score.Length; i++)
        {
            if (i < pb.Count)
            {
                score[i].text = $"{i + 1}. {score[i]}";
            }
            else
            {
                score[i].text = $"{i + 1}. 0";
            }
        }
    }
}
