using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;

    private float _minScale = 0.5f;
    private int _spawnChance = 100;
    private int _decreaseSpawnChance = 2;

    private int _minSpawnCubes = 2;
    private int _maxSpawnCubes = 7;

    private float _minChance = 0;
    private float _maxChance = 101;

    public void GenerateCubes()
    {
        int numCubes = Random.Range(_minSpawnCubes, _maxSpawnCubes);

        for (int i = 0; i < numCubes; i++)
        {
            if (Random.Range(_minChance, _maxChance) < _spawnChance)
            {
                Cube cube = Instantiate(_cubePrefab, transform.position, Quaternion.identity);

                cube.transform.localScale = new Vector3(transform.localScale.x * _minScale, transform.localScale.y * _minScale, transform.localScale.z * _minScale);

                cube.GetComponent<Renderer>().material.color = Random.ColorHSV();

                cube.DecreaseChance(_spawnChance / _decreaseSpawnChance);
            }
        }
    }

    public void DecreaseChance(int newSpawnChance)
    {
        _spawnChance = newSpawnChance;
    }
}
