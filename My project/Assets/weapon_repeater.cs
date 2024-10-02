using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon_repeater : MonoBehaviour
{
    [SerializeField] GameObject projetile;
    [SerializeField] float timeReload;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(fireWeapon());
    }

    IEnumerator fireWeapon()
    {
        while (true)
        {
            Instantiate(projetile,this.transform);
            yield return new WaitForSeconds(timeReload);
        }    
    }
}
