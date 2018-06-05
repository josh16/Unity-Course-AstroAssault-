using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using LearnProgrammingAcademy.Utils;
using LearnProgrammingAcademy.AstroAssault.Config;
using LearnProgrammingAcademy.Generated;


namespace LearnProgrammingAcademy.AstroAssault.Scene{

    public class LevelSceneController : MonoBehaviour{

        //== Messages ==
        private void Start()
        {
            if(PlayerPrefsController.Instance.IsTutorialOn())
            {
                SceneManager.LoadSceneAsync(SceneNames.Tutorial, LoadSceneMode.Additive);
                GameUtils.Pause();
            }
        }

        //1. Subscribe/Unsubscribe to LostLifeEvent from the player script
        private void OnEnable()
        {
            Player.LostLifeEvent += OnPlayerLostLife;
        }

        private void OnDisable()
        {
            Player.LostLifeEvent -= OnPlayerLostLife;
        }

        // == Events == 
        private void OnPlayerLostLife(int livesleft){

            if(livesleft<=0){
                GameUtils.Pause();
                SceneManager.LoadSceneAsync(SceneNames.GameOver,LoadSceneMode.Additive);
            }

        }

        // == OnClickEvents == 
        public void PauseOnClick(){
            GameUtils.Pause();
            SceneManager.LoadSceneAsync(SceneNames.Pause,LoadSceneMode.Additive);

        }
       
      

    }
}