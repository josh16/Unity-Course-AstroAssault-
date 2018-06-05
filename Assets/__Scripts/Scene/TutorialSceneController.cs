using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using LearnProgrammingAcademy.Utils;
using LearnProgrammingAcademy.AstroAssault.Config;
using LearnProgrammingAcademy.Generated;


namespace LearnProgrammingAcademy.AstroAssault.Scene{
 
    public class TutorialSceneController : MonoBehaviour{

        // == Fields ==
        [SerializeField]
        private ScrollRect scrollRect;

        private float normalizedDelta;

        //== Messages ==
        private void Start(){
            // calculate normalized delta (0-1) depending on child count
            // needs -1 since first page is already display, so we have 3 pages to change
            normalizedDelta = 1.0f / (scrollRect.content.childCount - 1);
        }

        // == OnClickEvents == 
        public void CloseOnClick(){
            SceneManager.UnloadSceneAsync(SceneNames.Tutorial);
            GameUtils.UnPause();
            PlayerPrefsController.Instance.TutorialOff();
        }

        public void NextOnClick(){
            float newNormalizedPosition = scrollRect.horizontalNormalizedPosition + normalizedDelta;
            scrollRect.horizontalNormalizedPosition = Mathf.Clamp01(newNormalizedPosition);
        }
    
        public void PreviousOnClick(){
            float newNormalizedPosition = scrollRect.horizontalNormalizedPosition - normalizedDelta;
            scrollRect.horizontalNormalizedPosition = Mathf.Clamp01(newNormalizedPosition);
        }
    }
}