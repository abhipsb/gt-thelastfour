namespace CricketChallenge.PL.Ui
{
    using System;
    using CricketChallenge.BL.Interfaces;
    using CricketChallenge.Interface;
    using CricketChallenge.PL.Handlers;

    /// <summary>
    /// Main class of the exe
    /// </summary>
    public class UserInterface
    {
        private const char MainMenuChoiceLastFour = '1';
        private const char MainMenuChoiceTieBreaker = '2';
        private const char MainMenuChoiceExit = '3';

        /// <summary>
        /// The main function of console app
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            while (true)
            {
                char mainMenuChoice = MenuHandler.DoGetMainMenuChoice();
                if (mainMenuChoice.Equals(MainMenuChoiceExit))
                {
                    Console.WriteLine();
                    break; // Exit main while loop
                }

                ProcessUserChoice(mainMenuChoice);
            }
        }

        /// <summary>
        /// Process the user choice and play the match
        /// </summary>
        /// <param name="userChoice"></param>
        /// <param name="userInputValue"></param>
        private static void ProcessUserChoice(char userChoice)
        {
            Console.Clear();
            switch (userChoice)
            {
                case MainMenuChoiceLastFour:
                    DoPlayLastFour();
                    break;
                case MainMenuChoiceTieBreaker:
                    DoPlayTieBreak();
                    break;
            }
        }

        /// <summary>
        /// Play the last four overs and display the result
        /// </summary>
        private static void DoPlayLastFour()
        {
            // Team1 -> Enchai
            ITeam team1 = Get.NewTeam("Enchai");

            // Team2 -> Lengaburu
            ITeam team2 = Get.NewTeam("Lengaburu");
            IPlayer player = Get.NewPlayer("Kirat Boli", new int[] {5, 30, 25, 10, 15, 1, 9, 5});
            team2.AddPlayer(player);
            player = Get.NewPlayer("NS Nodhi", new int[] { 10, 40, 20, 5, 10, 1, 4, 10 });
            team2.AddPlayer(player);
            player = Get.NewPlayer("R Rumrah", new int[] { 20, 30, 15, 5, 5, 1, 4, 20 });
            team2.AddPlayer(player);
            player = Get.NewPlayer("Shashi Henra", new int[] { 30, 25, 5, 0, 5, 1, 4, 30 });
            team2.AddPlayer(player);

            // Setup Match for Last Four Overs
            ICricketMatch lastFourOverMatch = Get.NewMatch(team1, team2, 40, 24);
            lastFourOverMatch.SetResultOutputHandler(Console.WriteLine);

            // Play Second half
            DoPlaySecondHalf(lastFourOverMatch);
        }

        /// <summary>
        /// Play the tie breaker and display the result
        /// </summary>
        private static void DoPlayTieBreak()
        {
            Console.WriteLine("****** TIE BREAKER STARTED ******");

            // Setup team1
            ITeam team1 = Get.NewTeam("Enchai");
            IPlayer player = Get.NewPlayer("DB Vellyers", new int[] { 5, 10, 25, 10, 25, 1, 14, 10 });
            team1.AddPlayer(player);
            player = Get.NewPlayer("H Mamla", new int[] { 10, 15, 15, 10, 20, 1, 19, 10 });
            team1.AddPlayer(player);

            // Setup team2
            ITeam team2 = Get.NewTeam("Lengaburu");
            player = Get.NewPlayer("Kirat Boli", new int[] { 5, 10, 25, 10, 25, 1, 14, 10 });
            team2.AddPlayer(player);
            player = Get.NewPlayer("NS Nodhi", new int[] { 5, 15, 15, 10, 20, 1, 19, 15 });
            team2.AddPlayer(player);

            // New Tie Breaker Match
            ICricketMatch tieBreakMatch = Get.NewMatch(team1, team2, 6);
            tieBreakMatch.SetResultOutputHandler(Console.WriteLine);

            // Play First half
            tieBreakMatch.PlayFirstHalf();
            Console.WriteLine(Get.TeamScore(team1));
            Console.WriteLine(Get.BattingSummary(team1));

            // Play Second half
            DoPlaySecondHalf(tieBreakMatch);
        }

        /// <summary>
        /// Play the second half [it's common for both problems]
        /// </summary>
        /// <param name="match"></param>
        private static void DoPlaySecondHalf(ICricketMatch match)
        {
            Console.WriteLine(Get.FirstHalfSummary(match));
            match.PlaySecondHalf();
            Console.WriteLine(Get.TeamScore(match.SecondBattingTeam));
            Console.WriteLine(Get.BattingSummary(match.SecondBattingTeam));
            WinnerInfo matchWinner = match.GetWinner();
            if (matchWinner.IsTieBreak)
            {
                DoPlayTieBreak();
                return;
            }

            Console.WriteLine(Get.MatchWinnerSummary(match));
            Console.ReadKey();
        }
    }
}
