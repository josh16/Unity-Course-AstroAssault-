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

        [SerializeField]
        private float xmin = -7.2f;

        [SerializeField]
        private float xmax = 7.2f;

        [SerializeField]  
        private float padding = 0.9f; // Padding for ship's body to not stay half out

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

            //restrict player movement (Player position) between xmin and xmax value
            float newX = Mathf.Clamp(body.position.x, xmin + padding, xmax - padding);

            body.position = new Vector2(newX, body.position.y);

           


        }

        #endregion
    }



















}
