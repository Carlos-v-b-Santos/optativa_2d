using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBehavior : ProjectileWeaponBehavior
{
    LaserWeaponController laserWeaponController;
    Rigidbody2D rb2D;

    // Start is called before the first frame update
    protected override void Awake()
    {
        laserWeaponController = GameObject.FindGameObjectWithTag("Laser").GetComponent<LaserWeaponController>();
        CurrentDamage = weaponData.Damage + laserWeaponController.modifyDamage;
        CurrentPierce = weaponData.Pierce;

        Destroy(this.gameObject, weaponData.Duration);

        rb2D = GetComponent<Rigidbody2D>();
        FireLaser();
    }

    protected void FireLaser()
    {
        rb2D.AddRelativeForce(Vector2.up * weaponData.Speed);
    }
}
