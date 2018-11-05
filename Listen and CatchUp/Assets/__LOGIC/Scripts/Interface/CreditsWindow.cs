using UnityEngine;

public class CreditsWindow : GameWindow
{
    public Animator CreditsAnimator;
    public AudioClip Music;

    public override void Show()
    {
        base.Show();
        Music.PlayBackgroundMusic();
        CreditsAnimator.SetTrigger("Start");
    }
    public override void Hide()
    {
        base.Hide();
        GameManager.Instance.MenuAudio.PlayRandomBackgroundMusic();
    }

}
