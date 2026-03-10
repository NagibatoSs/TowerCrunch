using System;
using UnityEngine;

public class GameStateMachine : MonoBehaviour
{
    public GameState CurrentState { get; private set; }
    public event Action<GameState> OnStateChanged;
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

    public void SetEndGame()
    {
        SetState(GameState.EndGame);
    }

    public void SetPause()
    {
        SetState(GameState.Pause);
    }
    public void SetWin()
    {
        SetState(GameState.Win);
    }
}
