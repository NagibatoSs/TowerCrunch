using UnityEngine;

[CreateAssetMenu(fileName = "PoolConfig", menuName = "Scriptable Objects/PoolConfig")]
public class PoolConfig : ScriptableObject
{
    [SerializeField] private GameObject prefab;
    public GameObject Prefab => prefab;

    [SerializeField] private int initialSize;

    public int InitialSize => initialSize;
}
