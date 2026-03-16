using UnityEngine;
using System;
using TMPro;
using System.Collections;

public class RewardCoinsUIHandler : MonoBehaviour
{
    [SerializeField] TMP_Text totalCoinsText;
    [SerializeField] TMP_Text rewardCoinsText;
    [SerializeField] RewardSystem rewardSystem;
    [SerializeField] float animationDelay = 0.05f;
    [SerializeField] float delayBeforeAnimation = 1f;
    public Action OnCoinAdd;

    private void OnEnable()
    {
        rewardSystem.OnReward += OnRewardDelegate;
    }
    private void OnDisable()
    {
        rewardSystem.OnReward -= OnRewardDelegate;
    }

    private void OnRewardDelegate(int total, int reward)
    {
        StartCoroutine(AnimateCoinsReward(total, reward));
    }

    private IEnumerator AnimateCoinsReward(int total, int reward)
    {
        int currentTotal = total;
        int remainingReward = reward;

        totalCoinsText.text = total.ToString();
        rewardCoinsText.text = "+" + reward.ToString();


        yield return new WaitForSeconds(delayBeforeAnimation);

        while (remainingReward > 0)
        {
            currentTotal++;
            remainingReward--;

            totalCoinsText.text = currentTotal.ToString();
            rewardCoinsText.text = "+" + remainingReward;
            OnCoinAdd?.Invoke();
            yield return new WaitForSeconds(animationDelay);
        }
        rewardCoinsText.text = "";
    }
}
