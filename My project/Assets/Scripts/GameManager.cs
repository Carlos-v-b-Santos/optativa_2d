using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //padrao
    public static GameManager Instance;

    //sistema de entrada
    public PlayerInputActions playerInputActions;

    // Start is called before the first frame update
    void Awake()
    {
        //instancia propria
        if (Instance != null)
        {
            Debug.LogError("Mais que um GameManager");
            return;
        }
        Instance = this;

        //instancia do input
        playerInputActions = new PlayerInputActions();
        if (playerInputActions != null)
        {
            Debug.Log("playerInputActions instaciado");
        }

        playerInputActions.Player.Enable();
    }
}
