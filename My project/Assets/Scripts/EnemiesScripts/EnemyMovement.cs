using System.Collections;
using System.Collections.Generic;
using System.Xml;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] EnemySO enemyData;
    EnemyStats enemyStats;

    [SerializeField] Rigidbody2D rb2D;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        enemyStats = GetComponent<EnemyStats>();
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //rb2D.MovePosition();
        rb2D.AddForce((player.transform.position - this.transform.position).normalized * enemyData.MoveSpeed);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == null) return;

        if (collision.gameObject.CompareTag("Projectile"))
        {
            DamageManager.Instance.CalcDamage(collision.gameObject.GetComponent<ProjectileWeaponBehavior>(),this.enemyStats);

            collision.GetComponent<ProjectileWeaponBehavior>().DecreasePierce();
        }
    }
}
