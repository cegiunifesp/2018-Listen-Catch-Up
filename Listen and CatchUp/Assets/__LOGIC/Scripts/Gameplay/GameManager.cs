using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonBehaviour<GameManager>
{
    public MenuCube Play;
    public MenuCube Ranking;
    public MenuCube Credits;
    public GameObject MainMenu;
    public IngameInterface InGameInterface;

    public GameOverWindow GameOverWindow;
    public RankingWindow RankingWindow;
    public CreditsWindow CreditsWindow;


    [Header("Audio")]
    [Header("FX")]
    public AudioClip RightAudio;
    public AudioClip WrongAudio;

    [Header("BGM")]
    public AudioClip[] MenuAudio;
    public AudioClip[] InGameAudio;

    public GameState State = GameState.Menu;

    private Score _score;

    private void Start()
    {
        LoadingScreen.Instance.Wait(this);
        Play.OnClicked += cube => StartCampaign();
        Ranking.OnClicked += cube => ShowRankingWindow();
        Credits.OnClicked += cube => ShowCreditsWindow();
        WordManager.Instance.OnOutOfWords += EndCampaign;
        ShowMainScreen();
        StartCoroutine(WaitForClipsToLoad());
    }

    private IEnumerator WaitForClipsToLoad()
    {
        List<AudioClip> unloaded = new List<AudioClip>();
        foreach (var clip in WordManager.Instance.WordList)
        {
            unloaded.Add(clip.AudioIn(Language.English));
        }
        foreach (var clip in MenuAudio)
        {
            unloaded.Add(clip);
        }
        foreach (var clip in InGameAudio)
        {
            unloaded.Add(clip);
        }
        unloaded.Add(RightAudio);
        unloaded.Add(WrongAudio);
        while (unloaded.Count != 0)
        {
            unloaded.RemoveAll(x => x.loadState == AudioDataLoadState.Loaded);
            yield return null;
        }
        LoadingScreen.Instance.SetDone(this);
    }

    public void StartCampaign()
    {
        AnimationManager.Instance.InGame(() =>
        {
            InGameAudio.PlayRandomBackgroundMusic();
            InGameInterface.SetActive(true);
            InGameInterface.Timer.InitTimer();
            WordManager.Instance.GetNewWord();
        });
        MainMenu.SetActive(false);
        WordGrid.Instance.GenerateGrid();
        _score = new Score();
        State = GameState.Game;
    }

    public void EndCampaign()
    {
        InGameInterface.SetActive(false);
        GameOverWindow.SetScore(_score);
        GameOverWindow.Show();
        State = GameState.Window;
    }

    public void ShowMainScreen()
    {
        RankingWindow.Hide();
        CreditsWindow.Hide();
        GameOverWindow.Hide();
        WordGrid.Instance.Clear();
        MainMenu.SetActive(true);
        InGameInterface.SetActive(false);
        AnimationManager.Instance.MainMenu();
        MenuAudio.PlayRandomBackgroundMusic();
        State = GameState.Menu;
    }

    public void ShowRankingWindow()
    {
        RankingWindow.Show();
    }
    private void ShowCreditsWindow()
    {
        CreditsWindow.Show();
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

public enum GameState
{
    Window,Menu,Game
}