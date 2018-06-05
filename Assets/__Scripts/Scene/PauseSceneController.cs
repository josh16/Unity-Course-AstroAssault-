using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using LearnProgrammingAcademy.AstroAssault.Utils;
using LearnProgrammingAcademy.Utils;
using LearnProgrammingAcademy.Generated;

namespace LearnProgrammingAcademy.AstroAssault.Scene{

    public class PauseSceneController : MonoBehaviour{
       
        // == onClick events ==
        public void ResumeOnClick(){
            GameUtils.UnPause();
            SceneManager.UnloadSceneAsync(SceneNames.Pause);
        }
    
        public void PlayAgainOnClick(){ // Load Level again, restart it
            GameUtils.UnPause();
            SceneManager.LoadSceneAsync(SceneNames.Level);
        }

        public void ExitToMenuOnClick(){  
            GameUtils.UnPause();
            SceneManager.LoadSceneAsync(SceneNames.MainMenu);
        }
    }
} 

