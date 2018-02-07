using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LearnProgrammingAcademy.Utils; // using the name space for utils class
using LearnProgrammingAcademy.AstroAssault.Utils;


namespace LearnProgrammingAcademy.AstroAssault
{

    public class PointSpawner : SpawnerBase{

        private IList<SpawnPoint> spawnPoints; // declared as interface so it will be converted to List
        private Stack<SpawnPoint> pointsToSpawn; // Stack declared for points to spawn
       
        // == messages ==
        protected override void Start()
        {
            spawnPoints = GetComponentsInChildren<SpawnPoint>();
            ShuffleSpawnPoints();
            base.Start();
        }

        // == Private Methods ==
        private void ShuffleSpawnPoints()
        {
            pointsToSpawn = ListUtils.CreateShuffledStack(spawnPoints);
        }

        //Spawn Function
        protected override void Spawn(){
            
            //Check to see if pointsToSpawn is 0
            if(pointsToSpawn.Count == 0)
            {
                ShuffleSpawnPoints();
            }

            var spawnPoint = pointsToSpawn.Pop();//Removes element from stack and returns to top

            var enemy = Instantiate(enemyPrefab,enemiesParent.transform); // Instantiate the Enemy
                                                         // Parent of enemy is now "enemies parent"
            //Enemy will instantiate at the spawnpoints position
            enemy.transform.position = spawnPoint.transform.position;

            //Falling behaviour will be based off the enemies Start Speed
            var fallingBehaviour = enemy.GetComponent<FallingBehaviour>(); // enemy will getComponent
            fallingBehaviour.Speed = enemyStartSpeed;

        }

    }
}