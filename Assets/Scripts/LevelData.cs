using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "Scriptable Objects/LevelData")]
public class LevelData : ScriptableObject
{
    [SerializeField] private int levelNumber;
    public int LevelNumber => levelNumber;

    [SerializeField] private int targetHeight;
    public int TargetHeight => targetHeight;

    [SerializeField] private float timeLimitInSeconds;
    public float TimeLimitInSeconds => timeLimitInSeconds;
}
