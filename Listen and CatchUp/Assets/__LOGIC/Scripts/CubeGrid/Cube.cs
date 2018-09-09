using System;
using System.Collections;
using UnityEngine;

public class Cube<T> : MonoBehaviour
{
<<<<<<< HEAD
    private bool shaking = false;
    private float timer;
=======
>>>>>>> cf1568948540affab573bfd6fb673671e1d037b0
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
        Destroy(gameObject);
        CubeGenerator<T>.Instance.CreateCube(Row);
<<<<<<< HEAD
        GameManager.Instance.RightChoice();
    }

    protected virtual void OnWrongMouseDown()
    {
        StartCoroutine("ShakeNow");
        GameManager.Instance.WrongChoice();
    }

    IEnumerator ShakeNow()
    {
        Vector3 original = transform.eulerAngles;

        if (shaking == false)
        {
            shaking = true;
            timer = 0;
        }

        yield return new WaitForSecondsRealtime(0.5f);

        shaking = false;

        transform.eulerAngles = original;
    }

    private void Update()
    {
        

        if (shaking)
        {
            timer += Time.deltaTime;
            transform.Rotate(new Vector3(0,0, Mathf.Cos(timer *  20)));
        }

        
=======
>>>>>>> cf1568948540affab573bfd6fb673671e1d037b0
    }

}
