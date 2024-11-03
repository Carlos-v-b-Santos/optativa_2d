using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    public static HUDManager Instance;

    [SerializeField] private PlayerStats _player;

    [SerializeField] private Slider _ExpSlider;

    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI clockText;
    
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private Image btnPause;
    [SerializeField] private Sprite btnPauseSprite;
    [SerializeField] private Sprite btnResumeSprite;
    private bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        if (Instance != null)
        {
            Debug.LogError("Mais que um HUDManager");
            return;
        }
        Instance = this;

        PauseButton();
    }

    private void Update()
    {
        clockText.text = string.Format("{0:00}:{1:00}", TimeManager.Instance.minutes, TimeManager.Instance.seconds);

        levelText.text = new string("Level: " + _player.Level);
        healthText.text = new string("VIDA: " + _player.health.ToString());
        scoreText.text = new string("Pontuação: " + GameManager.Instance.score);

        _ExpSlider.value = _player.exp;
        _ExpSlider.maxValue = _player.expToUpLevel;
    }

    public void PauseButton()
    {
        if (isPaused)
        {
            btnPause.sprite = btnPauseSprite;
            _pausePanel.SetActive(false);
            isPaused = false;
            GameManager.Instance.ResumeGame();
        }
        else
        {
            btnPause.sprite = btnResumeSprite;
            _pausePanel.SetActive(true);
            isPaused = true;
            GameManager.Instance.PauseGame();
        }
    }
}
