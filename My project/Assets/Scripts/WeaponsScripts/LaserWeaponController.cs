using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserWeaponController : WeaponController
{
    [SerializeField] private ParticleSystem _fireEffect;

    [SerializeField] private AimSystem aimSystem;
    [SerializeField] private float torretRotationVelocity = 1f;
    private Transform target;
    [SerializeField] public float modifyDamage;

    protected override void Awake()
    {
        base.Awake();
    }

    private void Update()
    {
        target = aimSystem.GetClosestEnemyTransform();
        if (target != null)
        {
            Vector2 direction = target.position - transform.position;
            Quaternion directionQuaternion = Quaternion.FromToRotation(Vector3.up, direction);
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, directionQuaternion, torretRotationVelocity);
        }
    }

    protected override void FireWeapon()
    {
        base.FireWeapon();
        AudioManager.Instance.laserAudioSource.PlayOneShot(clip);
        Instantiate(weaponData._WeaponPrefab, this.transform.position, this.transform.rotation, projectilesTransform);
        _fireEffect.Play();
    }

    public void UpgradeDamage(float modifyDamage)
    {
        this.modifyDamage += modifyDamage;
        GameManager.Instance.UpgradeChoiced();
    }
}
