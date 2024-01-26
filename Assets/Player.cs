using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

public class Player : MonoBehaviour
{
     private Rigidbody2D rigidbody;

     private Animator animator;
     private SpriteRenderer renderer;

     private float speed = 3;

     private float horizontal;

     [SerializeField] GameOverPanel gameOverPanel;
     bool isGameOver;
     public void GameOver()
     {
        isGameOver = true;
        
        gameOverPanel.gameObject.SetActive(true);
     }

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        PlayerMove();
        ScreenChk();
    }

    private void PlayerMove()
    {
        // gameover면 안 움직임.
        if(GameManager.Instance.IsGameOver) return;

        animator.SetFloat("speed",Mathf.Abs(horizontal));
        if(horizontal < 0)
        {
            renderer.flipX = true;
        }
        else{
            renderer.flipX = false;
        }
        rigidbody.velocity = new Vector2(horizontal * speed, rigidbody.velocity.y);
    }
    private void ScreenChk()
    {
        Vector3 worlpos = Camera.main.WorldToViewportPoint(this.transform.position);
        if(worlpos.x < 0.05f) worlpos.x = 0.05f;
        if(worlpos.x > 0.95f) worlpos.x = 0.95f;
        this.transform.position = Camera.main.ViewportToWorldPoint(worlpos);
    } 
}
