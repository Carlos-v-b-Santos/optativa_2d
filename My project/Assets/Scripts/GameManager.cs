using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    //padrao
    public static GameManager Instance;

    //sistema de entrada
    public PlayerInputActions playerInputActions;

    [SerializeField] private GameObject _panel;

    // Start is called before the first frame update
    void Awake()
    {
        //instancia propria
        if (Instance != null)
        {
            Debug.LogError("Mais que um GameManager");
            return;
        }
        Instance = this;

        //instancia do input
        playerInputActions = new PlayerInputActions();
        if (playerInputActions != null)
        {
            Debug.Log("playerInputActions instaciado");
        }

        playerInputActions.Player.Enable();
    }

    private void Update()
    {
        
    }

    public void LevelUP()
    {
        PauseGame();
        _panel.SetActive(true);

    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public void UpgradeChoiced()
    {
        _panel.SetActive(false);
        ResumeGame();
    }
}
