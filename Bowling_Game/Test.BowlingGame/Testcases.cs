using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using RollAndGetScore;

namespace Test.BowlingGame
{
    [TestFixture]
    public class Testcases
    {
        private Game _game;

        [SetUp]
        public void Initialize()
        {
            _game = new Game();
        }

        public void TraverseRoll(int frame, int pins)
        {
            for (int i = 0; i < frame; i++)
                _game.Roll(pins);
        }

        [Test]
        public void AllGutterRollScenario()
        {
            TraverseRoll(21, 0);
            Assert.AreEqual(0, _game.GetScore());
        }

        [Test]
        public void SimpleRollScenario()
        {
            TraverseRoll(20, 1);
            Assert.AreEqual(20, _game.GetScore());
        }

        [Test]
        public void AllStrikesScenario()
        {
            TraverseRoll(12, 10);
            Assert.AreEqual(300, _game.GetScore());
        }

        [Test]
        public void AllSpareScenario()
        {
            TraverseRoll(21, 5);
            Assert.AreEqual(150, _game.GetScore());
        }
    }
}
