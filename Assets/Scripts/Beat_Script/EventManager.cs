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
        var spawn = Instantiate(enemyPrefab, EnemyHolder);
        int plank = Random.RandomRange(0, 3);
        spawn.transform.position = spawnPositions[plank].position;
        spawn.transform.forward = spawnPositions[plank].forward;
    }
}
