using UnityEngine;

public abstract class PoolItem:MonoBehaviour
{
    protected Pool pool { get; set; }
    public bool IsInPool { get; set; }
    public virtual void Init(Pool pool)
    {
        this.pool = pool;
    }

    public virtual void ReturnToPool()
    {
        pool.ReturnToPool(this);
    }
    public abstract void OnSpawned();

    public abstract void OnDespawned();
}
