using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LearnProgrammingAcademy.AstroAssault{

    public class MotherShipController : MonoBehaviour{

        // == Fields == 
        private SpawnerBase[] spawners;

        // == Messages == 
        private void Start()
        {
            spawners = FindObjectsOfType<SpawnerBase>();
            Debug.Log($"Spawners found = {spawners.Length}"); 
        }


        // == Private Methods == 
        private void EnableSpawning(){
            foreach( var spawner in spawners){
                spawner.EnableSpawning();
            }
        }

        // == Animator Events ==
        private void AnimatorEnableSpawning(){
            EnableSpawning();
        }


    }
}