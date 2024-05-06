using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
[RequireComponent(typeof(Rigidbody))]
public class Cube : MonoBehaviour
{
    private Rigidbody _rigidbody;

    private int _decreaseSpawnChance = 2;
    public int SpawnChance { get; private set; } = 100;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();

        GetComponent<Renderer>().material.color = Random.ColorHSV();
    }

    public void Init(float decreaseScale)
    {
        transform.localScale = new Vector3(transform.localScale.x * decreaseScale, transform.localScale.y * decreaseScale, transform.localScale.z * decreaseScale);
        _rigidbody.AddExplosionForce(200, transform.position, 100);
        SpawnChance /= _decreaseSpawnChance;
    }
}
