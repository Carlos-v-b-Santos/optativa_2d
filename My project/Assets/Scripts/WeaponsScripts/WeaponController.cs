using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] protected WeaponSO weaponData;
    //[SerializeField] protected GameObject _WeaponPrefab;
    public float currentCooldown;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        currentCooldown = weaponData.Cooldown;

        StartCoroutine(FireWeaponSystem());
    }

    IEnumerator FireWeaponSystem()
    {
        while (true)
        {
            FireWeapon();
            yield return new WaitForSeconds(currentCooldown);
        }
    }

    protected virtual void FireWeapon()
    {
        //Instantiate(_WeaponPrefab, this.transform);
    }
}
