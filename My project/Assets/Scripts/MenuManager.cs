using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _introCanva;
    [SerializeField] private GameObject _btnPlay;
    [SerializeField] private GameObject _menuInicial;

    public void PlayIntro()
    {
        _menuInicial.SetActive(false);
        _introCanva.SetActive(true);
        _btnPlay.SetActive(true);
    }
}
