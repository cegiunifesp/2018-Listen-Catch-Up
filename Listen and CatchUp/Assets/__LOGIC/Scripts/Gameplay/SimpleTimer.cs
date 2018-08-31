using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTimer : MonoBehaviour
{
    private float _duration;
    private float _actualTime;
    private bool _state;
    private UnityEngine.Events.UnityEvent _event;

    public void Setup(float duration, UnityEngine.Events.UnityEvent evet)
    {
        _duration = duration;
        _event = evet;
    }

    public void TurnOn()
    {
        _state = true;
        _actualTime = 0;
    }

    public bool TurnOff()
    {
        bool estado = _state;
        _state = false;
        return estado;
    }

    private void Update()
    {
        if(_state)
        {
            _actualTime += Time.deltaTime;

            if(_actualTime > _duration)
            {
                _state = false;
                _event.Invoke();
            }

        }
    }

    public float GetCurrenTime()
    {
        return _actualTime;
    }

}
