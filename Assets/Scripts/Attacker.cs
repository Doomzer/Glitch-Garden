using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] int damage = 50;
    [Range(0f, 5f)] [SerializeField] float walkSpeed = 1f;
    GameObject[] targets;
    GameObject currentTarget;
    float currentWalkSpeed;

    private void Awake()
    {
        currentWalkSpeed = walkSpeed;
        FindObjectOfType<LevelController>().AttackerSpawned();
    }

    private void OnDestroy()
    {
        if(FindObjectOfType<LevelController>())
            if(!FindObjectOfType<LevelController>().IsGameOver())
                FindObjectOfType<LevelController>().AttackerDestroyed();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * currentWalkSpeed * Time.deltaTime);
    }

    public void SetMovementSpeed(float speed)
    {
        currentWalkSpeed = speed;
    }

    public void Attack(GameObject target)
    {
        currentTarget = target;
        SetMovementSpeed(0);
        GetComponent<Animator>().SetBool("IsAttacking", true);
    }

    void StopAttack()
    {
        GetComponent<Animator>().SetBool("IsAttacking", false);
        SetMovementSpeed(walkSpeed);
    }

    public void StrikeTarget()
    {
        if (!currentTarget)
        {
            StopAttack();
            return;
        }

        Health health = currentTarget.GetComponent<Health>();
        if (health)
        {
            health.ProcessHit(damage);
            if (health.GetHealth() <= 0)
                StopAttack();
        }
    }
}
