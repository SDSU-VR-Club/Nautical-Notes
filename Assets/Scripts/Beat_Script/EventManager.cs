﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RhythmTool;
//using Mathf;

public class EventManager : MonoBehaviour
{
    public RhythmAnalyzer analyzer;
    public RhythmPlayer player;
    public RhythmEventProvider eventProvider;

    public GameObject enemyPrefab;
    public Transform[] spawnPositions;
    public Transform EnemyHolder;

    public Transform Zone;

    private Enemy en;

    float currentBPM = 0.0f;

    void Awake()
    {
        analyzer.Initialized += OnInitialized;
        eventProvider.Register<Beat>(OnBeat);
        en = enemyPrefab.GetComponent<Enemy>();
        
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
        // If statement for if the BPM changes
        if ((currentBPM - beat.bpm) >= 1 || (currentBPM - beat.bpm) <= -1 )
        {
            en.speed = ChangeSpeed(beat);
        }

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

        currentBPM = beat.bpm;
    }

    private float ChangeSpeed(Beat beat)
    {
        // Duration of beat: t = (1/BPM) * 60 (resulting in seconds)
        // Speed: S = d/t, d = (Zspawn) - (Zzone) / duration of beat
        float beatduration = (1 / beat.bpm) * 60;
        float speed = (Mathf.Abs((spawnPositions[0].transform.position.z) - (Zone.transform.position.z))) / beatduration;
        return speed;
    }
}
