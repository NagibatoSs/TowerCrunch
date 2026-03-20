using UnityEngine;

public class VFXPoolItem : MonoBehaviour
{
    [SerializeField] private ParticleSystem particleSystem;
    private VFXPool pool { get; set; }

    public void Init(VFXPool pool)
    {
        this.pool = pool;
    }

    private void OnParticleSystemStopped()
    {
        ReturnToPool();
    }

    public void ReturnToPool()
    {
        pool.ReturnToPool(this);
    }

    public void OnGetFromPool()
    {
        if (particleSystem != null)
        {
            particleSystem.Clear();
            particleSystem.Play();
        }
    }
}
