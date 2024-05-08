using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
[RequireComponent(typeof(Rigidbody))]
public class Cubes : MonoBehaviour
{
    [SerializeField] private float _explosionForce;
    [SerializeField] private float _explosionRadius;

    private Rigidbody _rigidbody;

    private int _decreaseSpawnChance = 2;
    public int SpawnChance { get; private set; } = 100;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();

        GetComponent<Renderer>().material.color = Random.ColorHSV();
    }

    public void Init(float decreaseScale, int newSpawnChance)
    {
        transform.localScale = new Vector3(transform.localScale.x * decreaseScale, transform.localScale.y * decreaseScale, transform.localScale.z * decreaseScale);
        _rigidbody.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
        SpawnChance = newSpawnChance / _decreaseSpawnChance;
    }
}
