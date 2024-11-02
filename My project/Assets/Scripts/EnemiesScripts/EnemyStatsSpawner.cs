using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyStatsSpawner : MonoBehaviour
{
    [SerializeField] List<EnemySO> _enemies;
    [SerializeField] GameObject _player;
    [SerializeField] Transform _enemiesTranformParent;
    [SerializeField] Vector2 spawnArea;
    [SerializeField] float spawnTimer;

    [SerializeField] private float enemyMilestone = 90;
    [SerializeField] private float enemyStep = 90;
    [SerializeField] private int enemyPool = 1;

    // Start is called before the first frame update
    void Awake()
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

    private void Update()
    {
        if (TimeManager.Instance.time >= enemyMilestone)
        {
            Debug.Log("mais inimigos para spawnar");
            enemyMilestone += enemyStep;
            IncreaseEnemies();
        }
    }
    private void SpawnEnemy()
    {
        Vector3 position = GenerateRandomPosition();
        position += _player.transform.position;
        

        GameObject newEnemy = Instantiate(_enemies[Random.Range(0, enemyPool)]._EnemyPrefab,_enemiesTranformParent);
        
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

    public void IncreaseEnemies()
    {
        if(enemyPool < _enemies.Count)
        {
            enemyPool++;
        }
    }

}
