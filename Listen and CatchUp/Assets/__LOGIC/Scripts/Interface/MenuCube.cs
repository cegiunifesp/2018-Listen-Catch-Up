using System;
using UnityEngine;

public class MenuCube : MonoBehaviour
{

    public event Action<MenuCube> OnClicked;
    public Animator TextAnimator;

    private bool _hover;
    private int _animationStateHash;

    private void Awake()
    {
        _animationStateHash = Animator.StringToHash("Hidden");
    }


    private void OnEnable()
    {
        OnMouseExit();
    }

    protected virtual void OnMouseEnter()
    {
        if (GameManager.Instance.State != GameState.Menu) return;
        if (_hover) return;
        TextAnimator.SetFloat("Visible", 1);
        float currentTime = TextAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime;
        var time = currentTime > -1 ? currentTime : 0;
        TextAnimator.Play(_animationStateHash, 0, time);
        _hover = true;
    }

    protected virtual void OnMouseExit()
    {
        if (!_hover) return;
        TextAnimator.SetFloat("Visible", -1);
        float currentTime = TextAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime;
        TextAnimator.Play(_animationStateHash, 0, currentTime);
        _hover = false;
    }

    protected virtual void OnMouseDown()
    {
        if (GameManager.Instance.State != GameState.Menu) return;
        //        Destroy(gameObject);
        OnClicked?.Invoke(this);
    }
}
