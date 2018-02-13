using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LearnProgrammingAcademy.AstroAssault
{
    public class Enemy : MonoBehaviour
    {
        // == Messages ==
        private void OnTriggerEnter2D(Collider2D collider)
        {
            var bullet = collider.GetComponent<Bullet>();
            var ground = collider.GetComponent<Ground>();

            //If colliders with "Bullet" which will be the Bullet script attached to a GameObject..
            if(bullet)
            {
                //Destroy the bullet Game Object
                Destroy(bullet.gameObject);
                Debug.Log("Bullet Destroyed!");

                Destroy(gameObject); // Destroy the enemy gameobject
                Debug.Log("Enemy Destroyed!");
            } 
                else if(ground){
                Destroy(gameObject); // Destroy enemy gameobject
                Debug.Log("Enemy hit ground!");
             }
        }

    }
}
