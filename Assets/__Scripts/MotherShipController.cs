using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LearnProgrammingAcademy.AstroAssault{

    [RequireComponent(typeof(Animator))]
    public class MotherShipController : MonoBehaviour{

        // == Constants == 
        private const string NEXT_WAVE_TRIGGER_NAME = "NextWave";

        // == Fields == 
        private int enemyCountPerWave = 20;

        private int remainingEnemyCount;
        private int waveNumber; // initialize to 0 by default
        private SpawnerBase[] spawners;


        private Animator animator;

        // == Messages == 
        private void Start()
        {
            spawners = FindObjectsOfType<SpawnerBase>();
            animator = GetComponent<Animator>();
            Debug.Log($"Spawners found = {spawners.Length}"); 
        }

        private void OnEnable()
        {
            SpawnerBase.EnemySpawnedEvent += OnEnemySpawned; // Subscribing to event
        }

        private void OnDisable()
        {
            SpawnerBase.EnemySpawnedEvent -= OnEnemySpawned; // Unsubscribing to event
        }

        // == Event Methods
        private void OnEnemySpawned(){
            remainingEnemyCount--; // Reduce enemyCount
            Debug.Log($"remainingEnemyCount= {remainingEnemyCount}");
        
            if(remainingEnemyCount == 0){
                DisableSpawning();
                animator.SetTrigger(NEXT_WAVE_TRIGGER_NAME);
            }

        }


        // == Private Methods == 
        private void EnableSpawning(){
            waveNumber++; // wave number goes up by 1, wave starts
            remainingEnemyCount = enemyCountPerWave; // 'X' amount of enemies when the wave starts
            Debug.Log($"WaveNumber:{waveNumber}");

            foreach( var spawner in spawners){
                spawner.EnableSpawning();
            }
        }

        private void DisableSpawning(){
            foreach(var spawner in spawners){
                spawner.DisableSpawning();
            }

        }


        // == Animator Events ==
        private void AnimatorEnableSpawning(){
            EnableSpawning();
        }


    }
}