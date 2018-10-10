using System;
using System.Collections;
using UnityEngine;

public class AnimationManager : SingletonBehaviour<AnimationManager>
{

    public Animator CameraAnimator;

    public void InGame(Action onAnimationFinished)
    {
        CameraAnimator.SetBool("InGame",true);
        StartCoroutine(WaitForAnimationToFinish("InGame",onAnimationFinished));
    }

    private IEnumerator WaitForAnimationToFinish(string stateName,Action onAnimationFinished)
    {
        while (!CameraAnimator.GetCurrentAnimatorStateInfo(0).IsName(stateName) || 
            CameraAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1f)
        {
            yield return null;
        }
        onAnimationFinished?.Invoke();
    }

    public void MainMenu()
    {
        CameraAnimator.SetBool("InGame", false);
    }
}
