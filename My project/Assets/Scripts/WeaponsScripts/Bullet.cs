using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Bullet : MonoBehaviour
{
    [SerializeField] WeaponSO weaponData;

    public float CurrentDamage { get; private set; }
    public float CurrentPierce { get; private set; }

    Rigidbody2D rb2D;
    // Start is called before the first frame update
    void Awake()
    {
        CurrentDamage = weaponData.Damage;
        CurrentPierce = weaponData.Pierce;

        rb2D = GetComponent<Rigidbody2D>();
        rb2D.AddRelativeForce(Vector2.up * weaponData.Speed);
        StartCoroutine(ProjetileTimer());
    }

    IEnumerator ProjetileTimer()
    {
        yield return new WaitForSeconds(weaponData.Duration);
        DestroyProjetile();
    }

    public void DecreasePierce()
    {
        CurrentPierce--;

        if (CurrentPierce <= 0)
        {
            DestroyProjetile() ;
        }
    }

    public void DestroyProjetile()
    {
        Destroy(this.gameObject);
    }
}
