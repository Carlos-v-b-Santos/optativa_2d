using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//para aparecer no menu de cria��o
[CreateAssetMenu(fileName ="WeaponSO", menuName ="ScriptableObjects/Weapon")]
public class WeaponSO : ScriptableObject
{
    [Header("Weapon Stats")]//organiza��o no editor
    public GameObject _weaponPrefab;
    public float damage;
    public float speed;
    public float cooldown;
    public float duration;
    public int pierce;


}
