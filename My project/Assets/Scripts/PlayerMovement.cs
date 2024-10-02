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
    [SerializeField] float brake;
    [SerializeField] float rotation;

    //PlayerInputActions playerInputActions;

    // Start is called before the first frame update

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        //playerInputActions = new PlayerInputActions();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GetMoveInput();
    }

    void GetMoveInput()
    {
        Debug.Log("teste");

        //Debug.Log(playerInputActions.Player.Forward.ReadValue<Vector2>());

        float playerForward =  GameManager.Instance.playerInputActions.Player.Forward.ReadValue<float>();
        float playerRotation = GameManager.Instance.playerInputActions.Player.Rotation.ReadValue<float>();

        Debug.Log("frente " + playerForward);
        Debug.Log("rotacao " + playerRotation);

        if (playerForward > 0)
        {

        }
        else if (playerForward < 0)
        {
        
        }
    }


}
