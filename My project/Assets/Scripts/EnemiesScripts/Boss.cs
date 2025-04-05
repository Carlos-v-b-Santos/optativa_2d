using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] EnemySO enemyData;
    EnemyStats enemyStats;

    void Awake()
    {
        enemyStats = GetComponent<EnemyStats>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == null) return;

        if (collision.gameObject.CompareTag("Projectile"))
        {

            StartCoroutine(DamageEffect());
            DamageManager.Instance.CalcDamage(collision.gameObject.GetComponent<ProjectileWeaponBehavior>(), this.enemyStats);

            Destroy(collision.gameObject);
        }
    }

    IEnumerator DamageEffect()
    {
        SpriteRenderer c = GetComponent<SpriteRenderer>();

        for (int i = 0; i < 11; i++)
        {
            if (i / 2 == 0)
            {
                c.color = new Color(1f, 1f, 1f, 0.1f);
                yield return new WaitForSeconds(.1f);
            }
            else
            {
                c.color = new Color(1f, 1f, 1f, 1f);
                yield return new WaitForSeconds(.1f);
            }
        }
    }
}
