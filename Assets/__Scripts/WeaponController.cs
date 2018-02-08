using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LearnProgrammingAcademy.AstroAssault.Utils;

namespace LearnProgrammingAcademy.AstroAssault{

    public class WeaponController : MonoBehaviour
    {
        // == Constant == 
        private const string SHOOT_METHOD_NAME = "Shoot";

        // == Private Fields ==
        [SerializeField]
        private Bullet bulletPrefab;

        [SerializeField]
        private float bulletSpeed = 5f;

        [SerializeField]
        private float firingRate = 0.4f;

        private GameObject bulletsParent; // We use this to spawn the bullets to keep hiearchary clean

        // == Messages ==
        private void Start()
        {
            bulletsParent = GameObject.Find(ParentNames.BULLETS_PARENT_NAME);    

            //Check statement
            if(!bulletsParent)
            {
                bulletsParent = new GameObject(ParentNames.BULLETS_PARENT_NAME);
            }
        }

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                InvokeRepeating(SHOOT_METHOD_NAME,0f,firingRate);
            }
        
            if(Input.GetKeyUp(KeyCode.Space))
            {
                CancelInvoke(SHOOT_METHOD_NAME);
            }
           
        }

        // == private methods == 
        private void Shoot(){
            Bullet bullet = Instantiate(bulletPrefab, bulletsParent.transform);
            bullet.transform.position = transform.position;

            Rigidbody2D bulletBody = bullet.GetComponent<Rigidbody2D>();//Get the attached rigidbody to access physics
            bulletBody.velocity = Vector3.up * bulletSpeed;
        }

    }
}