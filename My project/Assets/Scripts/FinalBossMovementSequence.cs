using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossMovementSequence : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Camera _camera;
    [SerializeField] private float correction = 5;

    [SerializeField] private Vector3 initialPosition;
    [SerializeField] private float duration;
    [SerializeField] private float finalHeight;

    [SerializeField] private AudioClip finalBossMusic;
    [SerializeField] private AudioClip victoryMusic;

    // Start is called before the first frame update
    void Awake()
    {
        AudioManager.Instance.PlayOneShot(finalBossMusic);

        playerTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
        _camera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();

        transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y + _camera.orthographicSize + correction, 0);

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

        // Garante que a posição final seja alcançada
        transform.position = finalPosition;
    }
    private void Update()
    {
        if (transform.childCount > 0)
            return;

        AudioManager.Instance.ClearAudioChannels();
        AudioManager.Instance.PlayOneShot(victoryMusic);
        HUDManager.Instance.ShowVictoryPanel();

        Destroy(this.gameObject);
    }
}
