using System;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerScriptableModel", menuName = "Scriptable Objects/PlayerScriptableModel")]
public class PlayerScriptableModel: ScriptableObject, IStorable
{
    [SerializeField] private PlayerModel model;
    public PlayerModel Model => model;
    private const string SAVE_KEY = "playerData";
    public void Load()
    {
        if (!PlayerPrefs.HasKey(SAVE_KEY)) return;

        string json = PlayerPrefs.GetString(SAVE_KEY);
        PlayerModel data = JsonUtility.FromJson<PlayerModel>(json);
        model = data;
    }

    public void Save()
    {
        string json = JsonUtility.ToJson(model);
        PlayerPrefs.SetString(SAVE_KEY, json);
    }
}
