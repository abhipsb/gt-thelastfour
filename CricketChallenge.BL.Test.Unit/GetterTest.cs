using System.Reflection;
using CricketChallenge.BL.Interfaces;

namespace CricketChallenge.BL.Test.Unit
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using CricketChallenge.BL.Classes;
    using CricketChallenge.Interface;

    [TestClass]
    public class GetterTest
    {
        private readonly int[] _probability = {5, 30, 25, 10, 15, 1, 9, 5};
        private const string Name = "NameForTest";
        private const int BallsPerOver = 6;

        [TestMethod]
        public void ResultGetter_BallPlayedResultMethodPositive_Test()
        {
            var strikePlayer = Get.NewPlayer(Name, _probability);
            int ballNumber = 10;
            int ballResult = 0;
            string expectedResult = "1.4 " + strikePlayer.Name + " scores " + ballResult + " run";
            string actualResult = ResultGetter.GetBallPlayed(strikePlayer, ballNumber, ballResult, BallsPerOver);
            Assert.AreEqual(expectedResult, actualResult);

            ballNumber = 24;
            ballResult = -1;
            expectedResult = strikePlayer.Name + " Out!";
            actualResult = ResultGetter.GetBallPlayed(strikePlayer, ballNumber, ballResult, BallsPerOver);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void ResultGetter_BallPlayedResultMethodNegative_Test()
        {
            var strikePlayer = Get.NewPlayer(Name, _probability);
            int ballNumber = 0;
            int ballResult = 0;
            string actualResult = ResultGetter.GetBallPlayed(strikePlayer, ballNumber, ballResult, BallsPerOver);
        }

        [TestMethod]
        public void ResultGetter_MatchInfoMethods_Test()
        {
            var team1 = Get.NewTeam("Team1");
            var team2 = Get.NewTeam("Team2");
            var cricketMatch = Get.NewMatch(team1, team2);
            string expectedResult = string.Empty;
            string actualResult = Get.MatchWinnerSummary(cricketMatch);
            Assert.AreEqual(expectedResult, actualResult);

            expectedResult = "1 overs left. 0 runs to win";
            actualResult = Get.FirstHalfSummary(cricketMatch);
            Assert.AreEqual(expectedResult, actualResult);

            expectedResult = "Team1 score: 0";
            actualResult = ResultGetter.GetOverCompleted(cricketMatch, team1);
            Assert.AreEqual(expectedResult, actualResult);

            expectedResult = "1 overs left. 0 runs to win";
            actualResult = ResultGetter.GetOverCompleted(cricketMatch, team1, true);
            Assert.AreEqual(expectedResult, actualResult);

            expectedResult = string.Empty;
            actualResult = Get.BattingSummary(team1);
            Assert.AreEqual(expectedResult, actualResult);

            expectedResult = "Team1 Final Score = 0";
            actualResult = Get.TeamScore(team1);
            Assert.AreEqual(expectedResult, actualResult);

            var player = Get.NewPlayer(Name, _probability);
            team1.AddPlayer(player);
            expectedResult = string.Empty;
            actualResult = ResultGetter.GetBattingSummary(team1);
            Assert.AreEqual(expectedResult, actualResult);

            var strikeBatsman = team1.GetNextPlayer();
            expectedResult = "NameForTest - 0* (0 balls)\n";
            actualResult = ResultGetter.GetBattingSummary(team1);
            Assert.AreEqual(strikeBatsman.Name, Name);
            Assert.AreEqual(expectedResult, actualResult);

            var nextBatsman = team1.GetNextPlayer();
            Assert.IsNull(nextBatsman);
        }

        [TestMethod]
        public void Get_VariousMethods_Test()
        {
            ITeam team1 = Get.NewTeam("Team1");
            ITeam team2 = Get.NewTeam("Team2");

            ICricketMatch match = Get.NewMatch(team1, team2, 40, 24);
            string expectedResult = "4 overs left. 40 runs to win";
            string actualResult = ResultGetter.GetFirstHalfSummary(match);
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
