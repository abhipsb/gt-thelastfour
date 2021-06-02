namespace CricketChallenge.BL.Test.Unit
{
    using System;
    using CricketChallenge.Interface;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using CricketChallenge.BL.Classes;
    using CricketChallenge.BL.Interfaces;

    [TestClass]
    public class BasicTests
    {
        private readonly int[] _probability = { 5, 30, 25, 10, 15, 1, 9, 5 };

        [TestMethod]
        public void Team_AddPlayer_MoreThan11_Test()
        {
            // try to add more than 11 players
            int i = 0;
            var team = Get.NewTeam("Team");
            var player = Get.NewPlayer((i++).ToString(), _probability);
            team.AddPlayer(player);
            player = Get.NewPlayer((i++).ToString(), _probability);
            team.AddPlayer(player);
            player = Get.NewPlayer((i++).ToString(), _probability);
            team.AddPlayer(player);
            player = Get.NewPlayer((i++).ToString(), _probability);
            team.AddPlayer(player);
            player = Get.NewPlayer((i++).ToString(), _probability);
            team.AddPlayer(player);
            player = Get.NewPlayer((i++).ToString(), _probability);
            team.AddPlayer(player);
            player = Get.NewPlayer((i++).ToString(), _probability);
            team.AddPlayer(player);
            player = Get.NewPlayer((i++).ToString(), _probability);
            team.AddPlayer(player);
            player = Get.NewPlayer((i++).ToString(), _probability);
            team.AddPlayer(player);
            player = Get.NewPlayer((i++).ToString(), _probability);
            team.AddPlayer(player);
            player = Get.NewPlayer((i++).ToString(), _probability);
            team.AddPlayer(player);
            player = Get.NewPlayer((i++).ToString(), _probability);
            team.AddPlayer(player);

            Assert.AreEqual(11, team.GetPlayersList().Count);
        }

        [TestMethod]
        public void Team_AddPlayer_Null_Test()
        {
            var team = Get.NewTeam("Team");
            team.AddPlayer(null);
            Assert.AreEqual(0, team.GetPlayersList().Count);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void Player_Create_Invalid_Test()
        {
            var player = Get.NewPlayer("Name", new[] { 1, 2});
        }

        [TestMethod]
        public void Probability_Result_Test()
        {
            IProbabilityGenerator generator = new ProbabilityGenerator(_probability);
            int result = generator.GetNext();
            Assert.IsTrue(result >= -1 && result <= 6);
        }

        [TestMethod]
        public void Player_Test()
        {
            var team1 = Get.NewTeam("Team1");
            var team2 = Get.NewTeam("Team2");
            var player = Get.NewPlayer("Player", _probability);
            Assert.IsNull(player.MemberOfTeam);
            Assert.IsTrue(player.Name.Equals("Player"));
            Assert.IsTrue(player.BallsPlayed == 0);
            Assert.IsTrue(player.RunsScored == 0);
            Assert.IsTrue(player.Status == BattingStatus.DidNotBat);

            team1.AddPlayer(player);
            Assert.IsTrue(player.MemberOfTeam == team1);

            team2.AddPlayer(player);
            Assert.IsTrue(player.MemberOfTeam != team2);
        }

        [TestMethod]
        public void Team_Test()
        {
            var team1 = Get.NewTeam("Team1");
            Assert.IsTrue(team1.BallsPlayed == 0);
            Assert.IsTrue(team1.Score == 0);
            Assert.IsTrue(team1.WicketsRemaining == 0);
            Assert.IsTrue(team1.GetPlayersList().Count == 0);

            var player = Get.NewPlayer("Player", _probability);
            team1.AddPlayer(player);
            Assert.IsTrue(team1.GetPlayersList().Count == 1);
            Assert.IsTrue(team1.GetNextPlayer() == player);
        }
    }
}
