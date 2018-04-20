using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using LearnProgrammingAcademy.AstroAssault.Utils;

namespace LearnProgrammingAcademy.AstroAssault.Scene{

    public class PauseSceneController : MonoBehaviour{
       
        // == fields ==
        private GameController gameController;

        // == messages == 
        private void Start()
        {
            gameController = GameController.FindGameController();
        }

        // == onClick events ==
        public void ResumeOnClick(){
            gameController.UnPause();
            SceneManager.UnloadSceneAsync(SceneNames.PAUSE);
        }
    
        public void PlayAgainOnClick(){ // Load Level again, restart it
            gameController.UnPause();
            SceneManager.LoadSceneAsync(SceneNames.LEVEL);
        }

        public void ExitToMenuOnClick(){  
            gameController.UnPause();
            SceneManager.LoadSceneAsync(SceneNames.MAIN_MENU);
        }
    }
} 

