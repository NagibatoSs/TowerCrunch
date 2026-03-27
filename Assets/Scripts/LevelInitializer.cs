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
    [SerializeField] Camera mainCamera;

    Vector3 cameraStartPos;
    Vector3 spawnStartPos;
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

    private void Start()
    {
        if (mainCamera != null)
            cameraStartPos = mainCamera.transform.position;

        if (spawner != null)
            spawnStartPos = spawner.transform.position;
    }

    private void GetCurrentLevel()
    {
        int levelId = playerData.Model.LastLevelNumber - 1;
        if (levelId < 0) levelId = 0;
        if (levelId > levelsData.Levels.Count - 1) 
            levelId = levelId % levelsData.Levels.Count;
        currentLevel = levelsData.Levels[levelId];
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

        var camFollow = mainCamera?.GetComponent<CameraFollowing>();
        if (camFollow != null)
            camFollow.ResetPosition(cameraStartPos, spawnStartPos);

        OnInitialize?.Invoke();
    }


}
