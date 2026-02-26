using System;
using UnityEngine;

public class LandingDetector : MonoBehaviour
{
    [SerializeField] float rayOffset = 0.05f;
    [SerializeField] LayerMask mask;
    private bool isLanded = false;
    public event Action<GameObject> OnLanded;

    private void FixedUpdate()
    {
        if (isLanded) return;

        var halfHeight = transform.localScale.y * 0.5f;
        var rayLength = halfHeight + rayOffset;

        Vector3 origin = transform.position;
        Debug.DrawRay(origin, Vector3.down * rayLength, Color.red);
        if (Physics.Raycast(origin, Vector3.down, out RaycastHit hit, rayLength, mask))
        {
            isLanded = true;
            OnLanded?.Invoke(gameObject);
        }
    }
}
