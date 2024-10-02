using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float velocity;
    [SerializeField] Rigidbody2D rb2D;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //rb2D.MovePosition();
        rb2D.AddForce((player.transform.position - this.transform.position).normalized * velocity);

    }
}
