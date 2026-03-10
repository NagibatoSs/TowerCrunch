using TMPro;
using UnityEngine;

public class TowerHeightUIHandler : MonoBehaviour
{
    [SerializeField] TowerHeightManager heightManager;
    [SerializeField] TMP_Text heightText;

    private void OnEnable()
    {
        heightManager.OnHeightChanged += ChangeHeight;
    }

    private void OnDisable()
    {
        heightManager.OnHeightChanged -= ChangeHeight;
    }

    private void ChangeHeight(int height)
    {
        heightText.text = height.ToString();
    }
}
