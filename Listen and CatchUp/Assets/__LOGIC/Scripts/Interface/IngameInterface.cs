using UnityEngine;

public class IngameInterface : MonoBehaviour
{
    public Timer Timer;

    public SpriteButton LeaveButton;
    public SpriteButton ListenButton;


    private void Awake()
    {
        Timer.OnTimerFinished += (timer) => GameManager.Instance.EndCampaing();
        LeaveButton.OnClicked += (LeaveButtonClicked);
        ListenButton.OnClicked += (ListenButtonClicked);
    }

    private void ListenButtonClicked(SpriteButton arg0)
    {
        WordManager.Instance.ListenCurrentWord();
    }

    private void LeaveButtonClicked(SpriteButton arg0)
    {
        GameManager.Instance.EndCampaing();
    }

    public void SetActive(bool active)
    {

        gameObject.SetActive(active);
        Timer.gameObject.SetActive(active);
        if (!active)
        {
            Timer.StopTimer();
        }
    }
}
