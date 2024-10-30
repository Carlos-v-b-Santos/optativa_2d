using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalUIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreRecord;
    [SerializeField] private TextMeshProUGUI timeRecord;
    [SerializeField] private TextMeshProUGUI score;
    [SerializeField] private TextMeshProUGUI time;

    [SerializeField] private string scoreRecordKey = "SCORE_RECORD";
    [SerializeField] private string timeRecordKey = "TIME_RECORD";
    [SerializeField] private string scoreKey = "SCORE_PLAYER";
    [SerializeField] private string timeKey = "TIME_PLAYER";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreRecord.text = new string("Pontuação: " + PlayerPrefs.GetInt(scoreRecordKey));
        timeRecord.text = string.Format("{0:00}:{1:00}", Mathf.FloorToInt(PlayerPrefs.GetFloat(timeRecordKey) / 60), 
            Mathf.FloorToInt(PlayerPrefs.GetFloat(timeRecordKey) % 60));

        score.text = new string("Pontuação: " + PlayerPrefs.GetInt(scoreKey));
        time.text = string.Format("{0:00}:{1:00}", Mathf.FloorToInt(PlayerPrefs.GetFloat(timeKey) / 60),
            Mathf.FloorToInt(PlayerPrefs.GetFloat(timeKey) % 60));
    }
}
