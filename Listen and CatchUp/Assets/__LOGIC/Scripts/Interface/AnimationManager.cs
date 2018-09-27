using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : SingletonBehaviour<AnimationManager>
{

    public Animator CameraAnimator;

    public void InGame()
    {
        CameraAnimator.SetTrigger("ToggleView");
    }

    public void MainMenu()
    {
        CameraAnimator.SetTrigger("ToggleView");
    }
}
