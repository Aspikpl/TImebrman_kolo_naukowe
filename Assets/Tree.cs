using JetBrains.Annotations;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class Tree : MonoBehaviour
{
    GameObject[] treeprefab = new GameObject[5];
    GameObject[] treebranchleftprefab = new GameObject[5];
    GameObject[] treebranchrightprefab = new GameObject[5];
    GameObject[] treerootprefab = new GameObject[5];
    public GameObject gameoverpanel;
    public GameObject deathpanel;
    public GameObject mode;
    public GameObject[] playerdead = new GameObject[4];
    public GameControl gamecontrol;
    public GameObject skip;
    public GameObject settings;
    public Player player;
    public Pbtable pbtable;
    public TimerScript[] timerscript = new TimerScript[4];
    public AudioSource audiosource;
    public AudioClip[] audioclip = new AudioClip[8];
    public ButtonSoundManager buttonsoundmanager;
    public TMP_Text frequencytext;
    public TMP_Text qualitytext;
    public Sprite[] treesprite = new Sprite[5];
    public Sprite[] treespriteleft = new Sprite[5];
    public Sprite[] treespriteright = new Sprite[5];
    public Sprite[] rootsprite = new Sprite[5];
    int randomtreepart;
    string[] frequency = { "Each death", "5 deaths", "10 deaths", "Never" };
    int frequent = 0;
    int nextin = 1;
    int next = 1;
    int players = 1;
    int deadplayers = 0;
    int currentSprite = 0;
    public bool[] playerkeyboardactive = new bool[4];
    bool[] alreadydead = new bool[4];
    public static List<List<GameObject>> treeParts = new List<List<GameObject>>();
    List<float[]> treePlacementByPlayersNum = new List<float[]>();
    List<GameObject> roots = new List<GameObject>();
    List<float> PositionofPanel = new List<float>();
    public List<float> PositionofPoints = new List<float>();
    public List<float> timerPlacementByPlayersNum = new List<float>();
    void Awake()
    {
        treeprefab[0] = Resources.Load<GameObject>("Prefab/tree");
        treebranchleftprefab[0] = Resources.Load<GameObject>("Prefab/treebranch");
        treebranchrightprefab[0] = Resources.Load<GameObject>("Prefab/treebranchright");
        treerootprefab[0] = Resources.Load<GameObject>("Prefab/Root");

        treeprefab[1] = Resources.Load<GameObject>("Prefab/tree 1");
        treebranchleftprefab[1] = Resources.Load<GameObject>("Prefab/treebranch 1");
        treebranchrightprefab[1] = Resources.Load<GameObject>("Prefab/treebranchright 1");
        treerootprefab[1] = Resources.Load<GameObject>("Prefab/Root 1");

        treeprefab[2] = Resources.Load<GameObject>("Prefab/tree 2");
        treebranchleftprefab[2] = Resources.Load<GameObject>("Prefab/treebranch 2");
        treebranchrightprefab[2] = Resources.Load<GameObject>("Prefab/treebranchright 2");
        treerootprefab[2] = Resources.Load<GameObject>("Prefab/Root 2");

        treeprefab[3] = Resources.Load<GameObject>("Prefab/tree 3");
        treebranchleftprefab[3] = Resources.Load<GameObject>("Prefab/treebranch 3");
        treebranchrightprefab[3] = Resources.Load<GameObject>("Prefab/treebranchright 3");
        treerootprefab[3] = Resources.Load<GameObject>("Prefab/Root 3");

        treeprefab[4] = Resources.Load<GameObject>("Prefab/tree 4");
        treebranchleftprefab[4] = Resources.Load<GameObject>("Prefab/treebranch 4");
        treebranchrightprefab[4] = Resources.Load<GameObject>("Prefab/treebranchright 4");
        treerootprefab[4] = Resources.Load<GameObject>("Prefab/Root 4");

        deathpanel.SetActive(false);
        skip.SetActive(false);
        next = nextin;
        for(int i = 0; i < 4; i++)
        {
            alreadydead[i] = false;
        }
        for (int i = 0; i < 4; i++)
        {
            playerkeyboardactive[i] = true;
        }
        for(int i = 0; i < 4; i++)
        {
            playerdead[i].SetActive(false);
        }
    }
    public void SpawnTree()
    {
        float maxheight = 9.26f;
        float currentheight = -3.7f;
        Vector2 currentposition;
        GameObject newPart = null;
        players = GameControl.players;
        treePlacementByPlayersNum.Clear();
        timerPlacementByPlayersNum.Clear();
        PositionofPanel.Clear();
        PositionofPoints.Clear();
        if (players == 1)
        {
            treePlacementByPlayersNum.Add(new float[] { 0f });
        }
        if (players == 2)
        {
            treePlacementByPlayersNum.Add(new float[] { -5f, 5f });
        }
        if (players == 3)
        {
            treePlacementByPlayersNum.Add(new float[] { -6f, 0f, 6f });
        }
        if (players == 4)
        {
            treePlacementByPlayersNum.Add(new float[] { -7f, -2.5f, 2.5f, 7f });
        }
        for (int i = 0; i < players; i++)
        {
            treeParts.Add(new List<GameObject>());
            float x = treePlacementByPlayersNum[0][i];
            if (currentheight == -3.7f)
            {
                newPart = Instantiate(treeprefab[currentSprite], new Vector2(x, -3.7f), Quaternion.identity);
                treeParts[i].Add(newPart);
                newPart = null;
                roots.Add(Instantiate(treerootprefab[currentSprite], new Vector2(x, -4.65f), Quaternion.identity));
                PositionofPanel.Add(x);
                PositionofPoints.Add(x);
                pbtable.SetPointPosition(i);
                timerPlacementByPlayersNum.Add(x);
            }
            while (currentheight < maxheight)
            {
                randomtreepart = Random.Range(0, 3);
                currentheight += 1.44f;
                currentposition = new Vector2(x, currentheight);
                if (randomtreepart == 0)
                {
                    newPart = Instantiate(treeprefab[currentSprite], currentposition, Quaternion.identity);
                }
                else if (randomtreepart == 1)
                {
                    newPart = Instantiate(treebranchleftprefab[currentSprite], currentposition, Quaternion.identity);
                }
                else if (randomtreepart == 2)
                {
                    newPart = Instantiate(treebranchrightprefab[currentSprite], currentposition, Quaternion.identity);
                }
                treeParts[i].Add(newPart);
            }
            currentheight = -3.7f;
        }
        player.players = GameControl.players;
        player.ActivePlayer();
    }
    public void DestroyTreePart(int i)
    {
        int randomint = Random.Range(0, 6);
        GameObject LowestPart = null;
        float lowestY = 10f;
        foreach (GameObject part in treeParts[i])
        {
            if (part.transform.position.y < lowestY)
            {
                lowestY = part.transform.position.y;
                LowestPart = part;
            }
        }
        if (LowestPart != null)
        {
            if (pbtable.point[i] < 1)
            {
                audiosource.PlayOneShot(audioclip[6]);
            }
            else
            {
                audiosource.PlayOneShot(audioclip[randomint]);
            }
            treeParts[i].Remove(LowestPart);
            Destroy(LowestPart);
            timerscript[i].ResetTime(i);
        }
        foreach (GameObject part in treeParts[i])
        {
            Vector2 currentPosition = part.transform.position;
            part.transform.position = new Vector2(currentPosition.x, currentPosition.y - 1.44f);
        }
        pbtable.AddPoint(i);
    }
    public void AddBlock(int i)
    {
        randomtreepart = Random.Range(0, 3);
        float height = 9.26f;
        GameObject newPart = null;
        players = GameControl.players;
        if (players == 1)
        {
            treePlacementByPlayersNum.Add(new float[] { 0f });
        }
        if (players == 2)
        {
            treePlacementByPlayersNum.Add(new float[] { -5f, 5f });
        }
        if (players == 3)
        {
            treePlacementByPlayersNum.Add(new float[] { -6f, 0f, 6f });
        }
        if (players == 4)
        {
            treePlacementByPlayersNum.Add(new float[] { -7f, -2.5f, 2.5f, 7f });
        }
        float x = treePlacementByPlayersNum[0][i];
        Vector2 currentposition = new Vector2(x, height);
        if (randomtreepart == 0)
        {
            newPart = Instantiate(treeprefab[currentSprite], currentposition, Quaternion.identity);
        }
        else if (randomtreepart == 1)
        {
            newPart = Instantiate(treebranchleftprefab[currentSprite], currentposition, Quaternion.identity);
        }
        else if (randomtreepart == 2)
        {
            newPart = Instantiate(treebranchrightprefab[currentSprite], currentposition, Quaternion.identity);
        }
        treeParts[i].Add(newPart);
    }
    public void GameOver(int i)
    {
        GameObject LowestPart = null;
        float lowestY = 10f;
        foreach (GameObject part in treeParts[i])
        {
            if (part.transform.position.y < lowestY)
            {
                lowestY = part.transform.position.y;
                LowestPart = part;
            }
        }
        if (!alreadydead[i] && (timerscript[i].stoptimer || (LowestPart.tag == treebranchleftprefab[currentSprite].tag && player.player[i].facingright) || (LowestPart.tag == treebranchrightprefab[currentSprite].tag && !player.player[i].facingright)))
        {
            playerkeyboardactive[i] = false;
            alreadydead[i] = true;
            timerscript[i].stoptimer = true;
            if (players == 1)
            {
                pbtable.scoretext.text = "Score: " + pbtable.point;
                pbtable.ShowScore1player();
                pbtable.Score(pbtable.point[i]);
            }
            pbtable.pointstext[i].text = "Points: " + pbtable.point[i];
            if(players > 1)
            {
                ActivateDeadPlayerPanel(i);
                pbtable.ShowScore(i);
            }
            deadplayers++;
            player.player[i].animator.SetBool("Attacks", false);
            if (players == 1 && deadplayers == players)
            {
                next--;
                if (next == 0)
                {
                    deathpanel.SetActive(true);
                    next = nextin;
                }
                GameControl.treeprepared = false;
                gameoverpanel.SetActive(true);
                DestroyTrees();
                Time.timeScale = 0f;
                deadplayers = 0;
            }
            else if(players > 1 && players == deadplayers)
            {
                GameControl.treeprepared = false;
                Time.timeScale = 0f;
                deadplayers = 0;
                skip.SetActive(true);
                settings.SetActive(false);
            }
        }
    }
    public void Again(int i)
    {
        if(i == 0)
        {
            deathpanel.SetActive(false);
            pbtable.ResetTable();
            gamecontrol.again = true;
            if (!GameControl.treeprepared)
            {
                SpawnTree();
                GameControl.treeprepared = true;
            }
        }
        timerscript[i].stoptimer = false;
        timerscript[i].ResetTime(i);
        alreadydead[i] = false;
        for(int j = 0; j < players; j++)
        {
            gameoverpanel.SetActive(false);
            pbtable.points.SetActive(true);
            playerkeyboardactive[j] = true;
            player.animator.SetBool("Attacks", false);
            if (!gamecontrol.chill)
            {
                Time.timeScale = 1f;
                timerscript[i].timer[i].SetActive(true);
            }
        }
        gamecontrol.PlayersPositions();
    }
    public void Skip()
    {
        buttonsoundmanager.RandomBranchSound();
        deathpanel.SetActive(false);
    }
    public void SkipMultiplayer()
    {
        for (int j = 0; j < players; j++)
        {
            playerdead[j].SetActive(false);
        }
        gameoverpanel.SetActive(true);
        skip.SetActive(false);
        settings.SetActive(true);
        DestroyTrees();
    }
    public void More()
    {
        buttonsoundmanager.RandomBranchSound();
        if(frequent < 3)
        {
            frequent++;
            if (frequency[frequent] == "Each death")
            {
                nextin = 1;
                next = 1;
                frequencytext.text = frequency[frequent];
            }
            else if (frequency[frequent] == "5 deaths")
            {
                nextin = 5;
                next = 5;
                frequencytext.text = frequency[frequent];
            }
            else if (frequency[frequent] == "10 deaths")
            {
                nextin = 10;
                next = 10;
                frequencytext.text = frequency[frequent];
            }
            else if (frequency[frequent] == "Never")
            {
                nextin = -1;
                next = -1;
                frequencytext.text = frequency[frequent];
            }
        }
    }
    public void Less()
    {
        buttonsoundmanager.RandomBranchSound();
        if (frequent > 0)
        {
            frequent--;
            if (frequency[frequent] == "Each death")
            {
                nextin = 1;
                next = 1;
                frequencytext.text = frequency[frequent];
            }
            else if (frequency[frequent] == "5 deaths")
            {
                nextin = 5;
                next = 5;
                frequencytext.text = frequency[frequent];
            }
            else if (frequency[frequent] == "10 deaths")
            {
                nextin = 10;
                next = 10;
                frequencytext.text = frequency[frequent];
            }
            else if (frequency[frequent] == "Never")
            {
                nextin = -1;
                next = -1;
                frequencytext.text = frequency[frequent];
            }
        }
    }
    public void DestroyTrees()
    {
        foreach(List<GameObject> tree in treeParts)
        {
            foreach(GameObject child in tree)
            {
                Destroy(child);
            }
            tree.Clear();
        }
        foreach(GameObject root in roots)
        {
            Destroy(root);
        }
        roots.Clear();
    }
    void ActivateDeadPlayerPanel(int i)
    {
        playerdead[i].transform.position = new Vector2(PositionofPanel[i], 0);
        playerdead[i].SetActive(true);
    }
    void ChangeInstantiatesGraphic(int i)
    {
        GameObject[] treeprefabs = GameObject.FindGameObjectsWithTag("TreePart");
        GameObject[] treeprefabsleft = GameObject.FindGameObjectsWithTag("TreebranchPart");
        GameObject[] treeprefabsright = GameObject.FindGameObjectsWithTag("TreeBranchRightPart");
        GameObject[] rootprefabs = GameObject.FindGameObjectsWithTag("Root");

        foreach(GameObject treepart in treeprefabs)
        {
            treepart.GetComponent<SpriteRenderer>().sprite = treesprite[i];
        }
        foreach (GameObject treepart in treeprefabsleft)
        {
            treepart.GetComponent<SpriteRenderer>().sprite = treespriteleft[i];
        }
        foreach (GameObject treepart in treeprefabsright)
        {
            treepart.GetComponent<SpriteRenderer>().sprite = treespriteright[i];
        }
        foreach (GameObject treepart in rootprefabs)
        {
            treepart.GetComponent<SpriteRenderer>().sprite = rootsprite[i];
            if(i == 0)
            {
                treepart.transform.localScale = new Vector3(1.5f, 1.5f, 1f);
            }
            if(i > 0)
            {
                treepart.transform.localScale = new Vector3(3f, 1.5f, 1f);
            }
        }
        if (i == 4)
        {
            qualitytext.text = "Potato";
        }
        if (i == 3)
        {
            qualitytext.text = "Low";
        }
        if (i == 2)
        {
            qualitytext.text = "Medium";
        }
        if (i == 1)
        {
            qualitytext.text = "High";
        }
        if (i == 0)
        {
            qualitytext.text = "4K";
        }
    }
    public void BetterSprite()
    {
        if(currentSprite > 0)
        {
            currentSprite--;
            ChangeInstantiatesGraphic(currentSprite);
        }
    }
    public void WorseSprite()
    {
        if (currentSprite < 4)
        {
            currentSprite++;
            ChangeInstantiatesGraphic(currentSprite);
        }
    }
}
