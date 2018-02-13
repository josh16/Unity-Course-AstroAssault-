using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LearnProgrammingAcademy.Utils
{
    [RequireComponent(typeof(Animator))]
    public class AnimationAutoDestroyer : MonoBehaviour{

        // == fields == 
        [SerializeField]
        private float destroyDelay = 0.1f;

        [SerializeField]
        private Animator animator;


        private void Start()
        {
            animator = GetComponent<Animator>();
            float animationLength = animator.GetCurrentAnimatorStateInfo(0).length;
            float totalTime = animationLength + destroyDelay;

            Destroy(gameObject,totalTime);
        }


    }
}
