using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

[RequireComponent(typeof(Renderer), typeof(Rigidbody))]
public class Bomb : MonoBehaviour
{
    private Renderer _renderer;
    private IObjectPool<Bomb> _pool;
    private Color _color;
    private int _minLifeTime = 2;
    private int _maxLifeTime = 6;
    private float _explosionRadius = 5f;
    private float _explosionForce = 500f;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void OnEnable()
    {
        _renderer.material.color = Color.black;
        _color = _renderer.material.color;
        StartCoroutine(FadeAndExplode());
    }

    public void SetPool(IObjectPool<Bomb> pool)
    {
        _pool = pool;
    }

    private IEnumerator FadeAndExplode()
    {
        int lifeTime = Random.Range(_minLifeTime, _maxLifeTime);

        float elapsedTime = 0f;

        while (elapsedTime < lifeTime)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / lifeTime);
            Color newColor = new Color(_color.r, _color.g, _color.b, alpha);
            _renderer.material.color = newColor;
            yield return null;
        }

        Explode();
        _pool.Release(this);
    }

    private void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _explosionRadius);

        foreach (Collider hit in colliders)
        {
            if (hit.TryGetComponent(out Rigidbody rigidbody))
            {
                rigidbody.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
            }
        }
    }
}