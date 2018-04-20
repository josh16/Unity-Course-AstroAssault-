using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LearnProgrammingAcademy.Utils;

namespace LearnProgrammingAcademy.AstroAssault.Config{


    [RequireComponent(typeof(AudioListener))]
    public class PlayerPrefsController : Singleton<PlayerPrefsController>{

        // == constants ==
        private const string MUTE_KEY = "Mute";

        //Awake Method goes here
        protected override void Awake()
        {
            base.Awake();
            UpdateVolume();
        }

        // == public methods ==
        public void Mute(){
            PlayerPrefs.SetInt(MUTE_KEY,1); // true
            UpdateVolume();
        }

        public void UnMute(){
            PlayerPrefs.SetInt(MUTE_KEY,0); // false
            UpdateVolume();
        }

        public bool IsMute(){
            return PlayerPrefs.GetInt(MUTE_KEY, 0) == 1;
        }

        public void ResetPrefs(){
            UnMute();
        }

        // == private methods ==
        private void UpdateVolume(){
            AudioListener.volume = IsMute() ? 0f : 1f;
        }


    }
}
