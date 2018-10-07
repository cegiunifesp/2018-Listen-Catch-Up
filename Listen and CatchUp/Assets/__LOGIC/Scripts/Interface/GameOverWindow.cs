using TMPro;
using UnityEngine;

public class GameOverWindow : MonoBehaviour
{
    public TMP_Text Score;
    public Animator WindowAnimator;
    public SpriteButton MainMenuButton;

    private bool _visible = false;
    private int _animationStateHash;

    private void Awake()
    {
        _animationStateHash = Animator.StringToHash("ShowWindow");
        MainMenuButton.OnClicked+= OnClicked;
    }

    private void OnClicked(SpriteButton arg0)
    {
        GameManager.Instance.ShowMainScreen();
    }

    public void SetScore(Score score)
    {
        Score.text = $"{score.RightWords} words";
    }

    public void Show()
    {
        if (!_visible)
        {
            WindowAnimator.SetFloat("Visible", 1);
            float currentTime = WindowAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime;
            var time = currentTime > -1 ? currentTime : 0;
            WindowAnimator.Play(_animationStateHash, 0, time);
            _visible = true;
        }
    }

    public void Hide()
    {
        if (_visible)
        {
            WindowAnimator.SetFloat("Visible", -1);
//            float currentTime = WindowAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime;
            WindowAnimator.Play(_animationStateHash, 0, 1);
            _visible = false;
        }
    }
}
