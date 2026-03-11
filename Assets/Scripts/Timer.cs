using System;
using System.Collections;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float startTime = 30f;
    [SerializeField] CountdownBlockController countdownController;
    public Action<int> OnSecondChanged;
    float remainingTime = 0f;
    int lastSecond;
    int currentSecond;
    bool isPause = false;

    private void OnEnable()
    {
        countdownController.OnCountdownFinished += StartTimer;
    }

    private void OnDisable()
    {
        countdownController.OnCountdownFinished -= StartTimer;
    }

    private void Start() 
    {
        OnSecondChanged?.Invoke(Mathf.CeilToInt(startTime));
    }

    public void SetTime(float time)
    {
        startTime = time;
        OnSecondChanged?.Invoke(Mathf.CeilToInt(startTime));
    }

    public void PauseTimer()
    {
        isPause = true;
    }

    public void ResumeTimer()
    {
        isPause = false;
    }

    public void StartTimer()
    {
        remainingTime = startTime;
        lastSecond = Mathf.CeilToInt(startTime);
        OnSecondChanged?.Invoke(lastSecond);
    }

    private void Update()
    {
        if (remainingTime <= 0) return;
        if (isPause) return;

        remainingTime -= Time.deltaTime;

        currentSecond = Mathf.CeilToInt(remainingTime);
        if (currentSecond != lastSecond)
        {
            lastSecond = currentSecond;
            OnSecondChanged?.Invoke(currentSecond);
        }
    }
}
