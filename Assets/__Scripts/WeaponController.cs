using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LearnProgrammingAcademy.AstroAssault.Utils;

namespace LearnProgrammingAcademy.AstroAssault{

    public class WeaponController : MonoBehaviour
    {
        // == Constant == 
        private const string ShootMethodName = "Shoot";

        // == Private Fields ==
        [SerializeField]
        private Bullet bulletPrefab;

        [SerializeField]
        private float bulletSpeed = 5f;

        [SerializeField]
        private float firingRate = 0.4f;

        private GameObject bulletsParent; // We use this to spawn the bullets to keep hiearchary clean
        private SoundController soundController;

        // == Audio Fields == 
        [SerializeField]
        private AudioClip shootClip;

        // == Messages ==
        private void Start()
        {
            bulletsParent = ParentUtils.FindBulletsParent();
            soundController = SoundController.FindSoundController();

        }

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                InvokeRepeating(ShootMethodName,0f,firingRate);
            }
        
            if(Input.GetKeyUp(KeyCode.Space))
            {
                CancelInvoke(ShootMethodName);
            }
           
        }

        // == private methods == 
        private void Shoot(){
            soundController?.PlayOneShot(shootClip);
            Bullet bullet = Instantiate(bulletPrefab, bulletsParent.transform);
            bullet.transform.position = transform.position;

            Rigidbody2D bulletBody = bullet.GetComponent<Rigidbody2D>();//Get the attached rigidbody to access physics
            bulletBody.velocity = Vector3.up * bulletSpeed;
        }

    }
}