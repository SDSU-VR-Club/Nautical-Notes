using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RhythmTool;

public class EventManager : MonoBehaviour
{
    public RhythmAnalyzer analyzer;
    public RhythmPlayer player;
    public RhythmEventProvider eventProvider;

    public GameObject enemyPrefab;
    public Transform[] spawnPositions;
    public Transform EnemyHolder;

    void Awake()
    {
        analyzer.Initialized += OnInitialized;
        eventProvider.Register<Beat>(OnBeat);
        Enemy en = enemyPrefab.GetComponent<Enemy>();
        en.speed = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnInitialized(RhythmData rhythmData)
    {
        //Start playing the song.
        player.Play();
    }

    //OnBeat, call spawner.
    private void OnBeat(Beat beat)
    {
        var rand = new System.Random();
        if(rand.Next()%2 == 1)
        {
            var spawn = Instantiate(enemyPrefab, EnemyHolder);
            int plank = UnityEngine.Random.RandomRange(0, 3);
            spawn.transform.position = spawnPositions[plank].position;
            spawn.transform.forward = spawnPositions[plank].forward;
        }        
    }
}
