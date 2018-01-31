using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace LearnProgrammingAcademy.AstroAssault{

    public class Dock : MonoBehaviour{

        // == Fields ==
        [SerializeField]
        private float width = 0.8f;

        [SerializeField]
        private float height = 3.0f;


        //== Messages ==
        private void OnDrawGizmos(){
            Gizmos.color = Color.blue;
            Gizmos.DrawWireCube(transform.position,new Vector3(width,height));

        }

    }
}
