using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{

    private int _row;
    public void Setup(int row)
    {
        _row = row;
    }
    private void OnMouseDown()
    {
        CubeGenerator.Instance.CreateCube(_row);
        Destroy(gameObject);
    }
}
