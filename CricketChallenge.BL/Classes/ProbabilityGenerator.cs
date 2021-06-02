//////////////////////////////////////////// DESCRIPTION ///////////////////////////////////////////
// Make a collection of 100 units, each unit represent a possible score i.e. [0...6, or -1 for Out]
// Units are added to collection as per player's probability.
// e.g. if a player's probability of scoring 6 runs is 30% then 30 units among 100 represent 6 runs,
// if probability of scoring 1 run is 10% then 10 units among 100 represent 1 run, and so on.
// Each time the player faces the ball, these 100 units are arranged randomly, and then one random unit is picked.
//////////////////////////////////////////// DESCRIPTION ///////////////////////////////////////////

namespace CricketChallenge.BL.Classes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CricketChallenge.BL.Interfaces;

    /// <inheritdoc />
    internal class ProbabilityGenerator : IProbabilityGenerator
    {
        private const int CollectionLength = 100;
        private readonly int[] _results = { 0, 1, 2, 3, 4, 5, 6, -1 };
        private IList<int> _collectionOfHundredUnits = new List<int>(CollectionLength);

        /// <summary>
        /// Initialize the Calculator
        /// </summary>
        /// <param name="probability">Probability table</param>
        public ProbabilityGenerator(int[] probability)
        {
            InitializeCollection(probability);
            ArrangeUnitsRandomlyInCollection();
        }

        ///<inheritdoc/>
        public int GetNext()
        {
            Random indexGenerator = new Random();
            ArrangeUnitsRandomlyInCollection();
            int index = indexGenerator.Next(_collectionOfHundredUnits.Count);
            return _collectionOfHundredUnits[index];
        }

        /// <summary>
        /// Arrange all the units randomly
        /// </summary>
        private void ArrangeUnitsRandomlyInCollection()
        {
            Random indexGenerator = new Random();
            IList<int> randomCollection = new List<int>();
            for(int i = 0; i < CollectionLength; i++)
            {
                int index = indexGenerator.Next(_collectionOfHundredUnits.Count);
                randomCollection.Add(_collectionOfHundredUnits.ElementAt(index));
                _collectionOfHundredUnits.ToList().RemoveAt(index);
            }

            _collectionOfHundredUnits = randomCollection;
        }

        /// <summary>
        /// Initialize the collection with 100 units, distributed as per probability table
        /// Each unit represents a possible score[result]
        /// </summary>
        /// <param name="probability"></param>
        private void InitializeCollection(int[] probability)
        {
            if (probability.Length != _results.Length)
            {
                throw new ArgumentException("probability should be int["+ _results.Length + "]");
            }

            int nextCollectionIndex = 1;
            int totalOfProbability = 0;
            for (int resultIndex = 0; resultIndex < _results.GetUpperBound(0) + 1; resultIndex++)
            {
                int collectionIndex;
                totalOfProbability = totalOfProbability + probability[resultIndex];
                for (collectionIndex = nextCollectionIndex; collectionIndex <= totalOfProbability; collectionIndex++)
                {
                    _collectionOfHundredUnits.Add(_results[resultIndex]);
                }

                nextCollectionIndex = collectionIndex;
            }
        }
    }
}
