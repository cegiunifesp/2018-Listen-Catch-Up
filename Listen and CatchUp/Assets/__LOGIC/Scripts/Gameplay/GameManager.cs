using UnityEngine;

public class GameManager : SingletonBehaviour<GameManager>
{
    public MenuCube Play;

    public GameObject MainMenu;
    public IngameInterface InGameInterface;
    public GameOverWindow GameOverWindow;

    [Header("Audio")]
    [Header("FX")]
    public AudioClip RightAudio;

    public AudioClip WrongAudio;

    [Header("BGM")]
    public AudioClip[] MenuAudio;

    public AudioClip[] InGameAudio;


    private Score _score;

    private void Start()
    {
        Play.OnClicked += cube => StartCampaign();
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
    }

    public void EndCampaign()
    {
        InGameInterface.SetActive(false);
        GameOverWindow.SetScore(_score);
        GameOverWindow.Show();
    }

    public void ShowMainScreen()
    {
        AnimationManager.Instance.MainMenu();
        WordGrid.Instance.Clear();
        MainMenu.SetActive(true);
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
