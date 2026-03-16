using System.Collections;
using UnityEngine;

public class BlockAnimateColor : MonoBehaviour
{
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private float animationTime = 0.3f;
    [SerializeField] private float highlightSmoothness = 1f;
    [SerializeField] private Color emissionFlashColor = Color.white * 0.8f;
    private bool isAnimate = false;
    private float elapsedTime;
    private MaterialPropertyBlock block;
    private Color srcEmissionColor;
    private bool initialized;
    protected IEnumerator AnimateColor()
    {
        while (elapsedTime < animationTime)
        {
            yield return new WaitForEndOfFrame();


            Color emission = Color.Lerp(srcEmissionColor, emissionFlashColor, Mathf.PingPong(2 * elapsedTime / animationTime, 1));

            for (int i = 0; i < meshRenderer.sharedMaterials.Length; i++)
            {
                meshRenderer.GetPropertyBlock(block, i);

                block.SetColor("_EmissionColor", emission);

                meshRenderer.SetPropertyBlock(block, i);
            }
            elapsedTime += Time.deltaTime;
        }

        meshRenderer.GetPropertyBlock(block);
        block.SetColor("_EmissionColor", srcEmissionColor);
        meshRenderer.SetPropertyBlock(block);


        isAnimate = false;
    }

    public void Animate()
    {
        if (isAnimate) return;
        isAnimate = true;
        elapsedTime = 0f;
        if (!initialized) InitEmission();
        StartCoroutine(AnimateColor());
    }
    
    private void InitEmission()
    {
        block = new MaterialPropertyBlock();
        meshRenderer.sharedMaterial.EnableKeyword("_EMISSION");

        if (meshRenderer.sharedMaterial.HasProperty("_EmissionColor"))
            srcEmissionColor = meshRenderer.sharedMaterial.GetColor("_EmissionColor");
        else
            srcEmissionColor = Color.black;

        initialized = true;
    }
}
