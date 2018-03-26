using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using LearnProgrammingAcademy.AstroAssault.Utils;


namespace LearnProgrammingAcademy.AstroAssault.Scene{

    public class MainMenuSceneController : MonoBehaviour{

        // == OnClick Events == 
        public void PlayOnClick(){
            SceneManager.LoadSceneAsync(SceneNames.LEVEL);
        }

    }
}