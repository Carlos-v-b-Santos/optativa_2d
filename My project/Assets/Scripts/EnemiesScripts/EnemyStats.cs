using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [SerializeField] EnemySO enemyData;

    float currentMoveSpeed;
    float currentHealth;
    public float currentDamage;

    private void Awake()
    {
        currentMoveSpeed = enemyData.MoveSpeed;
        currentHealth = enemyData.MaxHealth;
        currentDamage = enemyData.Damage;
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
        Instantiate(enemyData._ExpPrefab,this.transform.position,Quaternion.identity);
        Destroy(this.gameObject);
    }
}
