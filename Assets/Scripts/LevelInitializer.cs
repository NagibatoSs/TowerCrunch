using System;
using UnityEngine;

public class LevelInitializer : MonoBehaviour
{
    [SerializeField] Timer timer;
    [SerializeField] LevelsScriptableModel levelsData;
    [SerializeField] PlayerScriptableModel playerData;
    [SerializeField] BlockSpawner spawner;
    [SerializeField] GameStateMachine stateMachine;
    [SerializeField] LevelDataReseter levelReseter;
    public Action OnInitialize;
    private LevelData currentLevel;
    public int TargetHeight => currentLevel.TargetHeight;
    public int CurrentLevel => currentLevel.LevelNumber;


    private void OnEnable()
    {
        stateMachine.OnStateChanged += OnStateChangedDelegate;
    }
    private void OnDisable()
    {
        stateMachine.OnStateChanged -= OnStateChangedDelegate;
    }

    private void GetCurrentLevel()
    {
        int levelId = playerData.Model.LastLevelNumber - 1;
        if (levelId < 0) levelId = 0;
        if (levelId > levelsData.Levels.Count - 1) 
            levelId = levelId % levelsData.Levels.Count;
        currentLevel = levelsData.Levels[levelId];
        Debug.Log("TargetHeight " + TargetHeight);
        Debug.Log("CurrentLevel " + CurrentLevel);
    }

    private void OnStateChangedDelegate(GameState state)
    {
        if (state == GameState.Game)
        {
            levelReseter.CleanData();
            Initialize();
        }
    }
    public void Initialize()
    {
        GetCurrentLevel();
        timer.SetTime(currentLevel.TimeLimitInSeconds);
        spawner.StartGame();
        OnInitialize?.Invoke();
    }


}
