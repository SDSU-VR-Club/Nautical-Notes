using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnRate;
    public Transform[] spawnPositions;
    public Transform EnemyHolder;
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(spawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator spawn()
    {
        while (true) {
            var spawn=Instantiate(enemyPrefab, EnemyHolder);
            int plank = Random.RandomRange(0, 3);
            spawn.transform.position = spawnPositions[plank].position;
            spawn.transform.forward = spawnPositions[plank].forward;
            yield return new WaitForSeconds(spawnRate);

        }
    }

}
