using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LearnProgrammingAcademy.AstroAssault.Utils;

namespace LearnProgrammingAcademy.AstroAssault
{
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(PolygonCollider2D))]
    [RequireComponent(typeof(PlayerController))]
    [RequireComponent(typeof(WeaponController))]
    public class Player : MonoBehaviour
    {
        // == Fields ==
        [SerializeField]
        private int lives = 4;

        [SerializeField]
        private GameObject explosionPrefab;

        //Reference 4 components here on the player
        // We want to deactivate these 4 components once the player dies
        private SpriteRenderer spriteRenderer;
        private PolygonCollider2D polygonCollider;
        private PlayerController playerController;
        private WeaponController weaponController;

        private Vector3 startPoisiton;
        private GameObject explosionsParent;

        // == Events == 
        public delegate void LostLifeDelegate(int livesLeft);
        public static event LostLifeDelegate LostLifeEvent;


        // == Properties == 
        public int Lives
        {
            get { return lives; }
        }

        // == Messages ==
        private void Start()
        {
            //Need to get the components at the start
            spriteRenderer = GetComponent<SpriteRenderer>();
            polygonCollider = GetComponent<PolygonCollider2D>();
            playerController = GetComponent<PlayerController>();
            weaponController = GetComponent<WeaponController>();


            //Remember the start position
            startPoisiton = new Vector3(transform.position.x, transform.position.y, transform.position.z);

            explosionsParent = GameObject.Find(ParentNames.EXPLOSIONS_PARENT_NAME);

            //Check
            if (!explosionsParent)
                explosionsParent = new GameObject(ParentNames.EXPLOSIONS_PARENT_NAME);
            
        }

        // == public methods ==
        public void Die(){
            StartCoroutine(DieCoroutine());//Call the coroutine
        }
         
        // == Event Methods ==
        private void PublishLostLifeEvent(){
            LostLifeEvent?.Invoke(lives);
        }


        //== Private Methods == 
        private IEnumerator DieCoroutine() {
            Debug.Log("DieCoroutine");
            //hide player(e.g disable components)
            DisableComponents();

            //spawn explosion
            GameObject explosionGameObject = Instantiate(explosionPrefab, explosionsParent.transform);
            explosionGameObject.transform.position = transform.position;

            lives--; //live = lives -1

            PublishLostLifeEvent();

            yield return new WaitForSeconds(1.5f);

            //Respawn condition
            if(lives>0)
            {
                Respawn();
            }
        }

        private void Respawn(){
            transform.position = startPoisiton;
            EnableCompnents();
        }

        private void EnableCompnents() { 
            SetComponentsEnabled(true);
        }
        private void DisableComponents(){ 
            SetComponentsEnabled(false);
        }
        private void SetComponentsEnabled(bool enabled){
            spriteRenderer.enabled = enabled;
            polygonCollider.enabled = enabled;
            playerController.enabled = enabled;
            weaponController.enabled = enabled;

        }

    }
}