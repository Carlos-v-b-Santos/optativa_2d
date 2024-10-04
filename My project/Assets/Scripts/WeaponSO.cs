using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//para aparecer no menu de criação
[CreateAssetMenu(fileName ="WeaponSO", menuName ="ScriptableObjects/Weapon")]
public class WeaponSO : ScriptableObject
{
    [Header("Weapon Stats")]//organização no editor
    [SerializeField] GameObject _weaponPrefab;
    public GameObject _WeaponPrefab { get => _weaponPrefab; private set => _weaponPrefab = value; }

    [SerializeField] float damage;
    public float Damage { get => damage; private set => damage = value; }

    [SerializeField] float speed;
    public float Speed { get => speed; private set => speed = value; }

    [SerializeField] float cooldown;
    public float Cooldown { get => cooldown; private set => cooldown = value; }
    
    [SerializeField] float duration;
    public float Duration { get =>  duration; private set => duration = value; }

    [SerializeField] int pierce;
    public int Pierce { get => pierce; private set => pierce = value; }

}
