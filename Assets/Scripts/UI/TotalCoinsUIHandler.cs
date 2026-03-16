using TMPro;
using UnityEngine;

public class TotalCoinsUIHandler : MonoBehaviour
{
    [SerializeField] PlayerScriptableModel playerScriptableModel;
    [SerializeField] TMP_Text totalCoinsText;

    private void OnEnable()
    {
        playerScriptableModel.Model.OnCoinsChanged += SetCoins;
    }

    private void Start()
    {
        totalCoinsText.text = playerScriptableModel.Model.Coin.ToString();
    }
    private void SetCoins(int newCoinsCount)
    {
        totalCoinsText.text = newCoinsCount.ToString();
    }
}
