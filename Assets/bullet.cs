using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            GameManager.Instance.Score();
            Destroy(this.gameObject);
        }

        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("게임종료");

            FindObjectOfType<Player>().GameOver();
            GameManager.Instance.GameOver();
            Destroy(this.gameObject);
        }
    }
}
