namespace CricketChallenge.BL.Interfaces
{
    using System.Collections.Generic;

    /// <summary>
    /// Interface for the team
    /// </summary>
    public interface ITeam
    {
        /// <summary>
        /// Team's Name
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Total runs scored by the team
        /// </summary>
        int Score { get; }

        /// <summary>
        /// Total balls played by the team
        /// </summary>
        int BallsPlayed { get; }

        /// <summary>
        /// Remaining wickets during match
        /// </summary>
        int WicketsRemaining { get; }

        /// <summary>
        /// Add a player in the team
        /// </summary>
        /// <param name="newPlayer"></param>
        void AddPlayer(IPlayer newPlayer);

        /// <summary>
        /// Gets the next player during match
        /// </summary>
        /// <returns></returns>
        IPlayer GetNextPlayer();

        /// <summary>
        /// Gets the list of players
        /// </summary>
        /// <returns></returns>
        IList<IPlayer> GetPlayersList();
    }
}
