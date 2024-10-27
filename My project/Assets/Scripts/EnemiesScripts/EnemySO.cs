using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//para aparecer no menu de criação
[CreateAssetMenu(fileName ="EnemySO", menuName ="ScriptableObjects/Enemy")]
public class EnemySO : ScriptableObject
{
    [SerializeField] GameObject _enemyPrefab;
    public GameObject _EnemyPrefab { get => _enemyPrefab; private set => _enemyPrefab = value; }

    [SerializeField] float moveSpeed;
    public float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }

    [SerializeField] float maxHealth;
    public float MaxHealth { get => maxHealth; set => maxHealth = value; }

    [SerializeField] float damage;
    public float Damage { get => damage; set => damage = value; }

    [SerializeField] GameObject _expPrefab;
    public GameObject _ExpPrefab { get => _expPrefab; private set => _expPrefab = value; }

}
