using System.Collections;
using System.Collections.Generic;
using LearnProgrammingAcademy.Utils;
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

        private IList<Dock> docks;
        private Stack<Dock> docksToSpawn;

        private GameObject enemiesParent; //reference to Enemies Parent GameObject


        //== Messages == 
        private void Start(){

            docks = GetComponentsInChildren<Dock>();

            enemiesParent = GameObject.Find(ENEMIES_PARENT_NAME); // looks for object with name

            //What happens if it doesn't exist? well we create a check

            //Check to see if parent is null and if so, object will be created
            if(!enemiesParent){
                Debug.Log($"{ENEMIES_PARENT_NAME}object not found, creating a new one");
                enemiesParent = new GameObject(ENEMIES_PARENT_NAME); 
            }

            ShuffleDocks();
            SpawnRepeating(); // SpawnRepeating function will get called here
        }

        // == Private Methods
        private void ShuffleDocks()
        {
            docksToSpawn = ListUtils.CreateShuffledStack(docks);      
        }


        //This function will invokeRepeating calling the Method name in string
        // 
        private void SpawnRepeating()
        {
            InvokeRepeating(SPAWN_METHOD_NAME,spawnDelay,spawnInterval); 
        }

        private void Spawn()
        {
            //if this is equal to 0, then we shuffle the docks
            if(docksToSpawn.Count == 0)
            {
                ShuffleDocks();
            }

            var dock = docksToSpawn.Pop(); //Remove the element from top of the list
            var slot = dock.NextFreeSlot(); // This will check the next free slot 

            //if slot is equal to null...
            if(!slot) 
            {
                return; // We want to return because the slot is full, 
                       // the remaining code will not execute
            }

            //Create the enemy and spawn the enemy at the Slot
            var enemy = Instantiate(enemyPrefab,slot.transform);
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

            //Add dock entry and slot waypoints
            var dockEntry = dock.GetEntryPoint();
            follower.Addwaypoint(dockEntry);
            follower.Addwaypoint(slot.transform.position);


        }

    }
}
