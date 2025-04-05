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
    [SerializeField] PlayerStats playerStats;
    [SerializeField] GameObject rightFlame;
    [SerializeField] GameObject leftFlame;

    private bool isRightActived;
    private bool isLeftActived;

    [SerializeField] AudioClip audioClip;

     // Start is called before the first frame update
    void Awake()
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
        isRightActived = false;
        isLeftActived = false;

        //leitura no input system
        float playerForward =  GameManager.Instance.playerInputActions.Player.Forward.ReadValue<float>();
        float playerRotation = GameManager.Instance.playerInputActions.Player.Rotation.ReadValue<float>();

        // movimentação
        if (playerForward > 0)
        {
            if(rb2D.velocity.magnitude < maxVelocity)
            {
                rb2D.AddRelativeForce(speed * playerForward * Vector2.up);
            }

            isRightActived = true;
            isLeftActived = true;
        }

        //rotação
        if (playerRotation != 0)
        {
            rb2D.AddTorque(rotation * playerRotation);
            if (playerRotation > 0)
            {
                isRightActived = true;
            }
            else
            {
                isLeftActived = true;
            }
        }

        if (!isRightActived)
        {
            rightFlame.SetActive(false);
        }
        else
        {
            rightFlame.SetActive(true);
        }

        if (!isLeftActived)
        {
            leftFlame.SetActive(false);
        }
        else
        {
            leftFlame.SetActive(true);
            
        }

        if (isRightActived || isLeftActived)
        {
            if (!AudioManager.Instance.engineAudioSource.isPlaying)
            {
                AudioManager.Instance.engineAudioSource.Play();
            }
        }
        else
        {
            AudioManager.Instance.engineAudioSource.Stop();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            StartCoroutine(DamageEffect());
            playerStats.TakeDamage(collision.gameObject.GetComponent<EnemyStats>().currentDamage);
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Exp"))
        {
            playerStats.UpdateExp(collision.gameObject.GetComponent<Exp>().expPoint);
            Debug.Log("exp coletado");
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
