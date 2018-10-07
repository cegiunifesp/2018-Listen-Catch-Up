using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonBehaviour<GameManager> {
    public MenuCube Play;

    public GameObject MainMenu;
    public IngameInterface InGameInterface;
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
        WordManager.Instance.OnOutOfWords += EndCampaing;
        ShowMainScreen();

    }
	
	// Update is called once per frame
	void Update () {
		
	}


    public void StartCampaing()
    {
        AnimationManager.Instance.InGame(()=>
        {
            IngameAudio.PlayRandomBackgroundMusic();
            InGameInterface.Timer.InitTimer();
            WordManager.Instance.GetNewWord();
        });
        InGameInterface.SetActive(true);
        MainMenu.SetActive(false);
        Gerador.GenerateGrid();
        _score = new Score();
    }

    public void EndCampaing()
    {
        AnimationManager.Instance.MainMenu();
        InGameInterface.SetActive(false);
        WordGrid.Instance.Clear();
        MainMenu.SetActive(true);
        GameOverWindow.SetScore(_score);
        GameOverWindow.Show();
    }

    public void ShowMainScreen()
    {
        GameOverWindow.Hide();
        InGameInterface.SetActive(false);
        MainMenu.SetActive(true);
        MenuAudio.PlayRandomBackgroundMusic();
    }
    
    public void RightChoice()
    {
        _score.RightChoice();
        _score.TimePoints(InGameInterface.Timer.RemainingSeconds);
        RightAudio.PlayFx();

    }

    public void WrongChoice()
    {
        _score.WrongChoice();
        WrongAudio.PlayFx();
    }

}
