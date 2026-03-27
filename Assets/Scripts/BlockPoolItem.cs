using UnityEngine;

public class BlockPoolItem : PoolItem
{
    private Rigidbody rb;
    private SizeChanger sizeChanger;
    private LandingDetector landingDetector;
    public override void Init(Pool pool)
    {
        base.Init(pool);
        rb = GetComponent<Rigidbody>();
        sizeChanger = GetComponent<SizeChanger>();
        landingDetector = GetComponent<LandingDetector>();
    }

    public override void OnSpawned()
    {
        landingDetector.isLanded = false;
        sizeChanger.SubscribeResize();
        sizeChanger.StartResizing();
    }

    public override void OnDespawned()
    {
        sizeChanger.UnsubscribeResize();
        transform.localScale = Vector3.one;
        rb.isKinematic = true;
    }
}
