using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace LearnProgrammingAcademy.AstroAssault
{



    public class PointSpawner : MonoBehaviour{

        //Better to have a const name instead of hard coding a string
        private const string SPAWN_METHOD_NAME = "Spawn";
        private const string ENEMIES_PARENT_NAME = "Enemies";

        // == fields == 

        //Declared as enemy so that only gameObjects that have enemy script will be called
        [SerializeField]
        private Enemy enemyPrefab; 

        [SerializeField]
        private float spawnInterval = 1.6f; // Time between the spawns

        [SerializeField]
        private float spawnDelay = 0.2f; // have a delay in spawn so too much enemies isn't spawning at once

        [SerializeField]
        private float enemyStartSpeed = 2.0f; // Enemy's speed


        private IList<SpawnPoint> spawnPoints; // declared as interface so it will be converted to List
        private GameObject enemiesParent;


        // == messages ==
        private void Start()
        {
            // This will find components with name "spawnPoint"
            spawnPoints = GetComponentsInChildren<SpawnPoint>();
            enemiesParent = GameObject.Find(ENEMIES_PARENT_NAME);

            //Check to see if enemiesParent is null and if so, it will create a new object
            //Always good to have a check to avoid errors and such
            if(!enemiesParent)
            {
                Debug.Log($"{ENEMIES_PARENT_NAME} object not found, creating new object!");
                enemiesParent = new GameObject(ENEMIES_PARENT_NAME); 
            }


            SpawnRepeating();
        }

        // == Private Methods ==
        private void SpawnRepeating()
        {
            InvokeRepeating(SPAWN_METHOD_NAME,spawnDelay,spawnInterval);
        }

      
        //Spawn Function
        private void Spawn(){

            // Spawn will be random and it will only spawn with the amount of spawners
            // that are available
            var randomIndex = Random.Range(0, spawnPoints.Count);
            var SpawnPoint = spawnPoints[randomIndex]; // The spawnpoints will be 

            var enemy = Instantiate(enemyPrefab,enemiesParent.transform); // Instantiate the Enemy
                                                         // Parent of enemy is now "enemies parent"

            //Enemy will instantiate at the spawnpoints position
            enemy.transform.position = SpawnPoint.transform.position; 

        }

    }
}