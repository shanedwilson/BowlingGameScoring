using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingGameScoring
{
    public class BowlingGame
    {
        private int score;
        private int[] rolls = new int[21];
        private int currentRoll;


        public void Try(int pins)
        {
            rolls[currentRoll++] = pins;
            score += pins;
        }

        public int Score()
        {
            int score = 0;
            int roll = 0;

            for (int frame = 0; frame < 10; frame++)
            {
                if (isStrike(roll))
                {
                    score += 10 + StrikeBonus(roll);
                    roll++;
                }
                else if (isSpare(roll))
                {
                    score += 10 + SpareBonus(roll);
                    roll += 2;
                }
                else
                {
                    score += SumOfFrames(roll);
                    roll += 2;
                }
            }
            return score;
        }

        private bool isSpare(int roll)
        {
            return rolls[roll] + rolls[roll + 1] == 10;
        }

        private bool isStrike(int roll)
        {
            return rolls[roll] == 10;
        }

        private int SumOfFrames(int roll)
        {
            return rolls[roll] + rolls[roll + 1];
        }

        private int SpareBonus(int roll)
        {
            return rolls[roll + 2];
        }

        private int StrikeBonus(int roll)
        {
            return rolls[roll + 1] + rolls[roll + 2];
        }
    }
}
