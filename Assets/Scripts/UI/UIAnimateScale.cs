using System.Collections;
using UnityEngine;

public class UIAnimateScale : MonoBehaviour
{
    [SerializeField] private AnimationCurve easing;
    [SerializeField] private float animationTime = 1f;
    [SerializeField] private float maxScaleCoef = 1.2f;
    [SerializeField] private float minScaleCoef = 0.9f;
    private Vector3 maxScale;
    private Vector3 minScale;
    private float elapsedTime;

    private void Awake()
    {
        maxScale = transform.localScale * maxScaleCoef;
        minScale = transform.localScale * minScaleCoef;
    }

    private void Start()
    {
        Animate();
    }

    public void Animate()
    {
        elapsedTime = 0f;
        StartCoroutine(AnimateScale());
    }
    private IEnumerator AnimateScale()
    {
        while (true)
        {

            float time = Mathf.PingPong(2* elapsedTime / animationTime, 1f);

            transform.localScale = Vector3.Lerp(minScale, maxScale, easing.Evaluate(time));
            elapsedTime += Time.deltaTime;

            yield return null;
        }
    }
}
