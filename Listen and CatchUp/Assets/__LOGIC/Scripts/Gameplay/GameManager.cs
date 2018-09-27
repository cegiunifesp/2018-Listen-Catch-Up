using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonBehaviour<GameManager> {

    public Timer GameTimer;
    public MenuCube Play;

    public GameObject MainMenu;
    public GameObject InGameInterface;
    public GameObject EndGameInterface;
    public WordGrid Gerador;
    public UnityEngine.UI.Text ScoreText;
    public UnityEngine.UI.Image ScoreImage;


    public AudioSource RightAudio;
    public AudioSource WrongAudio;

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
        AnimationManager.Instance.InGame();
        MainMenu.SetActive(false);
        InGameInterface.SetActive(true);
        EndGameInterface.SetActive(false);
        Gerador.GenerateGrid();
        GameTimer.gameObject.SetActive(true);
        GameTimer.InitTimer();
        _score = new Score();
    }

    public void EndCampaing()
    {
        AnimationManager.Instance.MainMenu();
        MainMenu.SetActive(false);
        InGameInterface.SetActive(false);
        EndGameInterface.SetActive(true);
        GameTimer.StopTimer();
        GameTimer.gameObject.SetActive(false);
        ScoreText.text = _score.GetScore().ToString();
        WordGrid.Instance.Clear();
    }

    public void ShowMainScreen()
    {
        MainMenu.SetActive(true);
        InGameInterface.SetActive(false);
        EndGameInterface.SetActive(false);
        GameTimer.gameObject.SetActive(false);
    }


    public void RightChoice()
    {
        _score.RightChoice();
        _score.TimePoints(GameTimer.RemainingSeconds);
        GameTimer.RestartTimer();
        WrongAudio.Stop();
        RightAudio.Stop();
        RightAudio.Play();

    }

    public void WrongChoice()
    {
        _score.WrongChoice();
        WrongAudio.Stop();
        WrongAudio.Play();
    }


}
