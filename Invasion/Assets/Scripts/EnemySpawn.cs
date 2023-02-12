using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public Transform spawnPos;
    public GameObject greenSlime;
    public float spawnCooldown;
    private bool canSpawn = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canSpawn)
        {
            StartCoroutine(spawnEnemy());
        }
    }

    IEnumerator spawnEnemy()
    {
        canSpawn = false;
        GameObject spawnedgreenSlime = Instantiate(greenSlime, spawnPos.position, spawnPos.rotation);
        yield return new WaitForSeconds(spawnCooldown);
        canSpawn = true;
    }

}
