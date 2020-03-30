using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnRate;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator spawn()
    {
        while (true) {
            var spawn=Instantiate(enemyPrefab, transform);
            spawn.transform.position += spawn.transform.right * Random.Range(0, 5);
            yield return new WaitForSeconds(spawnRate);

        }
    }

}
