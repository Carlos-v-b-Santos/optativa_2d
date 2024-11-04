using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonWeaponController : WeaponController
{
    [SerializeField] private ParticleSystem _fireEffect;

    public float modifySize = 0;

    // Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();
    }

    protected override void FireWeapon()
    {
        base.FireWeapon();
        //AudioManager.Instance.cannonAudioSource.PlayOneShot(clip);
        Instantiate(weaponData._WeaponPrefab, this.transform.position, this.transform.rotation, projectilesTransform);
        _fireEffect.Play();

    }

    public virtual void UpgradeSize(float sizeStep)
    {
        this.modifySize += sizeStep;
        GameManager.Instance.UpgradeChoiced();
    }
}
