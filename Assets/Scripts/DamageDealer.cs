using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] int damage = 100;
    [SerializeField] bool oneAttack = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var health = collision.gameObject.GetComponent<Health>();
        var attacker = collision.gameObject.GetComponent<Attacker>();

        if (!health || !attacker) { return; }

        health.ProcessHit(damage);
        Hit();
    }

    public void Hit()
    {
        if(oneAttack)
            Destroy(gameObject);
    }
}
