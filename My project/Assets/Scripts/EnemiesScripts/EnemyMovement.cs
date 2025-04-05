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

    [SerializeField] private float teleportDist;
    [SerializeField] private float teleportDistModify;

    // Start is called before the first frame update
    void Awake()
    {
        enemyStats = GetComponent<EnemyStats>();
        rb2D = GetComponent<Rigidbody2D>();

        Camera _camera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        float cameraWidth = _camera.orthographicSize * 2f * _camera.aspect;
        teleportDist = cameraWidth * teleportDistModify;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //rb2D.MovePosition();
        rb2D.AddForce((player.transform.position - this.transform.position).normalized * enemyData.MoveSpeed);
       
        if (player != null)
        {
            Vector2 direction =  this.transform.position - player.transform.position;
            this.transform.rotation = Quaternion.FromToRotation(Vector3.up, direction);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == null) return;

        if (collision.gameObject.CompareTag("Projectile"))
        {
            
            StartCoroutine(DamageEffect());
            DamageManager.Instance.CalcDamage(collision.gameObject.GetComponent<ProjectileWeaponBehavior>(),this.enemyStats);

            collision.GetComponent<ProjectileWeaponBehavior>().DecreasePierce();
        }
    }

    IEnumerator DamageEffect()
    {
        SpriteRenderer c = GetComponent<SpriteRenderer>();

        for (int i = 0; i < 11; i++)
        {
            if (i/2 == 0)
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

    public void Teleport()
    {
        Vector2 forwardPlayer = player.transform.up.normalized;
        Vector2 newPos = (Vector2)player.transform.position + forwardPlayer * teleportDist;

        transform.position = newPos;
    }
}
