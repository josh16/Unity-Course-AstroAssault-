using System.Collections;
using System.Collections.Generic;
using UnityEngine;



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


        //== Messages ==
        private void Start()
        {
            //Intialize the Array for Docks 
            slots = new DockSlot[slotCount];
            CreateSlots();
        }


        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireCube(transform.position, new Vector3(width, height));

        }

        //== public void Methods ==

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
            //otherwise..
            return null;
        }

        //This will be an EntryPoint for the Small ship
        public Vector3 GetEntryPoint()
        {
            int diff = slotCount /2 + 1; //+1 since we want to be above the dock
            float positionY = transform.position.y + slotSpacing * diff;
            return new Vector3(transform.position.x, positionY);
        }


        //== Private Methods == 
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
