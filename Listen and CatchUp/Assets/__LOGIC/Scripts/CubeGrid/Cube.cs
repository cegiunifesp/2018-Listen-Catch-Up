using UnityEngine;

public class Cube<T> : MonoBehaviour
{
    public int Row;
    public T Data
    {
        get { return _data; }
        set
        {
            _data = value;
            OnDataChanged();
        }
    }
    private T _data;


    public virtual void Setup()
    {

    }

    protected virtual void OnDataChanged()
    {
    }

    protected virtual void OnMouseDown()
    {
        Destroy();
        CubeGenerator<T>.Instance.CreateCube(Row);
    }

    public virtual void Destroy()
    {
        Destroy(gameObject);
    }

}
