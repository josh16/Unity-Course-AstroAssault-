using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using LearnProgrammingAcademy.Utils;
using LearnProgrammingAcademy.Generated;

namespace LearnProgrammingAcademy.AstroAssault.Scene{

    public class GameOverSceneController : MonoBehaviour{
        

        // == Fields ==
        [SerializeField]
        private Text waveNumberText;

        [SerializeField]
        private Text scoreText;

        private GameController gameController;

      
        // == Messages ==
        private void Start()
        {
            gameController = GameController.FindGameController();   
        
            if(gameController)
            {
                scoreText.text = gameController.GetScoreFormatted();
                waveNumberText.text = gameController.GetWaveNumberFormatted();
            }
        }

        // == OnClickEvents ==
        public void PlayAgainOnClick()
        {
            GameUtils.UnPause();
            SceneManager.LoadSceneAsync(SceneNames.Level);
        }
    
        public void ExitToMenuOnClick()
        {
            GameUtils.UnPause();
            SceneManager.LoadSceneAsync(SceneNames.MainMenu);
        }
    }
}
