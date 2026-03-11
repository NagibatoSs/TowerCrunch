using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class CountdownBlockController : MonoBehaviour
{
    [SerializeField] TMP_Text timerText;
    [SerializeField] float animationDuration = 0.25f;
    [SerializeField] float goTextDuration = 0.2f;
    [SerializeField] CanvasGroup countdownGroup;
    [SerializeField] GameStateMachine gameStateMachine;
    private Transform textTransform;
    public Action OnCountdownFinished;

    private void Awake()
    {
        textTransform = timerText.transform;
    }

    private void OnEnable()
    {
        gameStateMachine.OnStateChanged += OnStateChangedDelegate;
    }

    private void OnDisable()
    {
        gameStateMachine.OnStateChanged -= OnStateChangedDelegate;
    }

    private void OnStateChangedDelegate(GameState state)
    {
        if (state == GameState.Game)
        {
            StartCountdown();
        }
    }

    private void StartCountdown()
    {
        timerText.text = "";
        timerText.transform.localScale = Vector3.one;

        countdownGroup.alpha = 1;
        countdownGroup.blocksRaycasts = true;

        StartCoroutine(Countdown());
    }


    private IEnumerator Countdown()
    {
        timerText.text = "3";
        yield return PopAnimation();
        yield return new WaitForSeconds(Mathf.Max(0, 1 - animationDuration));

        timerText.text = "2";
        yield return PopAnimation();
        yield return new WaitForSeconds(Mathf.Max(0, 1 - animationDuration));

        timerText.text = "1";
        yield return PopAnimation();
        yield return new WaitForSeconds(Mathf.Max(0, 1 - animationDuration));

        timerText.text = "Вперед!";
        yield return PopAnimation();
        yield return new WaitForSeconds(goTextDuration);

        OnCountdownFinished?.Invoke();

        countdownGroup.alpha = 0;
        countdownGroup.blocksRaycasts = false;
    }

    IEnumerator PopAnimation()
    {
        float t = 0;

        while (t < animationDuration)
        {
            t += Time.deltaTime;

            float cubic = Mathf.Sin(t / animationDuration * Mathf.PI * 0.5f);

            textTransform.localScale = Vector3.Lerp(Vector3.one * 0.5f, Vector3.one * 1.2f, cubic);

            yield return null;
        }

    }

}
