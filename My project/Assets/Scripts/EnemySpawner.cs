using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> _enemies;
    [SerializeField] GameObject _player;
    [SerializeField] Vector2 spawnArea;
    [SerializeField] float spawnTimer;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemySpawn());
    }

    IEnumerator EnemySpawn()
    {
        while (true)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(spawnTimer);
        }
    }

    private void SpawnEnemy()
    {
        Vector3 position = GenerateRandomPosition();
        position += _player.transform.position;
        

        GameObject newEnemy = Instantiate(_enemies[Random.Range(0, _enemies.Count)]);
        
        newEnemy.transform.position = position;
        newEnemy.GetComponent<EnemyMovement>().player = _player;
    }

    private Vector3 GenerateRandomPosition()
    {
        Vector3 position = new Vector3();
        
        //50% para ficar em cada lado
        float f = UnityEngine.Random.value > 0.5f ? -1f : 1f;
        if(UnityEngine.Random.value > 0.5f)
        {
            position.x = UnityEngine.Random.Range(-spawnArea.x, spawnArea.x);
            position.y = spawnArea.y * f;
        }
        else
        {
            position.y = UnityEngine.Random.Range(-spawnArea.y, spawnArea.y);
            position.x = spawnArea.x * f;
        }
        position.z = 0;

        return position;
    }
}
