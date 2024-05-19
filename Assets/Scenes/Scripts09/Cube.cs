using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

[RequireComponent(typeof(Renderer))]
public class Cube : MonoBehaviour
{
    private IObjectPool<Cube> _pool;
    private bool _hasCollided = true;
    private int _minLifeTime = 2;
    private int _maxLifeTime = 6;

    public void SetPool(IObjectPool<Cube> pool)
    {
        _pool = pool;
    }

    private void OnEnable()
    {
        GetComponent<Renderer>().material.color = Color.white;
        _hasCollided = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent<Plane>(out Plane _) && _hasCollided)
        {
            _hasCollided = false;
            GetComponent<Renderer>().material.color = Random.ColorHSV();
            StartCoroutine(DestroyCube());
        }
    }

    private IEnumerator DestroyCube()
    {
        int lifeTime = Random.Range(_minLifeTime, _maxLifeTime);
        yield return new WaitForSeconds(lifeTime);
            
        _pool.Release(this);
    }
}
