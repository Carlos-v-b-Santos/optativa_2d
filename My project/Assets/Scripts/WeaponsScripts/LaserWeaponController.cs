using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserWeaponController : WeaponController
{ 
    [SerializeField] private AimSystem aimSystem;
    private Transform target;
    [SerializeField] public float modifyDamage;

    protected override void Start()
    {
        base.Start();
    }

    private void Update()
    {
        target = aimSystem.GetClosestEnemyTransform();
        if (target != null)
        {
            Vector2 direction = target.position - transform.position;
            this.transform.rotation = Quaternion.FromToRotation(Vector3.up, direction);
        }
    }

    protected override void FireWeapon()
    {
        base.FireWeapon();
        Instantiate(weaponData._WeaponPrefab, this.transform.position, this.transform.rotation);
    }

    public void UpgradeDamage(float modifyDamage)
    {
        this.modifyDamage += modifyDamage;
    }
}
