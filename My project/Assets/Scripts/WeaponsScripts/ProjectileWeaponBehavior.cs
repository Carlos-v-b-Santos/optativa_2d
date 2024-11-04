using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWeaponBehavior : MonoBehaviour
{
    [SerializeField] protected WeaponSO weaponData;
    [SerializeField] protected int CurrentPierce;
    public float CurrentDamage;

    [SerializeField] protected AudioClip impactAudio;

    // Start is called before the first frame update
    protected virtual void Awake()
    {
        CurrentDamage = weaponData.Damage;
        CurrentPierce = weaponData.Pierce;

        Destroy(this.gameObject, weaponData.Duration);
    }

    public virtual void DecreasePierce()
    {
        ImpactEffect();

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

    protected void ImpactEffect()
    {
        Instantiate(weaponData._ImpactEffect, this.transform.position, Quaternion.identity);
        AudioManager.Instance.impactAudioSource.PlayOneShot(impactAudio);
    }
}
