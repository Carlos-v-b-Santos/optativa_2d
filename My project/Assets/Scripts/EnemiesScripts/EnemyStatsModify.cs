using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatsModify : MonoBehaviour
{
    [SerializeField] public float ModifySpeed { get; private set; }
    [SerializeField] public float ModifyDamage { get; private set; }
    //[SerializeField] public float ModifyHealth { get; private set; }
    public float ModifyHealth;

    [SerializeField] private float difficultyMilestone = 60;
    [SerializeField] private float difficultyStep = 60;

    [SerializeField] private float healthStep = 1f;
    [SerializeField] private float damageStep = 0f;
    [SerializeField] private float speedStep = 0.1f;

    private void Update()
    {
        if (TimeManager.Instance.time >= difficultyMilestone)
        {
            Debug.Log("Stats de Inimigos aumentados");
            IncreaseStats();
            difficultyMilestone += difficultyStep;
        }
    }

    private void IncreaseStats()
    {
        IncreaseModifyDamage(damageStep);
        IncreaseModifyHealth(healthStep);
        IncreaseModifySpeed(speedStep);
    }

    private void IncreaseModifyDamage(float value)
    {
        ModifyDamage += value;
    }

    private void IncreaseModifyHealth(float value)
    {
        ModifyHealth += value;
    }

    private void IncreaseModifySpeed(float value)
    {
        ModifySpeed += value;
    }

}
