using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using LearnProgrammingAcademy.AstroAssault.Utils;



namespace LearnProgrammingAcademy.AstroAssault{

    public class Dock : MonoBehaviour
    {
       // == Fields ==
        [SerializeField] // Expose to editor
        private float width = 0.8f;

        [SerializeField]
        private float height = 3.0f;

        [SerializeField]
        [Range(1, 15)]// This range will represent how many enemies that will be in 1 slot itself
        private int slotCount = 5;

        [SerializeField]
        private float slotSpacing = 0.6f; // distance between the slots

        [SerializeField]
        private DockSlot slotPrefab; // Reference to only gameobjects that have the DockSlot script attached


        [SerializeField]
        private DockSlot[] slots; // DockSlots Array 
        private GameObject enemiesParent;

        //== MESSAGES ==
        private void Start()
        {
            //Intialize the Array for Docks 
            slots = new DockSlot[slotCount];
            enemiesParent = ParentUtils.FindEnemiesParent();
            CreateSlots();
        }

        //Update Method
        private void Update()
        {
            RepositionEnemies();
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireCube(transform.position, new Vector3(width, height));

        }

        //== PUBLIC METHODS ==
        //This Method will release all of enemies IF the stack is full
        public void Release()
        {
            var firstSlot = slots.First();
            Debug.Log($"Releasing enemy at slot = {firstSlot.name}");
            var enemyAtFirstSlot = firstSlot.GetComponentInChildren<Enemy>();

            //Reparent to enemies parent
            enemyAtFirstSlot.transform.parent = enemiesParent.transform;

            //Enable falling 
            var fallingBehaviour = enemyAtFirstSlot.GetComponent<FallingBehaviour>();
            fallingBehaviour.enabled = true; // Setting fallingBehaviour script to true

            RepositionEnemies();
        }

        //Checks to see if the slots are full
        public bool IsFull()
        {
            return NextFreeSlot() == null;
        }

        //Checks to see the next free slot
        // If slot is empty, return slot otherwise return null
        public DockSlot NextFreeSlot()
        {
            ///returns something
            foreach(var slot in slots)
            {
                if(slot.IsEmpty())
                {
                    return slot;
                }
            }

            return null;
        }

        //This will be an EntryPoint for the Small ship
        public Vector3 GetEntryPoint()
        {
            int diff = slotCount /2 + 1; //+1 since we want to be above the dock
            float positionY = transform.position.y + slotSpacing * diff;
            return new Vector3(transform.position.x, positionY);
        }


        //== PRIVATE METHODS == 
        private void RepositionEnemies()
        {
            //starting from 1 since first slot is empty(released or dead enemy
            for (int i = 1; i < slots.Length; i++)
            {
                var previousSlot = slots[i - 1];
                var currentSlot = slots[i];

                if (previousSlot.IsEmpty() && !currentSlot.IsEmpty())
                {
                    var enemyAtCurrentSlot = currentSlot.GetComponentInChildren<WayPointFollower>();

                    //Reparent to previous slot
                    enemyAtCurrentSlot.transform.parent = previousSlot.transform;

                    //Add Waypoint
                    enemyAtCurrentSlot.Addwaypoint(previousSlot.transform.position);

                }

            }
        }
        private void CreateSlots()
        {
            //Calculate starting position
            int halfCount = slotCount / 2 ;
            float startY = transform.position.y - slotSpacing * halfCount;

           
            //If there is even number of slots, start lower by half of slot spacing
            if(slotCount % 2 ==0)
            {
                startY += slotSpacing / 2f;
            }

            //Instantiate dock slots
            for (int i = 0; i < slotCount; i++)
            { 
                DockSlot slot = Instantiate(slotPrefab,transform); // all slots will be children of dock object
                float yPosition = startY + i * slotSpacing;

                //
                slot.transform.position = new Vector3(transform.position.x, yPosition);
                slots[i] = slot;// Place the instantiate slot inside the array[i]

            }
        }

    }
}
