using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lizard : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject otherObject = collision.gameObject;
        if(otherObject.GetComponent<Defender>())
        {
            if(otherObject.transform.position.x < transform.position.x && otherObject.transform.position.y == transform.position.y)
                GetComponent<Attacker>().Attack(otherObject);
        }
        /*
        if (otherObject.GetComponent<Attacker>())
        {
            GetComponent<Attacker>().SetMovementSpeed(0);
        }
        */
    }
}
