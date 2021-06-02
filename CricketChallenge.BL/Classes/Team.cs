namespace CricketChallenge.BL.Classes
{
    using System.Collections.Generic;
    using System.Linq;
    using CricketChallenge.BL.Interfaces;

    /// <summary>
    /// Implementation of the team
    /// </summary>
    internal class Team : ITeam
    {
        private readonly IList<IPlayer> _players;
        private int _playerIndex;

        ///<inheritdoc/>
        public string Name { get; }

        public Team(string name)
        {
            Name = name;
            _players = new List<IPlayer>();
            _playerIndex = 0;
        }

        ///<inheritdoc/>
        public int Score => GetScore();

        ///<inheritdoc/>
        public int BallsPlayed => GetBallsPlayed();

        public int WicketsRemaining => _players.Count == 0 ? 0 : _players.Count - (_playerIndex - 1);
        ///<inheritdoc/>

        ///<inheritdoc/>
        public void AddPlayer(IPlayer newPlayer)
        {
            if (newPlayer == null || newPlayer.MemberOfTeam != null)
            {
                return;
            }

            if (_players.Contains(newPlayer) || _players.Count == 11)
            {
                return;
            }

            _players.Add(newPlayer);
            newPlayer.MemberOfTeam = this;
        }

        ///<inheritdoc/>
        public IList<IPlayer> GetPlayersList()
        {
            return _players;
        }

        ///<inheritdoc/>
        public IPlayer GetNextPlayer()
        {
            if (_playerIndex < _players.Count)
            {
                var nextPlayer = _players[_playerIndex++];
                nextPlayer.Status = BattingStatus.NotOut;
                return nextPlayer;
            }

            return null;
        }

        /// <summary>
        /// Gets team's total score => sum of all players score
        /// </summary>
        /// <returns></returns>
        private int GetScore()
        {
            return _players.Aggregate(0, (current, player) => current + player.RunsScored);
        }

        /// <summary>
        /// Gets total balls played by team => sum of balls played by all players
        /// </summary>
        /// <returns></returns>
        private int GetBallsPlayed()
        {
            return _players.Aggregate(0, (current, player) => current + player.BallsPlayed);
        }
    }
}
