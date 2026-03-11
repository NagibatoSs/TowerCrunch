using UnityEditor.ShaderGraph.Internal;
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

    private void OnEnable()
    {
        ClickHandler.Instance.OnScreenClick += StopResizing;
    }
    private void OnDisable()
    {
        if (ClickHandler.Instance != null)
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

    private void Resize()
    {

        if (transform.localScale.x >= maxSize)
            isLowering = true;
        else if (transform.localScale.x <= minSize)
            isLowering = false;

        if (!isLowering)
            transform.localScale += transform.localScale * resizingSpeed * Time.fixedDeltaTime;
        else
            transform.localScale -= transform.localScale * resizingSpeed * Time.fixedDeltaTime;

    }

    public void StopResizing()
    {
        rigidbody.isKinematic = false;
        isResizing = false;
        ClickHandler.Instance.OnScreenClick -= StopResizing;
    }
}
