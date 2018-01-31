using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LearnProgrammingAcademy.AstroAssault {

    public class SpawnPoint : MonoBehaviour{


        //Spawner
        //public Transform spawner;


        //Visual Debugging using Gizmos(this is called on every frame)
        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(0, 1, 1);
            Gizmos.DrawSphere(transform.position,0.25f);
        }



    }
}