using UnityEngine;

public class CreditsWindow : GameWindow
{
    public Animator CreditsAnimator;

    public override void Show()
    {
        base.Show();
        //CreditsAnimator.SetTrigger("Start");
    }
}
