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

    TransitionEffect transitionEffect;

    [SerializeField] private PlayerStats _player;

    [SerializeField] private GameObject _allySpaceships;
    [SerializeField] private GameObject _finalBoss;

    [SerializeField] private bool victoryFlag = false;

    public bool IsPaused { get; private set; }

    public int score = 0;

    [SerializeField] private string scoreRecordKey = "SCORE_RECORD";
    [SerializeField] private string timeRecordKey = "TIME_RECORD";
    [SerializeField] private string scoreKey = "SCORE_PLAYER";
    [SerializeField] private string timeKey = "TIME_PLAYER";

    [SerializeField] private float delayFinalSequenceSeconds;

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

        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        transitionEffect = FindObjectOfType<TransitionEffect>();

        transitionEffect.FadeOut();

        ResumeGame();
    }
    public void LevelUP()
    {
        if (victoryFlag) return;

        PauseGame();
        HUDManager.Instance.ShowLevelUP();
    }

    public void PauseGame()
    {
        IsPaused = true;
        Time.timeScale = 0;
        AudioManager.Instance.PauseTrack();
    }

    public void ResumeGame()
    {
        IsPaused = false;
        transitionEffect.FadeOut();
        Time.timeScale = 1;
        AudioManager.Instance.UnpauseTrack();
    }

    public void UpgradeChoiced()
    {
        HUDManager.Instance.HideLevelUP();
        ResumeGame();
    }

    public void ChanceScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void GameOver()
    {
        if (victoryFlag) return;

        PauseGame();
        SaveRecord();

        ChanceScene(2);
    }

    public void SaveRecord()
    {
        float time = TimeManager.Instance.time;

        PlayerPrefs.SetInt(scoreKey, score);
        PlayerPrefs.SetFloat(timeKey, time);

        if (score > PlayerPrefs.GetInt(scoreRecordKey))
        {
            PlayerPrefs.SetInt(scoreRecordKey, score);
        }

        if (time > PlayerPrefs.GetFloat(timeRecordKey))
        {
            PlayerPrefs.SetFloat(timeRecordKey, time);
        }
    }

    public void WinGame()
    {


        ChanceScene(3);
    }

    public void VictorySequence()
    {
        if (victoryFlag) return;

        SaveRecord();
        victoryFlag = true;

        Debug.Log("Vitória!");
        playerInputActions.Player.Disable();
        HUDManager.Instance.HideHud();

        Transform enemiesGroup = GameObject.FindWithTag("EnemiesGroup").GetComponent<Transform>();

        GameObject.Instantiate(_finalBoss,enemiesGroup);

        StartCoroutine(FinalSequenceDelay());
    }

    public void ExitGame()
    {
        Screen.sleepTimeout = SleepTimeout.SystemSetting;

        Application.Quit();
    }

    IEnumerator FinalSequenceDelay()
    {
        yield return new WaitForSeconds(delayFinalSequenceSeconds);

        GameObject.Instantiate(_allySpaceships);
    }
}
