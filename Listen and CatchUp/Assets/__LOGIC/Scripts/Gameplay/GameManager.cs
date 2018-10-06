using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonBehaviour<GameManager> {

    public Timer GameTimer;
    public MenuCube Play;

    public GameObject MainMenu;
    public GameObject InGameInterface;
    public GameOverWindow GameOverWindow;
    public WordGrid Gerador;
   

    [Header("Audio")]
    [Header("FX")]
    public AudioClip RightAudio;
    public AudioClip WrongAudio;
    [Header("BGM")]
    public AudioClip[] MenuAudio;
    public AudioClip[] IngameAudio;


    private Score _score;


	// Use this for initialization
	void Start ()
	{
	    Play.OnClicked += cube => StartCampaing();
	    GameTimer.OnTimerFinished += (timer)=>EndCampaing();
        WordManager.Instance.OnOutOfWords += EndCampaing;
        ShowMainScreen();

    }
	
	// Update is called once per frame
	void Update () {
		
	}


    public void StartCampaing()
    {
        AnimationManager.Instance.InGame();
        MainMenu.SetActive(false);
        InGameInterface.SetActive(true);
        Gerador.GenerateGrid();
        GameTimer.gameObject.SetActive(true);
        GameTimer.InitTimer();
        IngameAudio.PlayRandomBackgroundMusic();
        _score = new Score();
    }

    public void EndCampaing()
    {
        AnimationManager.Instance.MainMenu();
        MainMenu.SetActive(false);
        InGameInterface.SetActive(false);
        GameTimer.StopTimer();
        GameTimer.gameObject.SetActive(false);
        GameOverWindow.SetScore(_score);
        GameOverWindow.Show();
        WordGrid.Instance.Clear();
    }

    public void ShowMainScreen()
    {
        MainMenu.SetActive(true);
        GameOverWindow.Hide();
        InGameInterface.SetActive(false);
        GameTimer.gameObject.SetActive(false);
        MenuAudio.PlayRandomBackgroundMusic();
    }
    
    public void RightChoice()
    {
        _score.RightChoice();
        _score.TimePoints(GameTimer.RemainingSeconds);
//        GameTimer.RestartTimer();
        RightAudio.PlayFx();

    }

    public void WrongChoice()
    {
        _score.WrongChoice();
        WrongAudio.PlayFx();
    }

}
