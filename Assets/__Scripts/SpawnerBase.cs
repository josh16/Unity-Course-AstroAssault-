using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LearnProgrammingAcademy.AstroAssault.Utils;
namespace LearnProgrammingAcademy.AstroAssault
{
    public abstract class SpawnerBase : MonoBehaviour
    {
        // == Constants ==
        private const string SpawnMethodName = "Spawn";

        //== Fields ==
        [SerializeField]
        protected Enemy enemyPrefab;

        [SerializeField]
        protected float spawnInterval = 1.6f; // SpawnInterval time for enemies

        [SerializeField]
        protected float spawnDelay = 0.2f; // Spawn time in between enemies

        [SerializeField]
        protected float enemyStartSpeed = 2.0f; //  starting speed

        [SerializeField]
        private bool SpawnOnStart;

        protected GameObject enemiesParent; //reference to  Parent GameObject

        // == Events ==
        public delegate void EnemySpawnedDelegate();
        public static event EnemySpawnedDelegate EnemySpawnedEvent;

        //= Messages ==
        protected virtual void Start()
        {

            enemiesParent = ParentUtils.FindEnemiesParent();

            if(SpawnOnStart){
                EnableSpawning(); 
            }

        }

        // == Abstract Methods == 
        protected abstract void Spawn();

        // == Public Methods
        public void EnableSpawning()
        {
            InvokeRepeating(SpawnMethodName, spawnDelay, spawnInterval);
        }

        public void DisableSpawning(){
            CancelInvoke(SpawnMethodName);
        }

        // == Private Messages == 


        // == Event Methods ==
        protected void PublishEnemySpawnedEvent() {
            EnemySpawnedEvent?.Invoke(); // Publishing the event
        }


    }
}