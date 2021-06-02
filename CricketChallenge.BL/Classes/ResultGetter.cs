namespace CricketChallenge.BL.Classes
{
    using CricketChallenge.BL.Interfaces;
    using System;

    /// <summary>
    /// Class responsible for providing different results in the form of formatted messages
    /// </summary>
    internal static class ResultGetter
    {
        public static string GetBallPlayed(IPlayer strikePlayer, int ballNumber, int ballResult, int ballsPerOver)
        {
            if (ballNumber < 1)
            {
                throw new ArgumentException("ballNumber can not be 0");
            }

            string message;
            if (ballResult == -1)
            {
                message = strikePlayer.Name + " Out!";
            }
            else
            {
                message = ballNumber/ballsPerOver + "." + ballNumber%ballsPerOver + " " + strikePlayer.Name +
                          " scores " + ballResult + " run";
            }

            return message;
        }

        public static string GetOverCompleted(ICricketMatch match, ITeam team, bool isChasingTarget = false)
        {
            if (isChasingTarget)
            {
                return match.RemainingBallsToPlay / match.BallsPerOver + " overs left. " + (match.RunsToWin - team.Score) + " runs to win";
            }

            return team.Name + " score: " + team.Score;
        }

        public static string GetMatchWinnerSummary(ICricketMatch match)
        {
            string message = string.Empty;
            var winner = match.GetWinner();
            if (winner.Status != MatchStatus.Completed)
            {
                return message;
            }

            if (winner.IsTieBreak)
            {
                return "Tie Break\n";
            }

            if (match.SecondBattingTeam == winner.Team)
            {
                message = match.SecondBattingTeam.Name + " Won by " + match.SecondBattingTeam.WicketsRemaining + " wicket and " + match.RemainingBallsToPlay +
                          " balls remaining";
            }
            else
            {
                message = match.FirstBattingTeam.Name + " Won by " + (match.RunsToWin - 1 - match.SecondBattingTeam.Score) + " runs and " +
                          match.RemainingBallsToPlay + " balls remaining";
            }

            return message;
        }

        public static string GetBattingSummary(ITeam team)
        {
            string message = string.Empty;
            foreach (var player in team.GetPlayersList())
            {
                if (player.Status == BattingStatus.DidNotBat)
                {
                    continue;
                }

                message = message + player.Name + " - " + player.RunsScored +
                          (player.Status == BattingStatus.Out ? string.Empty : "*") + " (" + player.BallsPlayed +
                          " balls)\n";
            }

            return message;
        }

        public static string GetFirstHalfSummary(ICricketMatch match)
        {
            return match.RemainingBallsToPlay / 6 + " overs left. " + match.RunsToWin + " runs to win";
        }

        public static string GetTeamScore(ITeam team)
        {
            return team.Name + " Final Score = " + team.Score;
        }
    }
}
