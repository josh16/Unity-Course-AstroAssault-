using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LearnProgrammingAcademy.AstroAssault
{
    public class GameController : MonoBehaviour
    {
        //== fields == 
        [SerializeField]
        private Text scoreText;

        private int score = 0;

        // == messages ==
        // We need to subscribe and than unsubcribe the event
        private void OnEnable()
        {
            Enemy.EnemyKilledEvent += OnEnemyKilled;
        }

        private void OnDisable()
        {
            Enemy.EnemyKilledEvent -= OnEnemyKilled;
        }
    
        // == Events ==
        private void OnEnemyKilled(Enemy enemy){
            //throw new System.NotImplementedException();
            score += enemy.ScoreValue;
            UpdateLabels();
        }

        //== private methods ==
        private void UpdateLabels(){
            // zeroes represent digit count
            scoreText.text = score.ToString("000000");
        }


    }
}