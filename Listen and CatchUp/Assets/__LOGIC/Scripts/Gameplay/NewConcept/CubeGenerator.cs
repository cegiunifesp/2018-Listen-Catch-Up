using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BoxCollider2D))]
public class CubeGenerator : SingletonBehaviour<CubeGenerator>
{
    public float Spacing = 0;
    public Vector2 RangeRotationX;
    public Vector2 RangeRotationY;
    public Cube CubePrefab;

    private Vector2 _gridsize;
    private Vector2 _cubeSize;
    private Vector3 _startLocation;
    private void Awake()
    {
        BoxCollider2D collider2D = GetComponent<BoxCollider2D>();
        Bounds bounds = collider2D.bounds;
        collider2D.enabled = false;
        GameObject cubeInstance = Instantiate(CubePrefab.gameObject);
        _cubeSize = cubeInstance.GetComponent<BoxCollider2D>().bounds.size;
        Destroy(cubeInstance);
        _startLocation = new Vector3(_cubeSize.x/1.5f + bounds.min.x,bounds.max.y + 2* _cubeSize.y,bounds.min.z);
        _gridsize = new Vector2((int)Mathf.Floor(( bounds.size.x+Spacing) / _cubeSize.x) - 1, (int)Mathf.Floor(bounds.size.y / _cubeSize.y));
         GenerateGrid();
    }

    public void CreateCube(int row)
    {
        Vector3 position = _startLocation + new Vector3((_cubeSize.x + Spacing) * row,0);
        float randomRotationx = Random.Range(RangeRotationX.x, RangeRotationX.y);
        float randomRotationY = Random.Range(RangeRotationY.x, RangeRotationY.y);
        Instantiate(CubePrefab, position, Quaternion.Euler(new Vector3(randomRotationx, randomRotationY)), transform).GetComponent<Cube>().Setup(row);
    }

    private void GenerateGrid()
    {
        for (int i = 0; i < _gridsize.x; i++)
        {
            for (int j = 0; j < _gridsize.y; j++)
            {
                CreateCube(i);
            }
        }
    }
}
