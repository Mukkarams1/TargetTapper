using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class MainMenuScript : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject Settings;
    public GameObject HowToPlay;
    public GameObject Credits;
    public Animator SettingAnimator;
    public GameObject SettingBtn;
    private bool ismuted;
    public static GameObject checkmarkMute;
    public GameObject FadeImage;
    



    // Start is called before the first frame update
    void Start()
    {
        FadeImage.SetActive(true);
        FadeImage.GetComponent<Animator>().SetTrigger("Fade-in");
        ismuted = PlayerPrefs.GetInt("Muted") ==1;
        AudioListener.pause = ismuted;
        MainMenu.SetActive(true);
        Settings.SetActive(false);
        HowToPlay.SetActive(false);
        Credits.SetActive(false);
       





    }
    public void SettingButtonClicked()
    {
        MainMenu.SetActive(false);
        Settings.SetActive(true);
        SettingAnimator.SetTrigger("SettingBtnTrigger");
        SettingBtn.SetActive(false);


    }
    public void HowToPlayClicked()
    {
        MainMenu.SetActive(false);
        HowToPlay.SetActive(true);
       
    }
    public void CreditsbuttonClicked()
    {
        MainMenu.SetActive(false);
        Credits.SetActive(true);
        
    }
    public void BackbuttonClicked()
    {
        MainMenu.SetActive(true);
        
        SettingAnimator.SetTrigger("SettingPanelOutTrigger");
        StartCoroutine("DisableSettingPanel");
        
        
        HowToPlay.SetActive(false);
        Credits.SetActive(false);
    }
    public IEnumerator DisableSettingPanel()
    {

        yield return new WaitForSeconds(1);


        Settings.SetActive(false);
        SettingBtn.SetActive(true);
    }
    public void PlayBtnClicked()
    {
        FadeImage.GetComponent<Animator>().SetTrigger("Fade-out");
        StartCoroutine("DelayOnScene");

    }
    public IEnumerator DelayOnScene()
    {
        yield return new WaitForSeconds(.7f);
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
        


    }
    
    public void NewGameBtnClicked()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
        
        PlayerPrefs.DeleteKey("HighScore");PlayerPrefs.DeleteKey("Defaulttimer");PlayerPrefs.DeleteKey("levelnum");
       

    }
    public void MutePressed()
    {
        ismuted = !ismuted;
        AudioListener.pause = ismuted;
        
        PlayerPrefs.SetInt("Muted", ismuted ? 1 : 0);
        
    }
   



}   

