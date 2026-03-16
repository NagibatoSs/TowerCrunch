using UnityEngine;

public class LoseTimeCondition : MonoBehaviour
{
    [SerializeField] Timer timer;
    [SerializeField] GameStateMachine gameStateMachine;

    private void OnEnable()
    {
        timer.OnSecondChanged += CheckLose;
    }
    private void OnDisable()
    {
        timer.OnSecondChanged -= CheckLose;
    }

    private void CheckLose(int second)
    {
        if (second <= 0)
        {
            gameStateMachine.SetLose();
        }
    }
}
