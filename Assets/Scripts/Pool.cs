using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    [SerializeField] PoolConfig poolConfig;
    private Queue<PoolItem> queue;
    public int QueueCount => queue.Count;
    private List<PoolItem> items;

    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        items = new List<PoolItem>(poolConfig.InitialSize);
        queue = new Queue<PoolItem>();
        for (int i = 0; i < poolConfig.InitialSize; i++)
        {
            CreateItem();
        }
    }

    private PoolItem CreateItem()
    {
        GameObject instance = Instantiate(poolConfig.Prefab, transform);
        instance.SetActive(false);

        var item = instance.GetComponent<PoolItem>();
        item.Init(this);

        items.Add(item);
        queue.Enqueue(item);

        return item;
    }

    public PoolItem GetFromPool()
    {
        if (queue.Count == 0)
            CreateItem();
        PoolItem poolItem = queue.Dequeue();
        poolItem.IsInPool = false;
        poolItem.gameObject.SetActive(true);
        poolItem.OnSpawned();
        return poolItem;
    }

    public void ReturnToPool(PoolItem item)
    {
        if (item.IsInPool) return;
        item.IsInPool = true;
        item.OnDespawned();
        item.gameObject.SetActive(false);
        queue.Enqueue(item);
    }
}
