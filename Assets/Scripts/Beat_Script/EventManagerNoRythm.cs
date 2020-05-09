using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using Mathf;

public class EventManagerNoRythm : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPositions;
    public Transform EnemyHolder;

    public Transform Zone;

    private Enemy en;

    public float beatInterval;
    public AudioSource song; 
    float start;
    float timeSinceLastBeat;
    void Awake()
    {
        en = enemyPrefab.GetComponent<Enemy>();
        start=Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastBeat+=Time.deltaTime;
        if(timeSinceLastBeat>beatInterval){
            timeSinceLastBeat=0;
            OnBeat();
        }
        if(song.clip.length<Time.time-start){
            victory();
        }
    }
    void victory(){
        SceneManager.LoadScene("victory");
    }
    //OnBeat, call spawner.
    private void OnBeat()
    {
        var rand = new System.Random();
        if(rand.Next()%2 == 0)
        {
            var spawn = Instantiate(enemyPrefab, EnemyHolder);
            int plank = UnityEngine.Random.RandomRange(0, 3);
            spawn.transform.position = spawnPositions[plank].position;
            spawn.transform.forward = spawnPositions[plank].forward;
        }
        else if(rand.Next()%2 == 1)
        {
            var spawn = Instantiate(enemyPrefab, EnemyHolder);
            int plank = UnityEngine.Random.RandomRange(0, 3);
            var spawn2 = Instantiate(enemyPrefab, EnemyHolder);
            int plank2 = UnityEngine.Random.RandomRange(0, 3);
            spawn.transform.position = spawnPositions[plank].position;
            spawn.transform.forward = spawnPositions[plank].forward;
            spawn2.transform.position = spawnPositions[plank2].position;
            spawn2.transform.forward = spawnPositions[plank2].forward;
        }

    }
}
