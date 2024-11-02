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
    [SerializeField] private PlayerStats _player;

    public int score = 0;

    [SerializeField] private string scoreRecordKey = "SCORE_RECORD";
    [SerializeField] private string timeRecordKey = "TIME_RECORD";
    [SerializeField] private string scoreKey = "SCORE_PLAYER";
    [SerializeField] private string timeKey = "TIME_PLAYER";

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
        
        ResumeGame();
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

    public void ChanceScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void GameOver()
    {
        PauseGame();

        float time = TimeManager.Instance.time;

        PlayerPrefs.SetInt(scoreKey,score);
        PlayerPrefs.SetFloat(timeKey,time);

        if (score > PlayerPrefs.GetInt(scoreRecordKey))
        {
            PlayerPrefs.SetInt(scoreRecordKey,score);
        }

        if (time > PlayerPrefs.GetFloat(timeRecordKey))
        {
            PlayerPrefs.SetFloat (timeRecordKey,time);
        }

        ChanceScene(2);
    }
}
