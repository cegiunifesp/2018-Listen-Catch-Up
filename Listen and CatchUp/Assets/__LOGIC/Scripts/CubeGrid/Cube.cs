using System;
using UnityEngine;

public class Cube<T> : MonoBehaviour
{
    public T Data
    {
        get { return _data; }
        set
        {
            _data = value;
            OnDataChanged();
        }
    }
    public Action<Cube<T>> OnCicked;

    private T _data;


    public virtual void Setup()
    {

    }

    protected virtual void OnDataChanged()
    {
    }

    protected void OnCubeClicked()
    {
        Destroy(gameObject);
    }

    private void OnMouseDown()
    {
        OnCicked?.Invoke(this);
        OnCubeClicked();
    }
}
