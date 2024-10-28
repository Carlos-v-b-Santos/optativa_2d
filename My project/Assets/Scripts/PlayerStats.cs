using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] public float health = 3f;
    [SerializeField] private float healthForLevel = 1f;
    [SerializeField] public int exp = 0;
    [SerializeField] public int expToUpLevel = 100;
    [SerializeField] int increaseExpToUpLevel = 100;
    [SerializeField] public int Level = 1;

    public void UpdateExp(int expPoint)
    {
        exp += expPoint;
        if (exp >= expToUpLevel)
        {
            exp = 0;
            expToUpLevel += increaseExpToUpLevel;
            Level++;
            GameManager.Instance.LevelUP();

            health += healthForLevel;
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if(health < 0)
        {
            Debug.Log("game over");
            this.gameObject.SetActive(false);
        }
    }

}
