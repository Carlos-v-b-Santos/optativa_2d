using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//para aparecer no menu de cria��o
[CreateAssetMenu(fileName ="EnemySO", menuName ="ScriptableObjects/Enemy")]
public class EnemySO : ScriptableObject
{
    public float moveSpeed;
    public float maxHealth;
    public float damage;

}
