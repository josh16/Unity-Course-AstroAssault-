using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using LearnProgrammingAcademy.AstroAssault.Config;
using LearnProgrammingAcademy.Generated;
//using LearnProgrammingAcademy.AstroAssault.Utils;

namespace LearnProgrammingAcademy.AstroAssault.Scene{


    public class OptionsSceneController : MonoBehaviour{

        // == onClick Events == 
        public void BackOnClick(){
            SceneManager.UnloadSceneAsync(SceneNames.Options);

        }
    
    }

}