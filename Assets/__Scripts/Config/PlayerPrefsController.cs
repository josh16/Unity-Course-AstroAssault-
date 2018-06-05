using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LearnProgrammingAcademy.Utils;

namespace LearnProgrammingAcademy.AstroAssault.Config{


    [RequireComponent(typeof(AudioListener))]
    public class PlayerPrefsController : Singleton<PlayerPrefsController>{

        // == constants ==
        private const string MuteKey = "Mute";
        private const string TutorialKey = "Tutorial";

        //Awake Method goes here
        protected override void Awake()
        {
            base.Awake();
            UpdateVolume();
        }

        // == public methods ==
        public void Mute(){
            PlayerPrefs.SetInt(MuteKey,1); // true
            UpdateVolume();
        }

        public void UnMute(){
            PlayerPrefs.SetInt(MuteKey,0); // false
            UpdateVolume();
        }

        public bool IsMute(){
            return PlayerPrefs.GetInt(MuteKey, 0) == 1;
        }

        public void TutotialOn(){
            PlayerPrefs.SetInt(TutorialKey,1); // true
        }

        public void TutorialOff(){
            PlayerPrefs.SetInt(TutorialKey,0); // false
        }

        // Check..
        public bool IsTutorialOn(){
            return PlayerPrefs.GetInt(TutorialKey, 1) == 1;
        }

        public void ResetPrefs(){
            UnMute();
            TutotialOn();
            UpdateVolume();
        }

        // == private methods ==
        private void UpdateVolume(){
            AudioListener.volume = IsMute() ? 0f : 1f;
        }


    }
}
