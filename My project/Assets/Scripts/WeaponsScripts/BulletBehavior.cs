using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class BulletBehavior : ProjectileWeaponBehavior
{
    Rigidbody2D rb2D;
    // Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();
        rb2D = GetComponent<Rigidbody2D>();
        FireBullet();
    }

    protected void FireBullet()
    {
        rb2D.AddRelativeForce(Vector2.up * weaponData.Speed);
    }
}
