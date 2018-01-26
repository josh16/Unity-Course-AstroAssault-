using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LearnProgrammingAcademy.AstroAssault {

    public class PlayerController : MonoBehaviour
    {
        #region == Constants ==
        private const string HORIZONTAL = "Horizontal";
        private const string VERTICAL = "Vertical";
        #endregion

        #region == fields ==
        [SerializeField]
        private float speed = 15;

        private Rigidbody2D body;

        #endregion

        #region == Messages ==
        private void Start()
        {
            body = GetComponent<Rigidbody2D>();

        }

        //This function is called every fixed frame
        private void FixedUpdate()
        {
            float horizontalMovement = Input.GetAxis(HORIZONTAL);

            body.velocity = new Vector2(horizontalMovement * speed, 0f);


        }

        #endregion
    }



















}
