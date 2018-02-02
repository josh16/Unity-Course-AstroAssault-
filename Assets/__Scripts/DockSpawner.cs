using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace LearnProgrammingAcademy.AstroAssault
{
    public class DockSpawner : MonoBehaviour
    {

        // == Constants ==
        //It's better to use a const for a string name instead of hard coding name. This can
        // be used once again later in the code
        private const string SPAWN_METHOD_NAME = "Spawn"; 
        private const string ENEMIES_PARENT_NAME = "Enemies"; 

        //== Fields ==
        [SerializeField]
        private Enemy enemyPrefab;

        [SerializeField]
        private float spawnInterval = 1.6f; // SpawnInterval time for enemies

        [SerializeField]
        private float spawnDelay = 0.2f; // Spawn time in between enemies

        [SerializeField]
        private float enemyStartSpeed = 2.0f; // Enemies starting speed

        [SerializeField]
        [Header("Waypoints")]
        private Transform[] wayPoints; // Array of all the waypoints

        private GameObject enemiesParent; //reference to Enemies Parent GameObject


        //== Messages == 
        private void Start(){

            enemiesParent = GameObject.Find(ENEMIES_PARENT_NAME); // looks for object with name

            //What happens if it doesn't exist? well we create a check

            //Check to see if parent is null and if so, object will be created
            if(!enemiesParent){
                Debug.Log($"{ENEMIES_PARENT_NAME}object not found, creating a new one");
                enemiesParent = new GameObject(ENEMIES_PARENT_NAME); 
            }
        
            SpawnRepeating(); // SpawnRepeating function will get called here
        }


        //This function will invokeRepeating calling the Method name in string
        // 
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

            //Get the Waypoint follower script
            var follower = enemy.GetComponent<WayPointFollower>();
            follower.Speed = enemyStartSpeed;


            //The enemy will
            foreach(var waypoint in wayPoints)
            {
                follower.Addwaypoint(waypoint.position);
            }

        }



    }
}
