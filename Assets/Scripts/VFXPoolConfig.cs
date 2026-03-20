using UnityEngine;

[CreateAssetMenu(fileName = "VFXPoolConfig", menuName = "Scriptable Objects/VFXPoolConfig")]
public class VFXPoolConfig : ScriptableObject
{
    [SerializeField] private GameObject prefab;
    public GameObject Prefab => prefab;

    [SerializeField] private int initialSize;

    public int InitialSize => initialSize;
}
