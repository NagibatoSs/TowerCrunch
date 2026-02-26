using UnityEngine;

public class GameReseter : MonoBehaviour
{
    [SerializeField] private GameStateMachine stateMachine;

    private void OnEnable()
    {
        stateMachine.OnStateChanged += ResetGame;
    }
    private void OnDisable()
    {
        stateMachine.OnStateChanged -= ResetGame;
    }

    void ResetGame(GameState state)
    {
        if (state == GameState.Game || state == GameState.Menu)
            Debug.Log("Reset");
    }
}
