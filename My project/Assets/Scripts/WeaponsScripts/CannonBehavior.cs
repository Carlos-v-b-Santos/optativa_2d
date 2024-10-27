using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBehavior : ProjectileWeaponBehavior
{
    CannonWeaponController cannonWeaponController;
    Rigidbody2D rb2D;


    // Start is called before the first frame update
    protected override void Start()
    {
        cannonWeaponController = GameObject.FindGameObjectWithTag("Cannon").GetComponent<CannonWeaponController>();

        CurrentDamage = weaponData.Damage;
        CurrentPierce = weaponData.Pierce + cannonWeaponController.modifyPierce;

        Destroy(this.gameObject, weaponData.Duration);

        rb2D = GetComponent<Rigidbody2D>();
        FireCannon();
    }

    protected void FireCannon()
    {
        rb2D.AddRelativeForce(Vector2.up * weaponData.Speed);
    }
}
