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

        // == public methods == 
        public void Pause()
        {
            Time.timeScale = 0f;
            AudioListener.pause = true;
        }

        public void UnPause()
        {
            Time.timeScale = 1f;
            AudioListener.pause = false;
        }


        //== private methods ==
        private void UpdateLabels(){
            // zeroes represent digit count
            scoreText.text = score.ToString("000000");
        }

        // == static methods == 
        public static GameController FindGameController(){
            var gameController = FindObjectOfType<GameController>();

            if(!gameController){
                Debug.LogWarning("GameController not found. Some game features will not work");
            }
        
            return gameController;
        }
    }
}