namespace CricketChallenge.BL.Interfaces
{
    /// <summary>
    /// Batting status of the player
    /// </summary>
    public enum BattingStatus
    {
        Out,
        NotOut,
        DidNotBat
    }

    /// <summary>
    /// Interface for the player [Batsman]
    /// </summary>
    public interface IPlayer
    {
        /// <summary>
        /// Player Name
        /// </summary>
        string Name { get; }
        
        /// <summary>
        /// Team of which the player is member
        /// </summary>
        ITeam MemberOfTeam { get; set; }

        /// <summary>
        /// Status of player's batting
        /// </summary>
        BattingStatus Status { get; set; }

        /// <summary>
        /// Total runs scored by the player
        /// </summary>
        int RunsScored { get; }

        /// <summary>
        /// Total balls played by the player
        /// </summary>
        int BallsPlayed { get; }

        /// <summary>
        /// Method to play the ball
        /// </summary>
        int PlayTheBall();
    }
}
