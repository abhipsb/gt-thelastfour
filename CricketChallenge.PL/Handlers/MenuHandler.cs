namespace CricketChallenge.PL.Handlers
{
    using System;

    /// <summary>
    /// Class provides the different menus for user input
    /// </summary>
    internal class MenuHandler
    {
        private static string m_HeaderLines = "====================================================================";
        private static  string m_MainMenuLines = "==========";
        private static string m_WelcomeMessage = "Welcome to Intergalactic T20 Cup Finale between Lengaburu and Enchai";
        private static  string m_MainMenuText = "Main Menu";
        private static  string m_ChoseOptionText = "Choose from below options:";
        private static  string m_YourChoiceText = "Your Choice: ";
        private static  int m_DivideBy2 = 2;
        private static  int m_YPos0 = 0;
        private static  int m_YPos1 = 1;
        private static  int m_YPos2 = 2;

        /// <summary>
        /// Display the main program heder
        /// </summary>
        private static void DisplayHeader()
        {
            Console.Clear();
            Console.SetCursorPosition(Console.WindowWidth / m_DivideBy2 - m_HeaderLines.Length / m_DivideBy2, m_YPos0);
            Console.Out.WriteLine(m_HeaderLines);
            Console.SetCursorPosition(Console.WindowWidth / m_DivideBy2 - m_HeaderLines.Length / m_DivideBy2, m_YPos1);
            Console.Out.WriteLine(m_WelcomeMessage);
            Console.SetCursorPosition(Console.WindowWidth / m_DivideBy2 - m_HeaderLines.Length / m_DivideBy2, m_YPos2);
            Console.Out.WriteLine(m_HeaderLines);
        }

        /// <summary>
        /// Display main menu
        /// </summary>
        internal static char DoGetMainMenuChoice()
        {
            DisplayHeader();
            Console.Out.WriteLine(m_MainMenuLines);
            Console.Out.WriteLine(m_MainMenuText);
            Console.Out.WriteLine(m_MainMenuLines);
            Console.Out.WriteLine(m_ChoseOptionText);
            Console.Out.WriteLine("1. Play The Last Four");
            Console.Out.WriteLine("2. Play The Tie Breaker");
            Console.Out.WriteLine("3. Exit");
            Console.Out.Write(m_YourChoiceText);
            return Console.ReadKey(true).KeyChar;
        }
    }
}
