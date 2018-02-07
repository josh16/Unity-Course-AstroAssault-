using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LearnProgrammingAcademy.AstroAssault.Utils;
namespace LearnProgrammingAcademy.AstroAssault
{
    public abstract class SpawnerBase : MonoBehaviour
    {
        // == Constants ==
        private const string SPAWN_METHOD_NAME = "Spawn";

        //== Fields ==
        [SerializeField]
        protected Enemy enemyPrefab;

        [SerializeField]
        protected float spawnInterval = 1.6f; // SpawnInterval time for enemies

        [SerializeField]
        protected float spawnDelay = 0.2f; // Spawn time in between enemies

        [SerializeField]
        protected float enemyStartSpeed = 2.0f; //  starting speed

        protected GameObject enemiesParent; //reference to  Parent GameObject

        //= MESSAGES ==
        protected virtual void Start()
        {

            enemiesParent = GameObject.Find(ParentNames.ENEMIES_PARENT_NAME); // looks for object with name

            //What happens if it doesn't exist? well we create a check

            //Check to see if parent is null and if so, object will be created
            if (!enemiesParent)
            {
                Debug.Log($"{ParentNames.ENEMIES_PARENT_NAME}object not found, creating a new one");
                enemiesParent = new GameObject(ParentNames.ENEMIES_PARENT_NAME);
            }
           
            SpawnRepeating(); // SpawnRepeating function will get called here
        }

        // == ABSTRACT METHODS == 
        protected abstract void Spawn();

        // == PRIVATE MESSAGES == 
        private void SpawnRepeating()
        {
            InvokeRepeating(SPAWN_METHOD_NAME, spawnDelay, spawnInterval);
        }



    }
}