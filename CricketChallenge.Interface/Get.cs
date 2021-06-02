namespace CricketChallenge.Interface
{
    using CricketChallenge.BL.Classes;
    using CricketChallenge.BL.Interfaces;

    public static class Get
    {
        /// <summary>
        /// Gets a new player
        /// </summary>
        /// <param name="name"></param>
        /// <param name="battingProbability"></param>
        /// <returns></returns>
        public static IPlayer NewPlayer(string name, int[] battingProbability)
        {
            return new Player(name, battingProbability);
        }

        /// <summary>
        /// Gets a new team
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static ITeam NewTeam(string name)
        {
            return new Team(name);
        }

        /// <summary>
        /// Initialize new match where both teams play
        /// </summary>
        /// <param name="teamToBatFirst"></param>
        /// <param name="teamToBatSecond"></param>
        /// <param name="ballsToPlay"></param>
        /// <returns></returns>
        public static ICricketMatch NewMatch(ITeam teamToBatFirst, ITeam teamToBatSecond, int ballsToPlay = 6)
        {
            return new CricketMatch(teamToBatFirst, teamToBatSecond, ballsToPlay);
        }

        /// <summary>
        /// Initialize new match where second team chase target
        /// </summary>
        /// <param name="teamToBatFirst"></param>
        /// <param name="teamToBatSecond"></param>
        /// <param name="customTarget"></param>
        /// <param name="ballsToPlay"></param>
        /// <returns></returns>
        public static ICricketMatch NewMatch(
            ITeam teamToBatFirst, ITeam teamToBatSecond, int customTarget, int ballsToPlay)
        {
            return new CricketMatch(teamToBatFirst, teamToBatSecond, customTarget, ballsToPlay);
        }

        /// <summary>
        /// Gets the summary of winning team
        /// </summary>
        /// <param name="match"></param>
        /// <returns></returns>
        public static string MatchWinnerSummary(ICricketMatch match)
        {
            return ResultGetter.GetMatchWinnerSummary(match);
        }

        /// <summary>
        /// Gets the result summary of batting team
        /// </summary>
        /// <param name="team"></param>
        /// <returns></returns>
        public static string BattingSummary(ITeam team)
        {
            return ResultGetter.GetBattingSummary(team);
        }

        /// <summary>
        /// Gets the summary of first half play
        /// </summary>
        /// <param name="match"></param>
        /// <returns></returns>
        public static string FirstHalfSummary(ICricketMatch match)
        {
            return ResultGetter.GetFirstHalfSummary(match);
        }
        
        /// <summary>
        /// Gets the team score
        /// </summary>
        /// <param name="team"></param>
        /// <returns></returns>
        public static string TeamScore(ITeam team)
        {
            return ResultGetter.GetTeamScore(team);
        }
    }
}