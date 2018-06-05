using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using LearnProgrammingAcademy.AstroAssault.Config;
using LearnProgrammingAcademy.Generated;


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
            SceneManager.LoadSceneAsync(SceneNames.Level);
        }

        public void OptionsOnClick(){
            SceneManager.LoadSceneAsync(SceneNames.Options,LoadSceneMode.Additive);
        }
    
        public void TutorialOnClick(){
            SceneManager.LoadSceneAsync(SceneNames.Tutorial, LoadSceneMode.Additive);
        }
    }
}