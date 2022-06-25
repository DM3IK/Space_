using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 50;

    void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();

        if (damageDealer != null)
        {
            TakeDamage(damageDealer.GetDamage());   //ha subito danni
            damageDealer.Hit();                     //ha colpito qualcosa
        }
    }

    /*take damage*/
    void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            //senza vita
            Destroy(gameObject);
        }
    }
}
