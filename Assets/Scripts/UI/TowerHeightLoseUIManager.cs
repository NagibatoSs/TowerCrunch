using TMPro;
using UnityEngine;

public class TowerHeightLoseUIManager : MonoBehaviour
{
    [SerializeField] LevelInitializer levelInitializer;
    [SerializeField] TowerHeightManager heightManager;
    [SerializeField] TMP_Text currentHeightText;
    [SerializeField] TMP_Text targetHeightText;

    private void OnEnable()
    {
        currentHeightText.text = heightManager.Height.ToString();
        targetHeightText.text = levelInitializer.TargetHeight.ToString();
    }
}
