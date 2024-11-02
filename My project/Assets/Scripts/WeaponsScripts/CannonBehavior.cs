using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBehavior : ProjectileWeaponBehavior
{
    CannonWeaponController cannonWeaponController;
    private Transform cannonBallTransform;
    Rigidbody2D rb2D;

    [SerializeField] private Vector3 initialSize;
    [SerializeField] private Vector3 sizeScale;

    // Start is called before the first frame update
    protected override void Awake()
    {
        cannonWeaponController = GameObject.FindGameObjectWithTag("Cannon").GetComponent<CannonWeaponController>();

        CurrentDamage = weaponData.Damage;
        CurrentPierce = weaponData.Pierce + cannonWeaponController.modifyPierce;

        Destroy(this.gameObject, weaponData.Duration);

        cannonBallTransform = GetComponent<Transform>();
        rb2D = GetComponent<Rigidbody2D>();
        
        cannonBallTransform.localScale = initialSize;

        FireCannon();
    }

    private void FixedUpdate()
    {
        cannonBallTransform.localScale += sizeScale * Time.deltaTime;
    }

    protected void FireCannon()
    {
        rb2D.AddRelativeForce(Vector2.up * weaponData.Speed);
    }
}
