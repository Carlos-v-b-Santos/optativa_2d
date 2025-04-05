using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimSystem : MonoBehaviour
{
    [SerializeField] private Transform _playerT;
    [SerializeField] private Transform _enemiesParent;
    private Transform closestEnemyT;

    [SerializeField] private float outOfRange;
    [SerializeField] private float outOfRangeMult;

    // Start is called before the first frame update
    //void Start()
    //{
    //    playerT = this.transform.parent;
    //}

    private void Awake()
    {
        _playerT = GetComponent<Transform>();
        _enemiesParent = GameObject.FindWithTag("EnemiesGroup").GetComponent<Transform>();

        Camera _camera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        float cameraWidth = _camera.orthographicSize * 2f * _camera.aspect;
        outOfRange = cameraWidth * outOfRangeMult;
    }

    public Transform GetClosestEnemyTransform()
    {
        //se estiver vazio de inimigos
        if (_enemiesParent.childCount == 0)
            return null;

        //associa o primeiro da lista como o mais perto
        List<Transform> enemies = ObterFilhosFolhaRecursivo(_enemiesParent);
        closestEnemyT = enemies[0];

        float minDistance = Vector2.Distance(closestEnemyT.position, _playerT.position);

        foreach (Transform enemie in enemies)
        {
            float distanceTemp = Vector2.Distance(enemie.position, _playerT.transform.position);

            if (distanceTemp < minDistance)
            {
                minDistance = distanceTemp;
                closestEnemyT = enemie;
            }
            else if (distanceTemp >= outOfRange)
            {
                enemie.GetComponent<EnemyMovement>().Teleport();
            }
        }

        //for (int i = 1; i < _enemiesParent.childCount; i++)
        //{
        //    Transform temp = _enemiesParent.GetChild(i);

        //calcula a menor distancia
        //    float distanceTemp = Vector2.Distance(temp.position, _playerT.transform.position);

        //    if (distanceTemp < minDistance)
        //    {
        //        minDistance = distanceTemp;
        //        closestEnemyT = temp;
        //   }
        //}

        return closestEnemyT;
    }

    List<Transform> ObterFilhosFolhaRecursivo(Transform pai)
    {
        List<Transform> folhas = new();

        if (pai.childCount == 0)
        {
            folhas.Add(pai);
        }
        else
        {
            foreach (Transform filho in pai)
            {
                folhas.AddRange(ObterFilhosFolhaRecursivo(filho));
            }
        }

        return folhas;
    }
}
