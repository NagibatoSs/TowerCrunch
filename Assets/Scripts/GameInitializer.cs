using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    [SerializeField] Timer timer;
    [SerializeField] int targetHeight;
    [SerializeField] BlockSpawner spawner;
    [SerializeField] TowerManager towerManager;
    [SerializeField] GameStateMachine stateMachine;

    private void OnEnable()
    {
        stateMachine.OnStateChanged += OnStateChangedDelegate;
    }
    private void OnDisable()
    {
        stateMachine.OnStateChanged -= OnStateChangedDelegate;
    }

    private void OnStateChangedDelegate(GameState state)
    {
        if (state == GameState.Game)
            Initialize();
    }
    private void Initialize()
    {
        timer.SetTime(25);
        spawner.StartGame();
    }


}
