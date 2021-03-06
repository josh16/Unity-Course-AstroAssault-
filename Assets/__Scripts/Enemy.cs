﻿using System.Collections;
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

        [SerializeField]
        private int scoreValue = 10;

        private GameObject explosionsParent;
        private SoundController soundController;

        // == Audio Fields == 
        [SerializeField]
        private AudioClip spawnClip;

        [SerializeField]
        private AudioClip hitClip;

        [SerializeField]
        private AudioClip crashClip;


        // == Properties == 
        public int ScoreValue{
            get { return scoreValue; } // read only

        }

        // == Events ==
        public delegate void EnemyKilled(Enemy enemy); // Delegate
        public static event EnemyKilled EnemyKilledEvent; // Event


        // == Messages ==
        private void Start()
        {
            explosionsParent = ParentUtils.FindExplosionsParent();

            //Find SoundController
            soundController = SoundController.FindSoundController();

            PlayClip(spawnClip);
        }

        private void OnTriggerEnter2D(Collider2D collider)
        {
            var bullet = collider.GetComponent<Bullet>();
            var ground = collider.GetComponent<Ground>();
            var player = collider.GetComponent<Player>();

            //If colliders with "Bullet" which will be the Bullet script attached to a GameObject..
            if(bullet)
            {
                PlayClip(hitClip);
                PublishEnemyKilledEvent(); // call this event
                SpawnExplosion(hitExplosionPrefab);
                //Destroy the bullet Game Object
                Destroy(bullet.gameObject);
                Debug.Log("Bullet Destroyed!");

                Destroy(gameObject); // Destroy the enemy gameobject
                Debug.Log("Enemy Destroyed!");
            } 
                else if(ground){
                PlayClip(crashClip);
                SpawnExplosion(crashExplosionPrefab);
                Destroy(gameObject); // Destroy enemy gameobject
                Debug.Log("Enemy hit ground!");
            } 
              else if(player)
            {
                PlayClip(crashClip);
                player.Die(); // call player Die Method
                SpawnExplosion(hitExplosionPrefab);
                Destroy(gameObject); // destroy enemy gameObject(the object this component is attached too)
            }
        }

        //== Private methods == 
        private void PlayClip(AudioClip clip){
            /*
            if(soundController){
                soundController.PlayOneShot(clip);
                }
             }
            */
        
            // A faster way..
            soundController?.PlayOneShot(clip);
        }

        private void SpawnExplosion(GameObject explosionPrefab)
        {
            GameObject explosionGameObject = Instantiate(explosionPrefab, explosionsParent.transform);
            explosionGameObject.transform.position = transform.position;
        }

        //Event Method
        private void PublishEnemyKilledEvent()
        {
            EnemyKilledEvent?.Invoke(this);

            // (this) keyword refers to the current instant
            // the (?) is the  null check operator
        }
    }
}
