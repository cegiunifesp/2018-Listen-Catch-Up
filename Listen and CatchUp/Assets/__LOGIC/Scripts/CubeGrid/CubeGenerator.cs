using System;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(BoxCollider2D))]
public class CubeGenerator<T> : SingletonBehaviour<CubeGenerator<T>>
{
    public float CubeFallHeight = 2;
    public float Spacing = 0.1f;
    public Vector2 RangeRotationX = new Vector2(-2,2);
    public Vector2 RangeRotationY = new Vector2(-3, 3);
    public GameObject CubePrefab;
    public Action<Cube<T>> OnCubeSpawned;

    private Vector2 _gridsize;
    private Vector2 _cubeSize;
    private Vector3 _startLocation;

    protected virtual void OnValidate()
    {
        if (CubePrefab != null && CubePrefab.GetComponent<Cube<T>>() == null)
        {
            Debug.LogError("The prefab must contain a Cube<" + typeof(T).Name + "> component.");
            CubePrefab = null;
        }
    }
    protected virtual  void Awake()
    {
        BoxCollider2D collider2D = GetComponent<BoxCollider2D>();
        Bounds bounds = collider2D.bounds;
        collider2D.enabled = false;
        GameObject cubeInstance = Instantiate(CubePrefab.gameObject);
        _cubeSize = cubeInstance.GetComponent<BoxCollider2D>().bounds.size;
        Destroy(cubeInstance);
        _startLocation = new Vector3(_cubeSize.x/2f + bounds.min.x, bounds.max.y + (CubeFallHeight * _cubeSize.y), bounds.min.z);
        _gridsize = new Vector2((int)Mathf.Floor((bounds.size.x + Spacing) / _cubeSize.x) - 1, (int)Mathf.Floor(bounds.size.y / _cubeSize.y));
        GenerateGrid();
    }

    public virtual Cube<T> CreateCube(int row)
    {
        Vector3 position = _startLocation + new Vector3((_cubeSize.x + Spacing) * row, 0);
        float randomRotationx = Random.Range(RangeRotationX.x, RangeRotationX.y);
        float randomRotationY = Random.Range(RangeRotationY.x, RangeRotationY.y);
        Vector3 randomRotation = new Vector3(randomRotationx, randomRotationY);
        Cube<T> cube = Instantiate(CubePrefab, position, Quaternion.Euler(randomRotation), transform).GetComponent<Cube<T>>();
        cube.OnCicked += targetCube=>CreateCube(row);
        OnCubeSpawned?.Invoke(cube);
        cube.Setup();
        return cube;
    }

    public virtual Cube<T> CreateCube(T data , int row)
    {
        Vector3 position = _startLocation + new Vector3((_cubeSize.x + Spacing) * row, 0);
        float randomRotationx = Random.Range(RangeRotationX.x, RangeRotationX.y);
        float randomRotationY = Random.Range(RangeRotationY.x, RangeRotationY.y);
        Vector3 randomRotation = new Vector3(randomRotationx, randomRotationY);
        Cube<T> cube = Instantiate(CubePrefab, position, Quaternion.Euler(randomRotation), transform).GetComponent<Cube<T>>();
        cube.Data = data;
        cube.OnCicked += targetCube => CreateCube(row);
        OnCubeSpawned?.Invoke(cube);
        return cube;
    }

    public virtual void GenerateGrid()
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
