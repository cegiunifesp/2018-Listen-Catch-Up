using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{

    public int InitialSeconds = 30;
    public int RemainingSeconds ;
    public Action<Timer> OnTick;
    public Action<Timer> OnTimerFinished;
    public TextMeshPro Display;

    IEnumerator Start()
    {
        RemainingSeconds = InitialSeconds;
        Display.text = RemainingSeconds + "";
        while (RemainingSeconds!= 0)
        {
            yield return new WaitForSecondsRealtime(1);
            OnTick?.Invoke(this);
            RemainingSeconds--;
            Display.text = RemainingSeconds + "";
        }

    
        OnTimerFinished?.Invoke(this);

    }

}
