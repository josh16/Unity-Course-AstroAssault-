using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LearnProgrammingAcademy.AstroAssault.Utils;

namespace LearnProgrammingAcademy.AstroAssault
{
    public class Enemy : MonoBehaviour
    {
        // == Fields ==
        [SerializeField]
        private GameObject hitExplosionPrefab;

        [SerializeField]
        private GameObject crashExplosionPrefab;

        private GameObject explosionsParent;


        // == Messages ==

        private void Start()
        {
            explosionsParent = GameObject.Find(ParentNames.EXPLOSIONS_PARENT_NAME);

            //Check
            if(!explosionsParent){
                explosionsParent = new GameObject(ParentNames.EXPLOSIONS_PARENT_NAME);
            }
        }

        private void OnTriggerEnter2D(Collider2D collider)
        {
            var bullet = collider.GetComponent<Bullet>();
            var ground = collider.GetComponent<Ground>();
            var player = collider.GetComponent<Player>();

            //If colliders with "Bullet" which will be the Bullet script attached to a GameObject..
            if(bullet)
            {
                SpawnExplosion(hitExplosionPrefab);
                //Destroy the bullet Game Object
                Destroy(bullet.gameObject);
                Debug.Log("Bullet Destroyed!");

                Destroy(gameObject); // Destroy the enemy gameobject
                Debug.Log("Enemy Destroyed!");
            } 
                else if(ground){
                SpawnExplosion(crashExplosionPrefab);
                Destroy(gameObject); // Destroy enemy gameobject
                Debug.Log("Enemy hit ground!");
            } 
              else if(player)
            {
                player.Die(); // call player Die Method
                SpawnExplosion(hitExplosionPrefab);
                Destroy(gameObject); // destroy enemy gameObject(the object this component is attached too)
            }
        }

        //== Private methods == 
        private void SpawnExplosion(GameObject explosionPrefab)
        {
            GameObject explosionGameObject = Instantiate(explosionPrefab, explosionsParent.transform);
            explosionGameObject.transform.position = transform.position;
        }

    }
}
