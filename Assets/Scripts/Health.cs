using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 100;
    [SerializeField] GameObject deathVFX;
    [SerializeField] float explosionDuration = 1f;

    public int GetHealth()
    {
        return health;
    }

    public void ProcessHit(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
        TriggerDeathVFX();
        //AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position, deathSoundVolume);
    }

    private void TriggerDeathVFX()
    {
        if (deathVFX)
        {
            var explosion = Instantiate(deathVFX, transform.position, transform.rotation);
            Destroy(explosion, explosionDuration);
        }
    }
}
