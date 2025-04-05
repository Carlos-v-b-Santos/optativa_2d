using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class VictoryMovementSequence : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Camera _camera;
    [SerializeField] private float correction = 5;

    [SerializeField] private Vector3 initialPosition;
    [SerializeField] private float duration;
    [SerializeField] private float finalHeight;

    [SerializeField] private AudioClip allySpaceshipMusic;

    // Start is called before the first frame update
    void Awake()
    {
        AudioManager.Instance.PlayOneShot(allySpaceshipMusic);

        playerTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
        _camera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        
        transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y - _camera.orthographicSize - correction, 0);

        initialPosition = transform.position;
        finalHeight = playerTransform.position.y + finalHeight;

        StartCoroutine(Move());
    }

    IEnumerator Move()
    {
        float time = 0f;
        Vector3 finalPosition = new Vector3(transform.position.x, finalHeight, transform.position.z);

        while (time < duration)
        {
            time += Time.deltaTime;
            transform.position = Vector3.Lerp(initialPosition, finalPosition, time / duration);
            yield return null;
        }

        // Garante que a posi��o final seja alcan�ada
        transform.position = finalPosition;
    }
}
