using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] float health = 3f;
    [SerializeField] int exp = 0;
    [SerializeField] int expToUpLevel = 100;
    [SerializeField] int increaseExpToUpLevel = 100;
    [SerializeField] int Level = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateExp(int expPoint)
    {
        exp += expPoint;
        if (exp >= expToUpLevel)
        {
            exp = 0;
            expToUpLevel += increaseExpToUpLevel;
            Level++;
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
