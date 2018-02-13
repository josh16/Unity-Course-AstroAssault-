using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LearnProgrammingAcademy.AstroAssault
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class BulletDestroyer : MonoBehaviour{

        // == Messages ==
        private void OnTriggerEnter2D(Collider2D collider){
            Bullet bullet = collider.GetComponent<Bullet>();

            if(bullet)
            {
                Destroy(bullet.gameObject);

            }
        }

    }
}
