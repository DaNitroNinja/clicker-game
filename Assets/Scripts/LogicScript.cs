using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

namespace Rishi
{
    public class LogicScript : MonoBehaviour
    {
        /* TODO:
         * Have a score go up by one when a user clicks the button - DONE
         * Make a random chance for the score to go to zero - DONE
         * Make the square change colour every time the button is clicked
         * Be able to hide and show empty parent gameObjects with the minigames under them.
         * Randomise the chance for the score to go to zero between a 1-15% chance
         * 
         */
        public int score = 0;
        public int highscore;
        public TextMeshProUGUI ScoreText;
        public TextMeshProUGUI HighScoreText;
        public Image ColourSprite;

        private void Awake()
        {
            highscore = PlayerPrefs.GetInt("HighScore", 0);
        }

        private void Update()
        {
            HighScoreCheck();

        }
        public void OnMainButtonClick()
        {
            RandomChance(1, 51, 2);
            ChangeColour(1,100);
            HighScoreCheck();
            
        }

        private void RandomChance(int LowerBound, int HigherBound,int OddsNumber)
        {
            // Randomiser Code
            System.Random random = new System.Random();
            int Chance = random.Next(LowerBound,HigherBound);
            if (Chance == OddsNumber)
            {
                score = 0;
                ScoreText.text = score.ToString();
            }
            else
            {
                score++;
                ScoreText.text = score.ToString();
            }
        }

        private void ChangeColour(int LowerBound, int HigherBound)
        {
            // Randomiser Code
            System.Random random = new System.Random();
            float red = random.Next(LowerBound, HigherBound);
            float blue = random.Next(LowerBound, HigherBound);
            float green = random.Next(LowerBound, HigherBound);

            red = red / 100;
            blue = blue / 100;
            green = green / 100;

            /*
             *  Debug.Log(red);
             *  Debug.Log(blue);
             *  Debug.Log(green); 
             */

            // Sets The Image's Colour To The Randomiser Numbers
            ColourSprite.color = new Color(red, blue, green, 1);

        }
        private void HighScoreCheck()
        {
            if (score < highscore)
            {
                highscore = score;
                PlayerPrefs.SetInt("HighScore", highscore);

                HighScoreText.text = highscore.ToString();

                Debug.Log("Score is higher than High Score");

            }
            else
            {
                Debug.Log("Score is Under High Score");
            }
        }

    }
}

