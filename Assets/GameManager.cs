using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static GameManager Instance
    {
        get{
            if(_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
            }
            return _instance;
        }
    }

    [SerializeField]
    private GameObject bullet;

    private int score;

    [SerializeField]
    private TMP_Text scoreTxt;

    [SerializeField]
    private TMP_Text bestScore;
    [SerializeField]
    private GameObject panel;
    // Start is called before the first frame update

    private Coroutine createBulletRoutine;

    public bool IsGameOver;


    public void GameStart()
    {
        createBulletRoutine = StartCoroutine(CreatebulletRoutine());
        panel.SetActive(false);
    }

    public void GameOver(){
        StopCoroutine(createBulletRoutine);
        IsGameOver = true;

        // find all hearts
        var bullets = FindObjectsOfType<bullet>();
        foreach(var bullet in bullets){
            Destroy(bullet.gameObject);
        }

    }

    public void Score()
    {
        score ++;
        scoreTxt.text = "score : " +score;
    }

    IEnumerator CreatebulletRoutine()
    {
        while (true)
        {
            CreateBullet();
            yield return new WaitForSeconds(0.3f);
        }
    }

    private void CreateBullet()
    {
        Vector3 pos = Camera.main.ViewportToWorldPoint(new Vector3(UnityEngine.Random.Range(0.0f, 1.0f), 1.1f,0));
        pos.z = 0.0f;
        Instantiate(bullet,pos,Quaternion.identity);
        bullet.transform.rotation = Quaternion.Euler(0,0,-180f);
    }
}
