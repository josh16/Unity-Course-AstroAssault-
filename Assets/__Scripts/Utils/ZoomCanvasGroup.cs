using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LearnProgrammingAcademy.Utils{

    // Purpose of this?

    [RequireComponent(typeof(CanvasGroup))]
    [RequireComponent(typeof(RectTransform))]
    [DisallowMultipleComponent]
    public class ZoomCanvasGroup : MonoBehaviour{

        // == Fields ==
        [SerializeField]
        private float duration = 0.5f;

        [SerializeField]
        [Range(0,1)]
        private float fromScale = 0.0f;

        [SerializeField]
        [Range(0,1)]
        private float toScale = 1.0f;

        private RectTransform rectTransform;
        private CanvasGroup canvasGroup;


        // == Private Messages ==
        private void Start(){
            rectTransform = GetComponent<RectTransform>();
            canvasGroup = GetComponent<CanvasGroup>();

            //rectTransforms scale is being set to 1 * fromScale(0) so it will be zero
            rectTransform.localScale = Vector2.one * fromScale;

            StartCoroutine(ZoomRoutine());

        }


        // == Private Methods ==
        private IEnumerator ZoomRoutine(){
            float elapsedTime = 0f;
            canvasGroup.interactable = false; // Turn off any UI buttons and etc

            while(elapsedTime <= duration)
            {
                elapsedTime += Time.unscaledDeltaTime;
                float time = elapsedTime / duration;
                Vector2 toScaleVector = Vector2.one * toScale;
                rectTransform.localScale = Vector2.Lerp(rectTransform.localScale,toScaleVector ,time);
                yield return null;
            }

            bool interactable = toScale == 1; // Buttons will become interactable once zoom is complete
            canvasGroup.interactable = interactable; // we set the interactable to be true here
        }

    }
}
