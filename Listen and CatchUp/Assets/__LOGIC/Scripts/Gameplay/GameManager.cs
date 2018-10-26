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
    public bool InGame;

    private Score _score;

    private void Start()
    {
        Play.OnClicked += cube => StartCampaign();
        Ranking.OnClicked += cube => ShowRankingWindow();
        Credits.OnClicked += cube => ShowCreditsWindow();
        WordManager.Instance.OnOutOfWords += EndCampaign;
        ShowMainScreen();
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
        InGame = true;
    }

    public void EndCampaign()
    {
        InGameInterface.SetActive(false);
        GameOverWindow.SetScore(_score);
        GameOverWindow.Show();
        InGame = false;
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
    }

    public void ShowRankingWindow()
    {
        NetworkedScore.Instance.GetScores(10,data =>
        {
            RankingWindow.Clear();
            RankingWindow.AddEntries(data);
        });
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
