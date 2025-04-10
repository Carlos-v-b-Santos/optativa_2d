using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] public AudioSource musicAudioSource;
    [SerializeField] public AudioSource engineAudioSource;
    [SerializeField] public AudioSource monsterAudioSource;
    [SerializeField] public AudioSource bulletAudioSource;
    [SerializeField] public AudioSource laserAudioSource;
    [SerializeField] public AudioSource cannonAudioSource;
    [SerializeField] public AudioSource impactAudioSource;

    [SerializeField][Range(0,1)] private float musicVolume = 1f;

    [SerializeField] private List<AudioClip> musicPlaylist;
    [SerializeField] private int currentTrackIndex = 0;
    [SerializeField] private bool loopPlaylist = true;

    // Start is called before the first frame update
    void Awake()
    {
        if(Instance != null)
        {
            Debug.LogError("Mais que um AudioManager");
            return;
        }
        Instance = this;

        musicAudioSource.volume = musicVolume;

        if (musicPlaylist.Count > 0)
        {
            PlayCurrentTrack();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!musicAudioSource.isPlaying && musicPlaylist.Count > 0 && !GameManager.Instance.IsPaused)
        {
            NextTrack();
        }
    }
    private void PlayCurrentTrack()
    {
        musicAudioSource.clip = musicPlaylist[currentTrackIndex];
        musicAudioSource.Play();
    }

    public void PauseTrack()
    {
        musicAudioSource.Pause();
    }

    public void UnpauseTrack()
    {
        musicAudioSource.UnPause();
    }
    public void NextTrack()
    {
        currentTrackIndex++;

        // Se chegou ao final da playlist
        if (currentTrackIndex >= musicPlaylist.Count)
        {
            if (loopPlaylist)
            {
                currentTrackIndex = 0; // Reinicia a playlist
            }
            else
            {

                ClearAudioChannels();
                GameManager.Instance.VictorySequence();

                return; // Sai se n�o h� mais faixas para tocar
            }
        }

        PlayCurrentTrack();
    }

    public void StopMusic()
    {
        musicAudioSource.Stop();
    }
    public void SetMusicVolume(float volume)
    {
        musicVolume = Mathf.Clamp01(volume);
        musicAudioSource.volume = musicVolume;
    }

    public void ClearAudioChannels()
    {
        musicAudioSource.Stop();
        engineAudioSource.Stop();
        monsterAudioSource.Stop();
        bulletAudioSource.Stop();
        laserAudioSource.Stop();
        cannonAudioSource.Stop();
        impactAudioSource.Stop();
    }

    public void PlayOneShot(AudioClip clip)
    {
        musicAudioSource.PlayOneShot(clip,1);
    }
}
