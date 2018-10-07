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
    public GameObject Bar;
    private float _barScale;

    private void Awake()
    {
        _barScale = Bar.transform.localScale.x;
    }

    IEnumerator StartTimer()
    {
        RemainingSeconds = InitialSeconds;
        Display.text = RemainingSeconds + "";

        Bar.transform.localScale = new Vector3(0, Bar.transform.localScale.y, Bar.transform.localScale.z);

        while (RemainingSeconds!= 0)
        {
            yield return new WaitForSecondsRealtime(1);
            OnTick?.Invoke(this);
            RemainingSeconds--;
            Display.text = RemainingSeconds + "";

            Bar.transform.localScale =  (new Vector3((_barScale/InitialSeconds) * (InitialSeconds - RemainingSeconds), Bar.transform.localScale.y, Bar.transform.localScale.z));
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
        Bar.transform.localScale = new Vector3(_barScale, Bar.transform.localScale.y, Bar.transform.localScale.z);
        StopCoroutine("StartTimer");
       
    }

}
