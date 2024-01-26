using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverPanel : MonoBehaviour
{
    [SerializeField] TMP_Text currentScoreText;
    [SerializeField] TMP_Text bestScoreText;

    [SerializeField] GameObject newTextObj;
//[출처] 무작정 따라하는 유니티 게임 만들기 - 공 피하기 #6|작성자 바른 개발


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver(int score)//현재 점수 전달
    {
	    gameObject.SetActive(true); // gameOverPanel 오브젝트 활성화

		newTextObj.SetActive(false); 
        currentScoreText.text = score.ToString(); ;
    }
//[출처] 무작정 따라하는 유니티 게임 만들기 - 공 피하기 #6|작성자 바른 개발


}
