using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace LearnProgrammingAcademy.AstroAssault
{
    public class DockSpawner : MonoBehaviour
    {

        // == Constants ==
        private const string SPAWN_METHOD_NAME = "Spawn";
        private const string ENEMIES_PARENT_NAME = "Enemies"; 

        //== Fields ==
        [SerializeField]
        private Enemy enemyPrefab;

        [SerializeField]
        private float spawnInterval = 1.6f;

        [SerializeField]
        private float spawnDelay = 0.2f;

        [SerializeField]
        private float enemyStartSpeed = 2.0f;

        private GameObject enemiesParent; //reference to GameObject

        //== Messages == 
        private void Start(){

            enemiesParent = GameObject.Find(ENEMIES_PARENT_NAME); // looks for object with name

            //Check to see if parent is null and if so, object will be created
            if(!enemiesParent){
                Debug.Log($"{ENEMIES_PARENT_NAME}object not found, creating a new one");
            }
        
            SpawnRepeating(); // SpawnRepeating function will get called here
        }

        private void SpawnRepeating()
        {
            InvokeRepeating(SPAWN_METHOD_NAME,spawnDelay,spawnInterval);
        }

        private void Spawn()
        {
            //Create the enemy and instantiate the enemy
            var enemy = Instantiate(enemyPrefab,enemiesParent.transform);
            enemy.transform.position = transform.position;

            //Use enemy object to reference fallingBehaviour script and 
            // we can now access the speed property and set that as enemystartSpeed;
            var fallingBehaviour = enemy.GetComponent<FallingBehaviour>();
            fallingBehaviour.Speed = enemyStartSpeed;

        }



    }
}
