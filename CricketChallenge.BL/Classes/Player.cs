namespace CricketChallenge.BL.Classes
{
    using CricketChallenge.BL.Interfaces;

    /// <summary>
    /// Implementation of Player [A Batsman]
    /// </summary>
    internal class Player : IPlayer
    {
        private readonly IProbabilityGenerator _resultGenerator;
        
        ///<inheritdoc/>
        public string Name { get; }

        ///<inheritdoc/>
        public ITeam MemberOfTeam { get; set; }

        ///<inheritdoc/>
        public int RunsScored { get; private set; }

        ///<inheritdoc/>
        public int BallsPlayed { get; private set; }

        ///<inheritdoc/>
        public BattingStatus Status { get; set; }

        /// <summary>
        /// Initialize a new player
        /// </summary>
        /// <param name="name">Name of the player</param>
        /// <param name="probability">Probability of scoring</param>
        public Player(string name, int[] probability)
        {
            Name = name;
            Status = BattingStatus.DidNotBat;
            RunsScored = 0;
            _resultGenerator = new ProbabilityGenerator(probability);
        }

        ///<inheritdoc/>
        public int PlayTheBall()
        {
            BallsPlayed++;
            int ballResult = _resultGenerator.GetNext();
            if (ballResult != -1)
            {
                RunsScored = RunsScored + ballResult;
            }

            return ballResult;
        }
    }
}
