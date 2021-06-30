using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] bool spawn = true;
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 5f;
    [SerializeField] float firstSpawnDelay = 10f;
    [SerializeField] Attacker[] attackerPrefabs;
    bool firstSpawn = true;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        while(spawn)
        {
            float spawnDelay = firstSpawnDelay;
            if (!firstSpawn)
                spawnDelay = Random.Range(minSpawnDelay, maxSpawnDelay);
            else
                firstSpawn = false;

            yield return new WaitForSeconds(spawnDelay);
            if(spawn)
                Spawn();
        }
    }

    void Spawn()
    {
        int i = Random.Range(0, attackerPrefabs.Length);
        SpawnAttacker(attackerPrefabs[i]);
    }

    public void StopSpawn()
    {
        spawn = false;
    }

    void SpawnAttacker(Attacker attacker)
    {
        Attacker newAttacker = Instantiate(attacker, transform.position, transform.rotation) as Attacker;
        newAttacker.transform.parent = transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
