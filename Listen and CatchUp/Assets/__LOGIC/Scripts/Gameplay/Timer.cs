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
<<<<<<< HEAD
    public GameObject Bar;
    float _barscale;

    IEnumerator StartTimer()
    {
        RemainingSeconds = InitialSeconds;
        Display.text = RemainingSeconds + "";
         _barscale = Bar.transform.localScale.x;

        Bar.transform.localScale = new Vector3(0, Bar.transform.localScale.y, Bar.transform.localScale.z);

=======

    IEnumerator Start()
    {
        RemainingSeconds = InitialSeconds;
        Display.text = RemainingSeconds + "";
>>>>>>> cf1568948540affab573bfd6fb673671e1d037b0
        while (RemainingSeconds!= 0)
        {
            yield return new WaitForSecondsRealtime(1);
            OnTick?.Invoke(this);
            RemainingSeconds--;
            Display.text = RemainingSeconds + "";
<<<<<<< HEAD
            Bar.transform.localScale =  (new Vector3((_barscale/InitialSeconds) * (InitialSeconds - RemainingSeconds), Bar.transform.localScale.y, Bar.transform.localScale.z));
        }

        OnTimerFinished?.Invoke(this);

        StopTimer();

    }

    public void InitTimer()
    {
        StartCoroutine("StartTimer");
    }

    public void RestartTimer()
    {
        if (RemainingSeconds == 0)
            InitTimer();
        else
            RemainingSeconds = InitialSeconds + 1;
    }

    public void StopTimer()
    {
        Bar.transform.localScale = new Vector3(_barscale, Bar.transform.localScale.y, Bar.transform.localScale.z);
        StopCoroutine("StartTimer");
=======
        }

    
        OnTimerFinished?.Invoke(this);

>>>>>>> cf1568948540affab573bfd6fb673671e1d037b0
    }

}
