namespace CricketChallenge.BL.Interfaces
{
    /// <summary>
    /// Interface for calculating the probability of scoring
    /// </summary>
    public interface IProbabilityGenerator
    {
        /// <summary>
        /// Gets the next possible score based on player's probability
        /// </summary>
        /// <returns></returns>
        int GetNext();
    }
}
