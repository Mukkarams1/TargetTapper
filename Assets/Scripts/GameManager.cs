using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour

{
    public int TargetCount;
    int Levelnum=1 ;
    int BaselevelMultiplier = 10;
    public int tapCount;
    public GamePLayScript gameplayscript;
    float defultTimer = 2;
    public float Timer;
    public bool TimerHasended = false;
    public bool HasWon;
    public static int HighScore;
    public float CountDownTimer;
    public bool CountDownTimerHasEnded;
    public AudioSource clickaudioSource;
    public AudioClip ClickSound;
    public AudioClip[] ClickSoundsDifferent;
    public AudioSource BackGround;
    public AudioClip BackGroundSound;
    
    // Start is called before the first frame update
    void Start()
    {
        CountDownTimer = 3;
        CountDownTimerHasEnded = false;
        GetHighScore();
        defultTimer=PlayerPrefs.GetFloat("Defaulttimer",2);
        Timer = defultTimer;
        Levelnum=PlayerPrefs.GetInt("levelnum", 1);
        TargetCount = GetTargetTapCount(Levelnum);
        Debug.Log("TargetCount" + TargetCount);
        
    }

    // Update is called once per frame
    void Update()
    {

        if (CountDownTimerHasEnded==false)
        {
            gameplayscript.TargetCountUpdater();
            gameplayscript.GetReady.SetActive(true);
            CountDownTimer -= Time.deltaTime;
            gameplayscript.CountDownUpdater();
            if (CountDownTimer <= 0)
            {
                CountDownTimerHasEnded = true;
                gameplayscript.GetReady.SetActive(false);
                gameplayscript.DisableCountDownTimer();
                //BackGround.PlayOneShot(BackGroundSound);
                BackGround.Play();
            }
        
        
        }
        
        if (CountDownTimerHasEnded == true && TimerHasended == false)
        {
            
            Timer = Timer - Time.deltaTime;
            gameplayscript.TimerTxtUpdater();
            


        }
        if(Timer <= 0)
        {
            TimerHasended = true;
            Timer = 0;
            BackGround.Stop();

            if (tapCount >= TargetCount)//Win/Lose Script
           {
                HasWon = true;
            }
        else
            {
                HasWon = false;
            }
            gameplayscript.GameHasEnded();

        
        }
        if (tapCount > HighScore)
        {
            HighScore = tapCount;
        }
        gameplayscript.HighScoreUpdater();
        
        Debug.Log(HighScore);
        SaveHighScore();


        if (CountDownTimerHasEnded == true && !TimerHasended && !gameplayscript.GameisPause && Input.GetMouseButtonDown(0))
        {
            tapCount = tapCount + 1;
            BtnClickedSound();
            gameplayscript.TapcounterTextUpdater();

        }
    }
         
    public void SaveHighScore()
    {
        PlayerPrefs.SetInt("HighScore",HighScore);
        Debug.Log("highscoresaved" + HighScore);
    }
    public void GetHighScore()
    {
        HighScore=PlayerPrefs.GetInt("HighScore");
    }
    public void BtnClickedSound()
    {
        int RandonSounds = Random.Range(0, ClickSoundsDifferent.Length);
        AudioClip ClickSound = ClickSoundsDifferent[RandonSounds];
        clickaudioSource.PlayOneShot(ClickSound);

    }
    int GetTargetTapCount(int _Levelnum)
    {
        int temp = 0;
        temp = BaselevelMultiplier*_Levelnum;
        
        return temp;


    }
    public void LevelIncrease()
    {
        Levelnum++;
        defultTimer = defultTimer + 2;
        PlayerPrefs.SetInt("levelnum",Levelnum);
        PlayerPrefs.SetFloat("Defaulttimer", defultTimer);
    }
    public int GetLevelNum()
    {
        return Levelnum;
    }
    public void NewGame()
    {
        Levelnum = 1;
    }
    
}


