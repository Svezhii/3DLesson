using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

[RequireComponent(typeof(Renderer), typeof(Rigidbody))]
public class Cube : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Renderer _renderer;
    private IObjectPool<Cube> _pool;
    private bool _hasCollided = true;
    private int _minLifeTime = 2;
    private int _maxLifeTime = 6;

    public event Action<Vector3> Exploded;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        _renderer.material.color = Color.white;
        _hasCollided = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out Plane _) && _hasCollided)
        {
            _hasCollided = false;
            _renderer.material.color = UnityEngine.Random.ColorHSV();
            StartCoroutine(DestroyAndSpawnBomb());
        }
    }

    public void StopVelocity()
    {
        _rigidbody.velocity = Vector3.zero;
    }

    public void SetPool(IObjectPool<Cube> pool)
    {
        _pool = pool;
    }

    private IEnumerator DestroyAndSpawnBomb()
    {
        int lifeTime = UnityEngine.Random.Range(_minLifeTime, _maxLifeTime);
        yield return new WaitForSeconds(lifeTime);

        _pool.Release(this);

        Exploded?.Invoke(transform.position);
    }
}