using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace LearnProgrammingAcademy.AstroAssault
{



    public class PointSpawner : MonoBehaviour{

        //Better to have a const name instead of hard coding a string
        private const string SPAWN_METHOD_NAME = "Spawn";

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

        // == messages ==
        private void Start()
        {
            // This will find components with name "spawnPoint"
            spawnPoints = GetComponentsInChildren<SpawnPoint>(); 
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

            var enemy = Instantiate(enemyPrefab); // Instantiate the Enemy

            //Enemy will instantiate at the spawnpoints position
            enemy.transform.position = SpawnPoint.transform.position; 

        }

    }
}