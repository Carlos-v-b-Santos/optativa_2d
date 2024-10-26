using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimSystem : MonoBehaviour
{
    [SerializeField] private Transform _playerT;
    [SerializeField] private Transform _enemiesParent;
    private Transform closestEnemyT;

    // Start is called before the first frame update
    //void Start()
    //{
    //    playerT = this.transform.parent;
    //}

    public Transform GetClosestEnemyTransform()
    {
        //se estiver vazio de inimigos
        if (_enemiesParent.childCount == 0)
            return null;

        //associa o primeiro da lista como o mais perto
        closestEnemyT = _enemiesParent.GetChild(0);
        float minDistance = Vector2.Distance(closestEnemyT.position, _playerT.position);
        

        for (int i = 1; i < _enemiesParent.childCount; i++)
        {
            Transform temp = _enemiesParent.GetChild(i);

            //calcula a menor distancia
            float distanceTemp = Vector2.Distance(temp.position, _playerT.transform.position);
           
            if (distanceTemp < minDistance)
            {
                minDistance = distanceTemp;
                closestEnemyT = temp;
            }
        }

        return closestEnemyT;
    }
}
