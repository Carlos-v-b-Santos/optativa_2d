using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [SerializeField] EnemySO enemyData;

    EnemyStatsModify enemyStatsModify;

    [SerializeField] private float currentMoveSpeed;
    [SerializeField] private float currentHealth;
    public float currentDamage;

    [SerializeField] private AudioClip audioClip;

    private void Awake()
    {
        enemyStatsModify = GameObject.FindGameObjectWithTag("EnemySpawner").GetComponent<EnemyStatsModify>();

        currentMoveSpeed = enemyData.MoveSpeed + enemyStatsModify.ModifySpeed;
        currentHealth = enemyData.MaxHealth + enemyStatsModify.ModifyHealth;
        currentDamage = enemyData.Damage + enemyStatsModify.ModifyDamage;
    }

    public void TakeDamage(float dmg)
    {
        currentHealth -= dmg;

        if (currentHealth <= 0)
        {
            Kill();
        }
    }

    private void Kill()
    {
        GameManager.Instance.score += enemyData.PointValue;
        Instantiate(enemyData._ExpPrefab,this.transform.position,Quaternion.identity);
        KillEffect();
        Destroy(this.gameObject);
    }

    private void KillEffect()
    {
        Instantiate(enemyData._KillEffect,this.transform.position,Quaternion.identity);
        AudioManager.Instance.monsterAudioSource.PlayOneShot(audioClip);
    }
}
