namespace CricketChallenge.BL.Interfaces
{
    using System;

    /// <summary>
    /// Enum for Match Status
    /// </summary>
    public enum MatchStatus
    {
        /// <summary>
        /// Match in progress
        /// </summary>
        InProgress,
        /// <summary>
        /// Match completed
        /// </summary>
        Completed
    }

    /// <summary>
    /// Information about match winner or tie-break
    /// </summary>
    public struct WinnerInfo
    {
        public ITeam Team;
        public bool IsTieBreak;
        public MatchStatus Status;
    }

    /// <summary>
    /// Cricket Match Interface
    /// </summary>
    public interface ICricketMatch
    {
        /// <summary>
        /// Team which is batting first
        /// </summary>
        ITeam FirstBattingTeam { get; }

        /// <summary>
        /// Team which is batting second
        /// </summary>
        ITeam SecondBattingTeam { get; }

        /// <summary>
        /// Number of balls in an Over
        /// </summary>
        int BallsPerOver { get; }

        /// <summary>
        /// Balls remaining to play for the second team
        /// </summary>
        int RemainingBallsToPlay { get; }

        /// <summary>
        /// Runs required to by second team
        /// </summary>
        int RunsToWin { get; }

        /// <summary>
        /// Current status of match i.e. In-progress or Completed
        /// </summary>
        MatchStatus Status { get; }

        /// <summary>
        /// Player on strike
        /// </summary>
        IPlayer StrikeBatsman { get; }

        /// <summary>
        /// Player on non-strike
        /// </summary>
        IPlayer NonStrikeBatsman { get; }

        /// <summary>
        /// Gets the match winner
        /// </summary>
        /// <returns></returns>
        WinnerInfo GetWinner();

        /// <summary>
        /// Play the first half of match [i.e. First team does the batting]
        /// </summary>
        void PlayFirstHalf();
        
        /// <summary>
        /// Play the second half of match [i.e. Second team does the batting]
        /// </summary>
        void PlaySecondHalf();

        /// <summary>
        /// Sets the output handler for displaying result of each ball played
        /// </summary>
        /// <param name="handler"></param>
        void SetResultOutputHandler(Action<string> handler);
    }
}
