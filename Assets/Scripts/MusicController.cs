using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicController : MonoBehaviour
{
    [SerializeField] private AudioSource musicSource;
    void Start()
    {
        if (musicSource == null)
            musicSource = GetComponent<AudioSource>();
        musicSource.Play();
    }

    public void Play()
    {
        musicSource.Play();
    }

    public void Stop()
    {
        musicSource.Stop();
    }
    public void ChangeMuteMode()
    {
        if (!musicSource.mute)
            MuteMusic();
        else
            UnmuteMusic();
        
    }
    public void MuteMusic()
    {
        musicSource.mute = true;
    }
    public void UnmuteMusic()
    {
        musicSource.mute = false;
    }
}
