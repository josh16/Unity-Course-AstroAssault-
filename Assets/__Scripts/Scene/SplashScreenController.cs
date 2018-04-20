using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using LearnProgrammingAcademy.AstroAssault.Utils;

namespace LearnProgrammingAcademy.AstroAssault.Scene{
    public class SplashScreenController : MonoBehaviour{
        //1.Display image
        //2.Display it for one second

        // == fields ==
        [SerializeField]
        [Range(0,6)]
        private float Duration = 1f;

        private void Start(){
            StartCoroutine(LoadMainMenuCourotine());
        }

        // == private methods ==
        private IEnumerator LoadMainMenuCourotine(){
            yield return new WaitForSeconds(Duration);
            SceneManager.LoadSceneAsync(SceneNames.MAIN_MENU);
        }


    }
}
