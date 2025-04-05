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

    [SerializeField] private GameObject _HUD;
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private GameObject _upgradePanel;
    [SerializeField] private GameObject _playerControllerUI;
    [SerializeField] private GameObject _btnPause;
    [SerializeField] private GameObject _victoryPanel;

    [SerializeField] private List<GameObject> _ConfirmButtons;
    [SerializeField] private List<GameObject> _UpgradeButtons;
    //[SerializeField] private Image btnPause;
    //[SerializeField] private TextMeshProUGUI btnPauseText;
    //[SerializeField] private TextMeshProUGUI btnResumeText;
    
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
        if (GameManager.Instance.IsPaused)
        {
            _btnPause.GetComponentInChildren<TextMeshProUGUI>().text = string.Format("PAUSAR");
            _pausePanel.SetActive(false);
            _playerControllerUI.SetActive(true);
            GameManager.Instance.ResumeGame();
        }
        else
        {
            _btnPause.GetComponentInChildren<TextMeshProUGUI>().text = string.Format("JOGAR");
            _pausePanel.SetActive(true);
            _playerControllerUI.SetActive(false);
            GameManager.Instance.PauseGame();
        }
    }

    public void ShowLevelUP()
    {
        _btnPause.SetActive(false);
        _upgradePanel.SetActive(true);
        _pausePanel.SetActive(false);
        _playerControllerUI.SetActive(false);
        ShowConfirmButtons(-1);
    }

    public void HideLevelUP()
    {
        _btnPause.SetActive(true);
        _upgradePanel.SetActive(false);
        _pausePanel.SetActive(false);
        _playerControllerUI.SetActive(true);
    }

    public void ShowControlButtons()
    {
        _playerControllerUI.SetActive(true);
    }

    public void HideControlButtons()
    {
        _playerControllerUI.SetActive(false);
    }

    public void HideHud()
    {
        _HUD.SetActive(false);
    }
    public void ShowHud()
    {
        _HUD.SetActive(true);
    }

    public void HideVictoryPanel()
    {
        _victoryPanel.SetActive(false);
    }
    public void ShowVictoryPanel()
    {
        _victoryPanel.SetActive(true);
    }

    public void ShowConfirmButtons(int index)
    {
        for(int i = 0; i < _ConfirmButtons.Count; i++)
        {
            if (i == index)
            {
                _ConfirmButtons[i].SetActive(true);
                _UpgradeButtons[i].SetActive(false);
            }
            else
            {
                _ConfirmButtons[i].SetActive(false);
                _UpgradeButtons[i].SetActive(true);
            }
        }
    }
}
