using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeInstantiator : MonoBehaviour
{
    [SerializeField] private Cube _cube;
    [SerializeField] private float _spawnInterval;

    private Transform _transform;
    private Vector3 _planeMinBounds;
    private Vector3 _planeMaxBounds;
    private float _cubeSpawnPositionY = 5f;


    private void Awake()
    {
        _transform = transform;
    }

    private void Start()
    {
        CalculatePlaneBounds();
        StartCoroutine(SpawnCubes());
    }

    private void CalculatePlaneBounds()
    {
        Mesh planeMesh = GetComponent<MeshFilter>().sharedMesh;
        Bounds planeBounds = planeMesh.bounds;

        _planeMinBounds = _transform.position + _transform.rotation * planeBounds.min;
        _planeMaxBounds = _transform.position + _transform.rotation * planeBounds.max;
    }

    private IEnumerator SpawnCubes()
    {
        var waitForSecond = new WaitForSeconds(_spawnInterval);

        while (enabled)
        {
            Vector3 randomPosition = GetRandomPosition();

            Instantiate(_cube, randomPosition, Quaternion.identity);

            yield return waitForSecond;
        }
    }

    private Vector3 GetRandomPosition()
    {
        float randomX = Random.Range(_planeMinBounds.x, _planeMaxBounds.x);
        float randomZ = Random.Range(_planeMinBounds.z, _planeMaxBounds.z);
        Vector3 randomPosition = new Vector3(randomX, transform.position.y + _cubeSpawnPositionY, randomZ);

        return randomPosition;
    }
}
