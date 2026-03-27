using UnityEngine;
using UnityEngine.UI;

public class SizeChanger : MonoBehaviour
{
    [SerializeField] float maxSizeMultiplier = 1.5f;
    [SerializeField] float minSizeMultiplier = 0.5f;
    [SerializeField] float resizingSpeed = 5f;
    private Rigidbody rigidbody;
    private float maxSize;
    private float minSize;
    private bool isLowering = false;
    private bool isResizing = true;

    public void SubscribeResize()
    {
        ClickHandler.Instance.OnScreenClick -= StopResizing;
        ClickHandler.Instance.OnScreenClick += StopResizing;
    }
    public void UnsubscribeResize()
    {
        ClickHandler.Instance.OnScreenClick -= StopResizing;
    }
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        maxSize = transform.localScale.x * maxSizeMultiplier;
        minSize = transform.localScale.x * minSizeMultiplier;
    }

    private void Update()
    {
        if (isResizing)
        {
            Resize();
        }
    }

    public void StartResizing()
    {
        isResizing = true;
    }

    private void Resize()
    {
        if (transform.localScale.x >= maxSize)
            isLowering = true;
        else if (transform.localScale.x <= minSize)
            isLowering = false;

        if (!isLowering)
            transform.localScale += transform.localScale * resizingSpeed * Time.deltaTime;
        else
            transform.localScale -= transform.localScale * resizingSpeed * Time.deltaTime;
    }

    private void StopResizing()
    {
        rigidbody.isKinematic = false;
        isResizing = false;
        isLowering = false;
    }

}
