using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rb2D;
    [SerializeField] float speed;
    // Start is called before the first frame update
    void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.AddRelativeForce(Vector2.up * speed);
    }
}
