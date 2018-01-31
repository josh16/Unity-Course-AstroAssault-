using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LearnProgrammingAcademy.AstroAssault
{
    [RequireComponent(typeof(Rigidbody2D))] // This will automatically add "rigidbody2d" to Gameobject
    public class FallingBehaviour : MonoBehaviour{


        // == fields ==
        private float speed = 2.0f;
        private Rigidbody2D body;

        // == properties ==
        public float Speed {
            get { return speed;}
            set { speed = value;}
            }


        // == messages ==
        private void Start()
        {
            body = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            body.velocity = Vector2.down * speed; // Ship will be falling down on the 'y' axis
        }


    }
}