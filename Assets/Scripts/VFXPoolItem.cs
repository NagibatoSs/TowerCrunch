using UnityEngine;

public class VFXPoolItem : PoolItem
{
    [SerializeField] private ParticleSystem particleSystem;

    private void OnParticleSystemStopped()
    {
        ReturnToPool();
    }

    public override void OnDespawned()
    {
    }

    public override void OnSpawned()
    {
        if (particleSystem != null)
        {
            particleSystem.Clear();
            particleSystem.Play();
        }
    }

}
