using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LearnProgrammingAcademy.AstroAssault{

    [RequireComponent(typeof(Animator))]
    public class MotherShipController : MonoBehaviour{

        // == Constants == 
        private const string NextWaveTriggerName = "NextWave";

        // == Fields == 
        [SerializeField]
        private AudioClip movingClip;

        [SerializeField]
        private AudioClip spawnClip;

        private SpawnerBase[] spawners;
        private Animator animator;
        private SoundController soundController;
        private GameController gameController;

        // == Messages == 
        private void Start()
        {
            spawners = FindObjectsOfType<SpawnerBase>();
            animator = GetComponent<Animator>();
            soundController = SoundController.FindSoundController();
            soundController?.Play(movingClip);
            gameController = GameController.FindGameController();

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
            gameController.DecrementRemainingCount();
        
            if(gameController.HasRemainingEnemies()){
                DisableSpawning();
                animator.SetTrigger(NextWaveTriggerName);
                soundController?.Play(movingClip);
            }

        }


        // == Private Methods == 
      private void EnableSpawning(){
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
            gameController.NextWave();
            EnableSpawning();
            soundController?.Play(spawnClip);
        }

    }
}