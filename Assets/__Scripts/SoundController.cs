using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace LearnProgrammingAcademy.AstroAssault
{
    [RequireComponent(typeof(AudioSource))]
    public class SoundController : MonoBehaviour
    {
        // == fields ==
        private AudioSource audiosource;

        // == messages ==
        private void Awake()
        {
            audiosource = GetComponent<AudioSource>();
        }

        // == Public methods ==
        public void PlayOneShot(AudioClip clip){
            if(clip){
                audiosource.PlayOneShot(clip);
            }
        }

        public void Play(AudioClip clip){
            if(clip){
                audiosource.clip = clip;
                audiosource.loop = true;
                audiosource.Play();
            }
        }

        // == Static Methods == 
        public static SoundController FindSoundController(){

            var soundController = FindObjectOfType<SoundController>();

            if (!soundController)
            {
                Debug.LogWarning("SoundController not found. Sounds will not be played");
            }
            return soundController;
        }

    }
}