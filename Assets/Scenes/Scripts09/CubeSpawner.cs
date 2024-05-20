using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

[RequireComponent(typeof(MeshFilter))]
public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private Cube _cube;
    [SerializeField] private float _spawnInterval;
    [SerializeField] private int _poolCapacity;
    [SerializeField] private int _poolMaxSize;

    private MeshFilter _meshFilter;
    private Transform _transform;
    private Vector3 _planeMinBounds;
    private Vector3 _planeMaxBounds;
    private float _cubeSpawnPositionY = 5f;

    private ObjectPool<Cube> _pool;

    private void Awake()
    {
        _meshFilter = GetComponent<MeshFilter>();
        _pool = new ObjectPool<Cube>(CreatePooledItem, TakeFromPool, ReturnedToPool, DestroyPoolObject, defaultCapacity: _poolCapacity, maxSize: _poolMaxSize);

        _transform = transform;
    }

    private void Start()
    {
        CalculatePlaneBounds();
        StartCoroutine(SpawnCubes());
    }

    private IEnumerator SpawnCubes()
    {
        var waitForSecond = new WaitForSeconds(_spawnInterval);

        while (enabled)
        {
            GetCube();

            yield return waitForSecond;
        }
    }

    private void GetCube()
    {
        _pool.Get();
    }

    private Vector3 GetRandomPosition()
    {
        float randomX = Random.Range(_planeMinBounds.x, _planeMaxBounds.x);
        float randomZ = Random.Range(_planeMinBounds.z, _planeMaxBounds.z);
        Vector3 randomPosition = new Vector3(randomX, transform.position.y + _cubeSpawnPositionY, randomZ);

        return randomPosition;
    }

    private void CalculatePlaneBounds()
    {
        Mesh planeMesh = _meshFilter.sharedMesh;
        Bounds planeBounds = planeMesh.bounds;

        _planeMinBounds = _transform.position + _transform.rotation * planeBounds.min;
        _planeMaxBounds = _transform.position + _transform.rotation * planeBounds.max;
    }

    private Cube CreatePooledItem()
    {
        Cube cube = Instantiate(_cube);
        cube.SetPool(_pool);
        return cube;
    }

    private void TakeFromPool(Cube cube)
    {
        Vector3 randomPosition = GetRandomPosition();

        cube.transform.position = randomPosition;
        cube.GetComponent<Rigidbody>().velocity = Vector3.zero;
        cube.gameObject.SetActive(true);
    }

    private void ReturnedToPool(Cube cube)
    {
        cube.gameObject.SetActive(false);
    }

    private void DestroyPoolObject(Cube cube)
    {
        Destroy(cube.gameObject);
    }
}
