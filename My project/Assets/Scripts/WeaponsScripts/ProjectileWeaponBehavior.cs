using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWeaponBehavior : MonoBehaviour
{
    [SerializeField] protected WeaponSO weaponData;
    public float CurrentDamage { get; private set; }
    public float CurrentPierce { get; private set; }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        CurrentDamage = weaponData.Damage;
        CurrentPierce = weaponData.Pierce;

        Destroy(this.gameObject, weaponData.Duration);
    }

    public virtual void DecreasePierce()
    {
        CurrentPierce--;

        if (CurrentPierce <= 0)
        {
            DestroyProjetile();
        }
    }

    public virtual void DestroyProjetile()
    {
        Destroy(this.gameObject);
    }

    public virtual void UpdateDamage(float modifyDamage)
    {
        CurrentDamage += modifyDamage;
    }
}
