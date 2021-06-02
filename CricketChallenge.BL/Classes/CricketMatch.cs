namespace CricketChallenge.BL.Classes
{
    using System;
    using System.Threading;
    using CricketChallenge.BL.Interfaces;

    /// <summary>
    /// Implementation of Cricket Match
    /// </summary>
    internal class CricketMatch : ICricketMatch
    {
        private Action<string> ResultOutputHandler { get; set; }
        private int _ballNumber;
        private readonly int _totalBallsToPlay;
        private ITeam _currentBattingTeam;

        ///<inheritdoc/>
        public int BallsPerOver => 6;

        ///<inheritdoc/>
        public ITeam FirstBattingTeam { get; }

        ///<inheritdoc/>
        public ITeam SecondBattingTeam { get; }

        ///<inheritdoc/>
        public int RemainingBallsToPlay => _totalBallsToPlay - _ballNumber;

        ///<inheritdoc/>
        public int RunsToWin { get; private set; }

        ///<inheritdoc/>
        public MatchStatus Status { get; private set; }

        ///<inheritdoc/>
        public IPlayer StrikeBatsman { get; private set; }

        ///<inheritdoc/>
        public IPlayer NonStrikeBatsman { get; private set; }

        /// <summary>
        /// Initialize a new match for both teams to play
        /// </summary>
        /// <param name="teamToBatFirst"></param>
        /// <param name="teamToBatSecond"></param>
        /// <param name="ballsToPlay"></param>
        public CricketMatch(ITeam teamToBatFirst, ITeam teamToBatSecond, int ballsToPlay = 6)
        {
            FirstBattingTeam = teamToBatFirst;
            SecondBattingTeam = teamToBatSecond;
            _totalBallsToPlay = ballsToPlay;
        }

        /// <summary>
        /// Initialize a new match considering first team has already played and second team will chase a target
        /// </summary>
        /// <param name="teamToBatFirst"></param>
        /// <param name="teamToBatSecond"></param>
        /// <param name="customTarget"></param>
        /// <param name="ballsToPlay"></param>
        public CricketMatch(ITeam teamToBatFirst, ITeam teamToBatSecond, int customTarget, int ballsToPlay)
        {
            FirstBattingTeam = teamToBatFirst;
            SecondBattingTeam = teamToBatSecond;
            RunsToWin = customTarget;
            _totalBallsToPlay = ballsToPlay;
        }

        ///<inheritdoc/>
        public void PlayFirstHalf()
        {
            Status = MatchStatus.InProgress;
            _currentBattingTeam = FirstBattingTeam;
            DoPlay();
            _ballNumber = 0;
            RunsToWin = FirstBattingTeam.Score + 1;
        }

        ///<inheritdoc/>
        public void PlaySecondHalf()
        {
            _ballNumber = 0;
            _currentBattingTeam = SecondBattingTeam;
            DoPlay(true);
            Status = MatchStatus.Completed;
        }

        ///<inheritdoc/>
        public WinnerInfo GetWinner()
        {
            WinnerInfo info = new WinnerInfo {Team = null, IsTieBreak = false, Status = MatchStatus.InProgress };
            if (Status != MatchStatus.Completed)
            {
                return info;
            }

            info.Status = MatchStatus.Completed;
            if (SecondBattingTeam.Score == RunsToWin - 1)
            {
                info.Team = null;
                info.IsTieBreak = true;
                return info;
            }

            if (SecondBattingTeam.Score < RunsToWin - 1)
            {
                info.Team = FirstBattingTeam;
                return info;
            }

            info.Team = SecondBattingTeam;
            return info;
        }

        ///<inheritdoc/>
        public void SetResultOutputHandler(Action<string> handler)
        {
            ResultOutputHandler = handler;
        }

        /// <summary>
        /// Simulation for playing balls
        /// </summary>
        /// <param name="isChasingTarget">Param to indicate if the current batting team is chasing target</param>
        private void DoPlay(bool isChasingTarget = false)
        {
            StrikeBatsman = _currentBattingTeam.GetNextPlayer();
            NonStrikeBatsman = _currentBattingTeam.GetNextPlayer();
            while (_totalBallsToPlay > _ballNumber)
            {
                int result = StrikeBatsman.PlayTheBall();
                _ballNumber++;
                ReturnBallPlayedResult(result);
                if (result == -1)
                {
                    StrikeBatsman.Status = BattingStatus.Out;
                    StrikeBatsman = _currentBattingTeam.GetNextPlayer();
                    if (StrikeBatsman == null)
                    {
                        break;
                    }

                    continue;
                }

                if (isChasingTarget && _currentBattingTeam.Score >= RunsToWin)
                {
                    break;
                }

                int overCheck = _ballNumber % BallsPerOver;
                if (result != 0 && result % 2 != 0)
                {
                    DoSwapBatsmen();
                }

                if (overCheck == 0)
                {
                    DoSwapBatsmen();
                    ReturnOverCompletedResult(isChasingTarget);
                }

                // For showing output slowly
                Thread.Sleep(300);
            }
        }

        /// <summary>
        /// Swap the batsmen on odd score or over complete
        /// </summary>
        private void DoSwapBatsmen()
        {
            IPlayer batsman = StrikeBatsman;
            StrikeBatsman = NonStrikeBatsman;
            NonStrikeBatsman = batsman;
        }

        /// <summary>
        /// For displaying the result of ball played by the batsman
        /// </summary>
        /// <param name="ballResult"></param>
        private void ReturnBallPlayedResult(int ballResult)
        {
            string message = ResultGetter.GetBallPlayed(StrikeBatsman, _ballNumber, ballResult, BallsPerOver);
            ResultOutputHandler?.Invoke(message);
        }

        /// <summary>
        /// For displaying the summary after over completion
        /// </summary>
        /// <param name="isChasingTarget"></param>
        private void ReturnOverCompletedResult(bool isChasingTarget = false)
        {
            string message = ResultGetter.GetOverCompleted(this, _currentBattingTeam, isChasingTarget);
            ResultOutputHandler?.Invoke(message);
        }
    }
}
