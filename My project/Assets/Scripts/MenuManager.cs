using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _introCanva;
    [SerializeField] private GameObject _btnPlay;
    [SerializeField] private GameObject _menuInicial;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClipIntro;
    [SerializeField] private AudioClip audioClipLoop;

    public void PlayIntro()
    {
        _menuInicial.SetActive(false);
        _introCanva.SetActive(true);
        _btnPlay.SetActive(true);
        audioSource.Stop();
        audioSource.PlayOneShot(audioClipIntro);
        StartCoroutine(PlayIntroAudio());
    }

    IEnumerator PlayIntroAudio()
    {
        while (audioSource.isPlaying)
        {
            yield return null;
        }
        audioSource.clip = audioClipLoop;
        audioSource.Play();
    }
}
