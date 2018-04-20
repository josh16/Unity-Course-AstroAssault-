using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using LearnProgrammingAcademy.AstroAssault.Utils;
using LearnProgrammingAcademy.AstroAssault.Config;


namespace LearnProgrammingAcademy.AstroAssault.Scene{

    public class MainMenuSceneController : MonoBehaviour{

        // == messages ==
        private void Start()
        {
            if (!PlayerPrefsController.Instance.IsMute()){
                AudioSource audiosource = GetComponent<AudioSource>();
                audiosource.Play();
            }
        }


        // == OnClick Events == 
        public void PlayOnClick(){
            SceneManager.LoadSceneAsync(SceneNames.LEVEL);
        }

        public void OptionsOnClick(){
            SceneManager.LoadSceneAsync(SceneNames.OPTIONS,LoadSceneMode.Additive);
        }
    }
}