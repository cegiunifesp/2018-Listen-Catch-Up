using TMPro;
using UnityEngine.UI;

public class GameOverWindow : GameWindow
{
    public TMP_Text Score;
    public Button MainMenuButton;
    public TMP_InputField UsernameInput;
    public Button SaveScoreButton;

    private Score _score;
    protected override void Awake()
    {
        base.Awake();
        MainMenuButton.onClick.AddListener(OnClicked);
        UsernameInput.onValueChanged.AddListener(OnTextChanged);
        SaveScoreButton.interactable = false;
        SaveScoreButton.onClick.AddListener(OnSaveScoreClicked);
    }

    private void OnSaveScoreClicked()
    {
        NetworkedScore.Instance.PushScore(UsernameInput.text, _score.RightWords);
        GameManager.Instance.ShowMainScreen();
    }

    private void OnTextChanged(string value)
    {
        SaveScoreButton.interactable = !string.IsNullOrEmpty(value);
    }

    private void OnClicked()
    {
        GameManager.Instance.ShowMainScreen();
    }

    public void SetScore(Score score)
    {
        Score.text = $"{score.RightWords} words";
        _score = score;
    }
}
