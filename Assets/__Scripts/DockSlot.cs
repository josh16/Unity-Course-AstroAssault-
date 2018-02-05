using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace LearnProgrammingAcademy.AstroAssault
{
    public class DockSlot : MonoBehaviour
    {

        //==messages==
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position,0.25f); 
        }


        // == Public Methods
       public bool IsEmpty()
        {
            //This will check if the transform object is empty
            return transform.childCount == 0; 
        }


    }
}
