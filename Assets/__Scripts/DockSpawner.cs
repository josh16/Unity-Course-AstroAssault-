using System.Collections;
using System.Collections.Generic;
using LearnProgrammingAcademy.Utils;
using UnityEngine;



namespace LearnProgrammingAcademy.AstroAssault
{
    public class DockSpawner : SpawnerBase
    {
       
        [SerializeField]
        [Header("Waypoints")]
        private Transform[] wayPoints; //Array of all the waypoints
        private IList<Dock> docks;
        private Stack<Dock> docksToSpawn;

       //== Messages == 
        protected override void Start()
        {
            docks = GetComponentsInChildren<Dock>();
            ShuffleDocks();

            base.Start(); // Calls Start Method from SpawnBase class
        }

        // == Private Methods
        private void ShuffleDocks()
        {
            docksToSpawn = ListUtils.CreateShuffledStack(docks);      
        }


        protected override void Spawn()
        {
            //if this is equal to 0, then we shuffle the docks
            if(docksToSpawn.Count == 0)
            {
                ShuffleDocks();
            }

            var dock = docksToSpawn.Pop(); //Remove the element from top of the list

            //If Dock is full, release an enemy(smallship)
            if(dock.IsFull())
            {
                dock.Release();
            }

            var slot = dock.NextFreeSlot(); // This will check the next free slot 

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
