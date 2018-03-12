using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace LearnProgrammingAcademy.AstroAssault.UI{
    
    public class LifeContainer : MonoBehaviour {

        // == fields == 
        [SerializeField]
        private LifeIcon lifeIconPrefab; // This field will be exposed in the editor

        [SerializeField]
        private Color lostLifeColor = new Color(1,1,1,0.5f); // Alpha will be half transparent 

        private int startingLives;
        private List<LifeIcon> icons = new List<LifeIcon>();


        // == messages == 
        private void Start()
        {
            Player player = FindObjectOfType<Player>();

            //Check to see if player exists
            if(player){
                startingLives = player.Lives;
                CreateIcons();
            }
        }

        private void OnEnable()
        {
            Player.LostLifeEvent += OnPlayerLifeLost;
        }

        private void OnDisable()
        {
            Player.LostLifeEvent -= OnPlayerLifeLost;
        }


        // == Event Methods ==
        private void OnPlayerLifeLost(int lives){
           
           for (int i = 0; i < icons.Count; i++)
                {
                    if (i >= lives)
                    {
                        icons[i].SetImageColor(lostLifeColor);
                    }
                }
        }

        // == private methods ==
        private void CreateIcons(){
            for (int i = 0; i < startingLives; i++){
                LifeIcon lifeIcon = Instantiate(lifeIconPrefab, transform); // transform as the parent
                icons.Add(lifeIcon);
            }

            //reversing list so that last life is at index 0
            // We reverse the list when creating the icons
            icons.Reverse();

        
        }

    }

}
    