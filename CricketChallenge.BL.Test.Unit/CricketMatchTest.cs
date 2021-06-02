using CricketChallenge.BL.Interfaces;

namespace CricketChallenge.BL.Test.Unit
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using CricketChallenge.Interface;

    [TestClass]
    public class CricketMatchTest
    {
        private readonly int[] _probability = { 5, 30, 25, 10, 15, 1, 9, 5 };
        private const int BallsPerOver = 6;
        private string _message;

        private void OutputHandler(string message)
        {
            _message = message;
        }

        [TestMethod]
        public void CricketMatch_Test()
        {
            var team1 = Get.NewTeam("Team1");
            var player = Get.NewPlayer(team1.Name + "_Player1", _probability);
            team1.AddPlayer(player);
            player = Get.NewPlayer(team1.Name + "_Player2", _probability);
            team1.AddPlayer(player);
            
            // Test for adding same player again
            team1.AddPlayer(player);
            Assert.AreEqual(team1.GetPlayersList().Count, 2);

            var team2 = Get.NewTeam("Team2");
            player = Get.NewPlayer(team2.Name + "_Player1", _probability);
            team2.AddPlayer(player);
            player = Get.NewPlayer(team2.Name + "_Player2", _probability);
            team2.AddPlayer(player);

            ICricketMatch match = Get.NewMatch(team1, team2);
            match.SetResultOutputHandler(OutputHandler);
            match.PlayFirstHalf();
            Assert.AreNotEqual(string.Empty, Get.TeamScore(team1));
            Assert.AreNotEqual(string.Empty, Get.BattingSummary(team1));
            Assert.AreNotEqual(string.Empty, Get.FirstHalfSummary(match));

            match.PlaySecondHalf();
            Assert.AreNotEqual(string.Empty, Get.TeamScore(team2));
            Assert.AreNotEqual(string.Empty, Get.BattingSummary(team2));
            WinnerInfo matchWinner = match.GetWinner();
            Assert.IsNotNull(matchWinner);
            Assert.AreNotEqual(string.Empty, Get.MatchWinnerSummary(match));

            Assert.AreNotEqual(team1.BallsPlayed, 0);
            Assert.AreNotEqual(team2.BallsPlayed, 0);

            Assert.IsNotNull(team1.WicketsRemaining);
            Assert.IsNotNull(team2.WicketsRemaining);
        }
    }
}
