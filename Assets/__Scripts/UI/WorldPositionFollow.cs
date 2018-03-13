using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace LearnProgrammingAcademy.AstroAssault.UI
{
    public class WorldPositionFollow : MonoBehaviour
    {
        // == Fields ==
        [SerializeField]
        private Transform positionToFollow;


        // == Messages == 
        private void LateUpdate(){
            if(positionToFollow){
                //ScreenPosition will get the camera's position, and the transform will follow it
                Vector3 screenPosition = Camera.main.WorldToScreenPoint(positionToFollow.position);
                transform.position = screenPosition;
            }
        }



    }
}