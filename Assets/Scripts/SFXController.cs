using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SFXController : MonoBehaviour
{
    private AudioSource audioSource;
    void Start()
    {
        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();
    }

    public void Play(SFXData data)
    {
        if (data == null) return;
        audioSource.pitch = Random.Range(data.MinPitch, data.MaxPitch);
        audioSource.PlayOneShot(data.Clip);
        audioSource.pitch = 1f;
    }

    public void ChangeMuteMode()
    {
        if (!audioSource.mute)
            MuteSFX();
        else
            UnmuteSFX();

    }
    public void MuteSFX()
    {
        audioSource.mute = true;
    }
    public void UnmuteSFX()
    {
        audioSource.mute = false;
    }
}
