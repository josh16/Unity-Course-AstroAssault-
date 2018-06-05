using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LearnProgrammingAcademy.AstroAssault
{
    public class GameController : MonoBehaviour
    {
        //== Fields == 
        [SerializeField]
        private int enemyCountPerWave = 200;

        [SerializeField]
        private Text scoreText;

        [SerializeField]
        private Text waveNumberText;

        [SerializeField]
        private Text remainingEnemyCountText;

        private int score = 0;
        private int remainingEnemyCount;
        private int waveNumber; // initialize to 0 by default

        // == Messages ==
        private void Start()
        {
            remainingEnemyCount = enemyCountPerWave;
            UpdateText();
        }

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
            UpdateText();
        }

        public void DecrementRemainingCount()
        {
            remainingEnemyCount--;
            UpdateText();
        }

        public bool HasRemainingEnemies()
        {
            return remainingEnemyCount <= 0;

        }

        public void NextWave()
        {
            waveNumber++; // wave number goes up by 1, wave starts
            remainingEnemyCount = enemyCountPerWave; // 'X' amount of enemies when the wave starts
            UpdateText();

        }


        // == Public methods == 
        public string GetScoreFormatted()
        {
            return score.ToString("000000");
        }

        public string GetWaveNumberFormatted()
        {
            return waveNumber.ToString("000");
        }

        //== private methods ==
        private void UpdateText(){
            // zeroes represent digit count
            scoreText.text = GetScoreFormatted();
            waveNumberText.text = GetWaveNumberFormatted();
            remainingEnemyCountText.text = remainingEnemyCount.ToString("000");
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