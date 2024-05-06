using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Cube))]
public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;

    private Cube _cube;

    private float _minScale = 0.5f;

    private int _minSpawnCubes = 2;
    private int _maxSpawnCubes = 7;

    private float _minChance = 0;
    private float _maxChance = 101;

    private void Awake()
    {
        _cube = GetComponent<Cube>();
    }

    public void GenerateCubes()
    {
        int numCubes = Random.Range(_minSpawnCubes, _maxSpawnCubes);

        if (Random.Range(_minChance, _maxChance) < _cube.SpawnChance)
        {
            for (int i = 0; i < numCubes; i++)
            {
                Cube cube = Instantiate(_cubePrefab, transform.position, Quaternion.identity);

                cube.Init(_minScale); 
            }
        }
    }
}
