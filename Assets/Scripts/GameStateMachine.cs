using System;
using UnityEngine;

public class GameStateMachine : MonoBehaviour
{
    public GameState CurrentState { get; private set; }
    public event Action<GameState> OnStateChanged;
    public event Action OnWin;
    private void OnEnable()
    {
        CurrentState = GameState.Menu;
    }

    public void SetState(GameState state)
    {
        if (CurrentState == state)
            return;
        Debug.Log(state);
        CurrentState = state;
        OnStateChanged?.Invoke(state);
    }

    public void SetMenu()
    {
        SetState(GameState.Menu);
    }

    public void SetGame()
    {
        SetState(GameState.Game);
    }

    public void SetLose()
    {
        SetState(GameState.Lose);
    }

    public void SetWin()
    {
        SetState(GameState.Win);
        OnWin?.Invoke();
    }
}
