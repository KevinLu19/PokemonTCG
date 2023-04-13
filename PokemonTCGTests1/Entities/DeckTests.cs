using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokemonTCG.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PokemonTCG.Entities.Tests
{
    [TestClass()]
    public class DeckTests
    {
        [TestMethod()]
        // Fisher- Yates algorithm.
        public void shuffle_test_return_void()
        {
            // Arrange - Configure the test by setting up the tested systems and other mechanisms.
            Random rand = new Random();
            List<int> testing_list = new List<int> {1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20};
            int next_number;        // Used for the algorithm. Chooses the next number to start the algorithm.
            Deck test_deck_shuffle = new Deck();

            // Act - Call the action to perform test unit. 
            //test_deck_shuffle.shuffle();

            for (int i = testing_list.Count - 1; i < 0; i--)
            {
                // Pick a random next index range from 0 to i.
                int random_next_index = rand.Next(0, i + 1);

                // Swapping.
                int temp_variable = testing_list[i];
                testing_list[i] = testing_list[random_next_index];
                testing_list[random_next_index] = temp_variable;
            }

            Console.WriteLine(testing_list);

            // Assert - Check result of the performed operation
            Assert.Fail();
        }
    }
}