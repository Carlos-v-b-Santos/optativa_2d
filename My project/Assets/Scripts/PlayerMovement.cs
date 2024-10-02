using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb2D;
    [SerializeField] float maxVelocity;
    [SerializeField] float speed;
    [SerializeField] float reverse;
    [SerializeField] float rotation;

     // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GetMoveInput();
    }

    void GetMoveInput()
    {
        //leitura no input system
        float playerForward =  GameManager.Instance.playerInputActions.Player.Forward.ReadValue<float>();
        float playerRotation = GameManager.Instance.playerInputActions.Player.Rotation.ReadValue<float>();

        // movimentação
        if (playerForward > 0)
        {
            rb2D.AddRelativeForce(speed * playerForward * Vector2.up);
        }
        else if (playerForward < 0)
        {
            rb2D.AddRelativeForce(reverse * playerForward * Vector2.up);
        }

        //rotação
        if (playerRotation != 0)
        {
            rb2D.AddTorque(rotation * playerRotation);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            this.gameObject.SetActive(false);
        }
    }
}
