using UnityEngine;
using UnityEngine.Pool;

public class BombSpawner : Spawner<Bomb>
{
    [SerializeField] private Bomb _bomb;
    [SerializeField] private int _poolCapacity;
    [SerializeField] private int _poolMaxSize;

    private ObjectPool<Bomb> _pool;

    public int ActiveObjects => _pool.CountActive;

    private void Awake()
    {
        _pool = new ObjectPool<Bomb>(CreatePooledItem, TakeFromPool, ReturnedToPool,
            DestroyPoolObject, defaultCapacity: _poolCapacity, maxSize: _poolMaxSize);
    }

    public Bomb GetBomb()
    {
        return _pool.Get();
    }

    public void HandleCubeExplosion(Vector3 position)
    {
        Bomb bomb = GetBomb();
        bomb.transform.position = position;
    }

    protected override Bomb CreatePooledItem()
    {
        Bomb bomb = Instantiate(_bomb);
        bomb.SetPool(_pool);
        return bomb;
    }

    protected override void TakeFromPool(Bomb bomb)
    {
        bomb.gameObject.SetActive(true);
        IncrementTotalSpawned();
    }

    protected override void ReturnedToPool(Bomb bomb)
    {
        bomb.gameObject.SetActive(false);
    }

    protected override void DestroyPoolObject(Bomb bomb)
    {
        Destroy(bomb.gameObject);
    }
}