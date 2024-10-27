using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Exp : MonoBehaviour
{
    [SerializeField] float velocity;
    public int expPoint = 1;

    private GameObject player;
    private Rigidbody2D rb2D;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector2 direction = player.transform.position - this.transform.position;

        rb2D.velocity = velocity * direction;
    }
    
}
