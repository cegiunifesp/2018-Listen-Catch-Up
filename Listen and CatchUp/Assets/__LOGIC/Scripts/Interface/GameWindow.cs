using UnityEngine;
using UnityEngine.UI;

public class GameWindow : MonoBehaviour
{
    public Button CloseButton;
    public Animator WindowAnimator;

    private bool _visible;
    private int _animationStateHash;

    protected virtual void Awake()
    {
        _animationStateHash = Animator.StringToHash("ShowWindow");
        CloseButton.onClick.AddListener(OnCloseButtonClick);
    }
    
    protected virtual void OnCloseButtonClick()
    {
        Hide();
    }

    public virtual void Show()
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

    public virtual void Hide()
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
