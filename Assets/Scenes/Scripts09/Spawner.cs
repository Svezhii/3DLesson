using System;
using UnityEngine;

public abstract class Spawner<T> : MonoBehaviour
{
    protected int TotalSpawned;

    public event Action<int> OnTotalSpawnedChanged;


    protected void IncrementTotalSpawned()
    {
        TotalSpawned++;
        OnTotalSpawnedChanged?.Invoke(TotalSpawned);
    }

    protected abstract T CreatePooledItem();

    protected abstract void TakeFromPool(T prefab);

    protected abstract void ReturnedToPool(T prefab);

    protected abstract void DestroyPoolObject(T prefab);
}