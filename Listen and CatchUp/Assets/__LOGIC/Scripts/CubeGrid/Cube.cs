using System;
using UnityEngine;

public class Cube<T> : MonoBehaviour
{

    private void Start()
    {
        normalColor = background.color;
        otherColor = new Color(255, 255, 255);
    }

    private void Update()
    {
        Id = Row * 4 + (int)(transform.position.y + 2.5f);
    }

    public int Id;
    public SpriteRenderer background;
    public int Row;


    public Color normalColor;
    public Color otherColor;

    public T Data
    {
        get { return _data; }
        set
        {
            _data = value;
            OnDataChanged();
        }
    }

    public Action<Cube<T>> OnClicked;

    private T _data;

    public virtual void Setup()
    {

    }

    protected virtual void OnDataChanged()
    {
    }


    public void Click()
    {
        OnMouseDown();
    }

    protected virtual void OnMouseDown()
    {
        Destroy();
        OnClicked?.Invoke(this);
    }

    public virtual void Destroy()
    {
        Destroy(gameObject);
    }

    public void SelectCube()
    {
        background.color = otherColor;
    }

    public void DeselectCube()
    {
        background.color = normalColor;
    }

}
