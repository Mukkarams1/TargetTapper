using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePLayScript : MonoBehaviour
{


    public GameObject GameOver;
    public GameObject pause;
    public GameObject YouWin;
    public GameObject ResumebtnPasuse;
    public GameObject MainMenuBtnPause;
    public GameObject TapCounterTxt;
    public GameObject TimerTxT;
    public GameObject HighScoreTxT;
    public bool GameisPause;
    public Text CountDownTimerTXT;
    public GameObject TargetCountTxT;
    public GameManager gameManager;
    public GameObject GetReady;
    public AdManager adManager;

    


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        GameOver.SetActive(false);
        pause.SetActive(false);
        YouWin.SetActive(false);
        




    }
    private void Update()
    {
        
    }

    public void CountDownUpdater()
    {
        if (!gameManager.CountDownTimerHasEnded)
        {
            CountDownTimerTXT.text = gameManager.CountDownTimer.ToString("N0");
        }
    }

    public void DisableCountDownTimer()
    {
        CountDownTimerTXT.gameObject.SetActive(false);
    }
    
    
    
    public void PauseBtnClicked()
    {
        GameisPause = true;
        pause.SetActive(true);
        Time.timeScale = 0;
        gameManager.BackGround.Pause();



    }
    public void YouWinClicked()
    {
        pause.SetActive(false);
        YouWin.SetActive(true);
        
    }
    public void GameOverClicked()
    {
        GameOver.SetActive(false);
        YouWin.SetActive(false);
        
    }
    public void ResumeBtnPasueClicked()
    {
        pause.SetActive(false);
        gameManager.BackGround.UnPause();
        Time.timeScale = 1;
        GameisPause = false;
    }

   
    public void MainMenuPauseBtnClicked ()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
    

    public void TapcounterTextUpdater()
    {
        TapCounterTxt.GetComponent<Text>().text = gameManager.tapCount.ToString();
    }

    public void TimerTxtUpdater()
    {
        TimerTxT.GetComponent<Text>().text = gameManager.Timer.ToString("N0");

    }
    public void TargetCountUpdater()
    {
        TargetCountTxT.GetComponent<Text>().text = gameManager.TargetCount.ToString();

    }
    public void GameHasEnded()
    {
        
        if (gameManager.HasWon == true)
        {
            YouWin.SetActive(true);
            GameOver.SetActive(false);
            adManager.AdCalled();

        }
        if(gameManager.HasWon==false)
        {
            GameOver.SetActive(true);
            adManager.AdCalled();

        }
    }
    public void HighScoreUpdater()
    {
        HighScoreTxT.GetComponent<Text>().text = GameManager.HighScore.ToString();
    }
    public void NextLevelBtn()
    {
        gameManager.LevelIncrease();
        
        Debug.Log("Level Number" + gameManager.GetLevelNum());
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
    
}


