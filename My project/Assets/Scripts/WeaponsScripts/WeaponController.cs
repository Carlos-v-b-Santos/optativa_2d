using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] protected WeaponSO weaponData;
    [SerializeField] protected Transform projectilesTransform;
    [SerializeField] protected AudioClip clip;
    //[SerializeField] protected GameObject _WeaponPrefab;
    public float currentCooldown;

    // Start is called before the first frame update
    protected virtual void Awake()
    {
        projectilesTransform = GameObject.FindWithTag("ProjectileGroup").GetComponent<Transform>();

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
        //AudioManager.Instance.projectileAudioSource.PlayOneShot(clip);
        //Instantiate(_WeaponPrefab, this.transform);
    }
}
