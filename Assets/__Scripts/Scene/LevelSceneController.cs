using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using LearnProgrammingAcademy.AstroAssault.Utils;

namespace LearnProgrammingAcademy.AstroAssault.Scene{

    public class LevelSceneController : MonoBehaviour{

        // == fields ==
        private GameController gameController;

        // == messages == 
        private void Start(){
            gameController = GameController.FindGameController();
        }

        // == OnClickEvents == 
        public void PauseOnClick(){
            gameController.Pause();
            SceneManager.LoadSceneAsync(SceneNames.PAUSE,LoadSceneMode.Additive);

        }
       
    }
}