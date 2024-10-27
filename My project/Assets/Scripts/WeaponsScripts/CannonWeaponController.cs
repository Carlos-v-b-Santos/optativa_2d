using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonWeaponController : WeaponController
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    protected override void FireWeapon()
    {
        base.FireWeapon();
        Instantiate(weaponData._WeaponPrefab, this.transform.position, this.transform.rotation);
    }
}
