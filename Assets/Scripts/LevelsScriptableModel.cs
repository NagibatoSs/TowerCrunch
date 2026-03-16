using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelsScriptableModel", menuName = "Scriptable Objects/LevelsScriptableModel")]
public class LevelsScriptableModel : ScriptableObject
{
    [SerializeField] private List<LevelData> levels;

    public List<LevelData> Levels => levels;

    public LevelData GetLevel(int levelNumber)
    {
        return levels.Find(l => l.LevelNumber == levelNumber);
    }
}
