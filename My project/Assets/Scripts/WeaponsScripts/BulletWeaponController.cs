using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BulletWeaponController : WeaponController
{
    [SerializeField] float maxAngle = 45f;
    [SerializeField] float rotationVelocity = 2f;

    [SerializeField] float time;
    [SerializeField] Quaternion initialRotation;

    float angle;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        initialRotation = transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        angle = Mathf.Sin(time) * maxAngle;

        transform.localRotation = initialRotation * Quaternion.Euler(0, 0, angle);

        time += Time.deltaTime * rotationVelocity;
    }

    protected override void FireWeapon()
    {
        base.FireWeapon();
        Instantiate(weaponData._WeaponPrefab, this.transform.position, transform.rotation * Quaternion.Euler(0, 0, 90));
        Instantiate(weaponData._WeaponPrefab, this.transform.position, transform.rotation * Quaternion.Euler(0, 0, -90));
    }

    public void UpgradeCooldown(float modifyCooldown)
    {
        this.currentCooldown -= modifyCooldown;
    }
}
