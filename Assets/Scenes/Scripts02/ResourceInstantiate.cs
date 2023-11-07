using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class ResourceInstantiate : MonoBehaviour
{
    [SerializeField] private Resource _resourcePrefab;
    [SerializeField] private float _spawnInterval;
    [SerializeField]  private Borders _borders;

    private Vector3 _planeMinBounds;
    private Vector3 _planeMaxBounds;
    private float _resourceSpawnPositionY = 0.09f;

    private void Start()
    {
        CalculatePlaneBounds();
        StartCoroutine(SpawnRecource());
    }

    private void CalculatePlaneBounds()
    {
        Mesh planeMesh = _borders.GetComponent<MeshFilter>().sharedMesh;
        Bounds planeBounds = planeMesh.bounds;

        _planeMinBounds = _borders.transform.position + _borders.transform.rotation * planeBounds.min;
        _planeMaxBounds = _borders.transform.position + _borders.transform.rotation * planeBounds.max;
    }

    private IEnumerator SpawnRecource()
    {
        var waitForSecond = new WaitForSeconds(_spawnInterval);

        while(enabled)
        {
            Vector3 randomPosition = GetRandomPosition();

            Instantiate(_resourcePrefab, randomPosition, Quaternion.identity);

            yield return waitForSecond;
        }
    }

    private Vector3 GetRandomPosition()
    {
        float randomX = Random.Range(_planeMinBounds.x, _planeMaxBounds.x);
        float randomZ = Random.Range(_planeMinBounds.z, _planeMaxBounds.z);
        Vector3 randomPosition = new Vector3(randomX, _borders.transform.position.y + _resourceSpawnPositionY, randomZ);

        return randomPosition;
    }
}
