using UnityEngine;

public enum SFXType
{
    Crunch,
    BlockSet,
    Coin
}

[CreateAssetMenu(fileName = "SFXData", menuName = "Scriptable Objects/SFXData", order = 51)]
public class SFXData : ScriptableObject
{
    [SerializeField] private SFXType type;
    public SFXType SFXType => type;

    [SerializeField] private AudioClip clip;
    public AudioClip Clip => clip;

    [SerializeField] private float minPitch = 0.9f;
    public float MinPitch => minPitch;

    [SerializeField] private float maxPitch = 1.1f;
    public float MaxPitch => maxPitch;

}
