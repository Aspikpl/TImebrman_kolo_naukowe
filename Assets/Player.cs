using UnityEngine;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public bool facingright = true;
    public Animator animator;
    public Tree tree;
    public GameControl gamecontrol;
    public int players;
    public Player[] player = new Player[4];
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        animator = this.GetComponent<Animator>();
    }
    void Update()
    {
        if (this.name == "Player 1")
        {
            if (!tree.playerkeyboardactive[0])
            {
                return;
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                if (!facingright)
                {
                    Flip();
                }
                this.transform.position = new Vector2(gamecontrol.playersposition[0], -3.7f);
                animator.SetBool("Attacks", true);
                tree.DestroyTreePart(0);
                tree.AddBlock(0);
                tree.GameOver(0);
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                if (facingright)
                {
                    Flip();
                }
                this.transform.position = new Vector2(gamecontrol.playersposition[0] + 3, -3.7f);
                animator.SetBool("Attacks", true);
                tree.DestroyTreePart(0);
                tree.AddBlock(0);
                tree.GameOver(0);
            }
            else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
            {
                animator.SetBool("Attacks", false);
            }
        }
        if (this.name == "Player 2")
        {
            if (!tree.playerkeyboardactive[1])
            {
                return;
            }
            if (Input.GetKeyDown(KeyCode.H))
            {
                if (!facingright)
                {
                    Flip();
                }
                this.transform.position = new Vector2(gamecontrol.playersposition[1], -3.7f);
                animator.SetBool("Attacks", true);
                tree.DestroyTreePart(1);
                tree.AddBlock(1);
                tree.GameOver(1);
            }
            else if (Input.GetKeyDown(KeyCode.K))
            {
                if (facingright)
                {
                    Flip();
                }
                this.transform.position = new Vector2(gamecontrol.playersposition[1] + 3, -3.7f);
                animator.SetBool("Attacks", true);
                tree.DestroyTreePart(1);
                tree.AddBlock(1);
                tree.GameOver(1);
            }
            else if (Input.GetKeyUp(KeyCode.H) || Input.GetKeyUp(KeyCode.K))
            {
                animator.SetBool("Attacks", false);
            }
        }
        if (this.name == "Player 3")
        {
            if (!tree.playerkeyboardactive[2])
            {
                return;
            }
            if (Input.GetKeyDown(KeyCode.C))
            {
                if (!facingright)
                {
                    Flip();
                }
                this.transform.position = new Vector2(gamecontrol.playersposition[2], -3.7f);
                animator.SetBool("Attacks", true);
                tree.DestroyTreePart(2);
                tree.AddBlock(2);
                tree.GameOver(2);
            }
            else if (Input.GetKeyDown(KeyCode.B))
            {
                if (facingright)
                {
                    Flip();
                }
                this.transform.position = new Vector2(gamecontrol.playersposition[2] + 3, -3.7f);
                animator.SetBool("Attacks", true);
                tree.DestroyTreePart(2);
                tree.AddBlock(2);
                tree.GameOver(2);
            }
            else if (Input.GetKeyUp(KeyCode.C) || Input.GetKeyUp(KeyCode.B))
            {
                animator.SetBool("Attacks", false);
            }
        }
        if (this.name == "Player 4" )
        {
            if (!tree.playerkeyboardactive[3])
            {
                return;
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (!facingright)
                {
                    Flip();
                }
                this.transform.position = new Vector2(gamecontrol.playersposition[3], -3.7f);
                animator.SetBool("Attacks", true);
                tree.DestroyTreePart(3);
                tree.AddBlock(3);
                tree.GameOver(3);
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (facingright)
                {
                    Flip();
                }
                this.transform.position = new Vector2(gamecontrol.playersposition[3] + 3, -3.7f);
                animator.SetBool("Attacks", true);
                tree.DestroyTreePart(3);
                tree.AddBlock(3);
                tree.GameOver(3);
            }
            else if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
            {
                animator.SetBool("Attacks", false);
            }
        }
    }
    public void Flip()
    {
        facingright = !facingright;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    public void ActivePlayer()
    {
        if(players == 1)
        {
            player[0].gameObject.SetActive(true);
            player[1].gameObject.SetActive(false);
            player[2].gameObject.SetActive(false);
            player[3].gameObject.SetActive(false);
            gamecontrol.PlayersPositions();
        }
        if (players == 2)
        {
            player[0].gameObject.SetActive(true);
            player[1].gameObject.SetActive(true);
            player[2].gameObject.SetActive(false);
            player[3].gameObject.SetActive(false);
            gamecontrol.PlayersPositions();
        }
        if (players == 3)
        {
            player[0].gameObject.SetActive(true);
            player[1].gameObject.SetActive(true);
            player[2].gameObject.SetActive(true);
            player[3].gameObject.SetActive(false);
            gamecontrol.PlayersPositions();
        }
        if (players == 4)
        {
            player[0].gameObject.SetActive(true);
            player[1].gameObject.SetActive(true);
            player[2].gameObject.SetActive(true);
            player[3].gameObject.SetActive(true);
            gamecontrol.PlayersPositions();
        }
    }
}
