using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;
using static UnityEngine.Rendering.STP;

public class VFXPool : MonoBehaviour
{
    [SerializeField] VFXPoolConfig vfxConfig;
    private Queue<VFXPoolItem> queue;
    private List<VFXPoolItem> items;

    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        items = new List<VFXPoolItem>(vfxConfig.InitialSize);
        queue = new Queue<VFXPoolItem>();
        for (int i = 0; i < vfxConfig.InitialSize; i++)
        {
            CreateItem();
        }
    }

    private VFXPoolItem CreateItem()
    {
        GameObject instance = Instantiate(vfxConfig.Prefab, transform);
        instance.SetActive(false);

        var item = instance.GetComponent<VFXPoolItem>();
        item.Init(this);

        items.Add(item);
        queue.Enqueue(item);

        return item;
    }

    public VFXPoolItem GetFromPool()
    {
        if (queue.Count == 0)
            CreateItem();
        VFXPoolItem poolItem = queue.Dequeue();
        poolItem.OnGetFromPool();
        poolItem.gameObject.SetActive(true);
        return poolItem;
    }

    public void ReturnToPool(VFXPoolItem item)
    {
        item.gameObject.SetActive(false);
        queue.Enqueue(item);
    }
}
