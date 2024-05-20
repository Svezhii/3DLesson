using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

[RequireComponent(typeof(Renderer))]
public class Cube : MonoBehaviour
{
    private Renderer _renderer;
    private IObjectPool<Cube> _pool;
    private bool _hasCollided = true;
    private int _minLifeTime = 2;
    private int _maxLifeTime = 6;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void OnEnable()
    {
        _renderer.material.color = Color.white;
        _hasCollided = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent<Plane>(out Plane _) && _hasCollided)
        {
            _hasCollided = false;
            _renderer.material.color = Random.ColorHSV();
            StartCoroutine(Destroy());
        }
    }

    public void SetPool(IObjectPool<Cube> pool)
    {
        _pool = pool;
    }

    private IEnumerator Destroy()
    {
        int lifeTime = Random.Range(_minLifeTime, _maxLifeTime);
        yield return new WaitForSeconds(lifeTime);
            
        _pool.Release(this);
    }
}
