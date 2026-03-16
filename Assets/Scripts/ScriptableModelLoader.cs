using System.Collections.Generic;
using UnityEngine;

public class ScriptableModelLoader : MonoBehaviour
{
    [SerializeField] protected List<ScriptableObject> scriptableModelsList;

    public List<ScriptableObject> ScriptableModelsList => scriptableModelsList;

    private void Start()
    {
        ScriptableModelsList.ForEach(scriptableModel =>
        {
            (scriptableModel as IStorable)?.Load();
        });
    }

    private void OnDisable()
    {
        ScriptableModelsList.ForEach(scriptableModel =>
        {
            (scriptableModel as IStorable)?.Save();
        });
    }

    private void OnApplicationPause(bool pause)
    {
        if(!pause) return;

        ScriptableModelsList.ForEach(scriptableModel =>
        {
            (scriptableModel as IStorable)?.Save();
        });
    }

    void OnApplicationQuit()
    {
        ScriptableModelsList.ForEach(scriptableModel =>
        {
            (scriptableModel as IStorable)?.Save();
        });
    }
}
