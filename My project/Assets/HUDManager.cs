using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDManager : MonoBehaviour
{
    public static HUDManager Instance;

    [SerializeField] private PlayerStats _player;

    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI clockText;

    // Start is called before the first frame update
    void Start()
    {
        if (Instance != null)
        {
            Debug.LogError("Mais que um HUDManager");
            return;
        }
        Instance = this;
    }

    private void Update()
    {
        clockText.text = string.Format("{0:00}:{1:00}", TimeManager.Instance.minutes, TimeManager.Instance.seconds);

        levelText.text = new string("Level: " + _player.Level);
        healthText.text = new string("VIDA: " + _player.health);
    }
}
