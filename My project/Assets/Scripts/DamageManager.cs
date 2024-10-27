using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageManager : MonoBehaviour
{
    public static DamageManager Instance;

    [SerializeField] public float modifyDamage; //{ get; private set; }


    private void Start()
    {
        if (Instance != null)
        {
            Debug.LogError("Mais que um DamageManager");
            return;
        }
        Instance = this;
    }

    public void CalcDamage(ProjectileWeaponBehavior projectile, EnemyStats enemy)
    {
        enemy.TakeDamage(projectile.CurrentDamage);
    }

    public virtual void UpgradeDamage(float modifyDamage)
    {
        this.modifyDamage += modifyDamage;
    }
}
