using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LearnProgrammingAcademy.Utils{

    //This class will only contain static vars,methods, and etc
    public static class GameUtils{

        public static void Pause()
        {
            SetPause(true);
        }

        public static void UnPause()
        {
            SetPause(false);
        }

        public static void SetPause(bool pause){
            Time.timeScale = pause ? 0f: 1f; // ternary operator
            AudioListener.pause = pause;
        }

    }
}