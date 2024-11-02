using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonWeaponController : WeaponController
{
    [SerializeField] private ParticleSystem _fireEffect;

    public int modifyPierce = 0;

    // Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();
    }

    protected override void FireWeapon()
    {
        base.FireWeapon();
        Instantiate(weaponData._WeaponPrefab, this.transform.position, this.transform.rotation, projectilesTransform);
        _fireEffect.Play();

    }

    public virtual void UpgradePierce(int modifyPierce)
    {
        this.modifyPierce += modifyPierce;
        GameManager.Instance.UpgradeChoiced();
    }
}
