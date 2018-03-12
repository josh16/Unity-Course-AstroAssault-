using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LearnProgrammingAcademy.AstroAssault.UI{

    [RequireComponent(typeof(Image))]
    public class LifeIcon : MonoBehaviour{

        // == Fields == 
        private Image image;

        // == Messages ==
        private void Start()
        {
            image = GetComponent<Image>();
        }

        // == public Methods ==
        public void SetImageColor(Color color){
            image.color = color;
        }

    }
}
