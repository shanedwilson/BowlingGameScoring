using Xunit;

namespace BowlingGameScoring.Tests
{
    public class tests_for_various_bowling_score_scenarios
    {
        BowlingGame game = new BowlingGame();

        [Fact]
        public void test_gutter_game()
        {
            RollMany(20, 0);

            Assert.Equal(0, game.Score());
        }

        [Fact]
        public void test_all_ones()
        {
            RollMany(20, 1);

            Assert.Equal(20, game.Score());
        }

        [Fact]
        public void test_one_spare()
        {
            RollSpare();
            game.Try(3);
            RollMany(17, 0);

            Assert.Equal(16, game.Score());
        }

        [Fact]
        public void test_one_strike()
        {
            RollStrike();
            game.Try(3);
            game.Try(4);
            RollMany(16, 0);

            Assert.Equal(24, game.Score());
        }

        [Fact]
        public void test_perfect_game()
        {
            RollMany(12, 10);

            Assert.Equal(300, game.Score());
        }

        private void RollSpare()
        {
            game.Try(5);
            game.Try(5);
        }

        private void RollMany(int rolls, int pins)
        {
            for (int i = 0; i < rolls; i++)
            {
                game.Try(pins);
            }
        }

        private void RollStrike()
        {
            game.Try(10);
        }
    }
}
