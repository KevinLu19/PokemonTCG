using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

// Trainers include item, Stadium, and Support cards.
enum CardTypes
{
    Pokemon, Trainers, Energy
}

public enum TrainerTypes
{ 
    Item, Support, Stadium
}

enum EnergyTypes
{
    Grass, Fire, Water, Electric, Fighting, Psychic, Colorless, Dark, Steel, Dragon, Fairy
}

enum EnergyVersion
{
    Basic, Double
}

namespace PokemonTCG.Entities
{
//    Deck related Rules:
//- Cannot have 3 of the same card name type in the deck except for energy cards.
//- Max card deck size is 42.
//- Cannot have more than 4 ultra-rare cards.
    public class Deck
    {
        private static int MAX_DECK_SIZE = 42;

        private Pokemon _pokemon_obj;

        private List<Pokemon> pokemon_cards = new List<Pokemon>(new Pokemon[MAX_DECK_SIZE]);

        // Create a deck and shuffle it for the user when generating a new game.
        public Deck()
        {
            shuffle();
        }

        // Shuffle using Fisher- Yates algorithm.
        public void shuffle()
        {
            Random rand = new Random();

            int list_pokemon_size = pokemon_cards.Count;

            // Fisher–Yates shuffle  Algorithm
            for (int i = list_pokemon_size - 1; i < 0; i--)
            {
                // Pick a random next index range from 0 to i.
                int random_next_index = rand.Next(0, i + 1);

                // Swapping.
                Pokemon temp_variable = pokemon_cards[i];
                pokemon_cards[i] = pokemon_cards[random_next_index];
                pokemon_cards[random_next_index] = temp_variable;
            }
        }

        // Drawing card from deck.
        public void Draw(int count)
        {
            Pokemon first_card = pokemon_cards[0];

        }
    }

    public class Card
    {
        public string card_type;                    // Trainer, Pokemon, or Energy card. 3 Possibilities.
    }

    public class Pokemon : Card
    {
        public string pokemon_name;
        public int hp;
        
        private string pokemon_stage;               // Tells if the card is basic, stage 1, stage 2, etc.
        private EnergyTypes pokemon_type;            // Electric, fire, water, etc.
        
        private List<String> move_set_name;         // Possibility of 1 or 2 moves in one card.
        public int move_damage;
        private List<EnergyTypes> move_set_energy_cost;

        public Pokemon()
        {
            pokemon_name = "";
            hp = 0;
        }
    }

    public class Energy : Card
    {
        private List<EnergyTypes> energy_type;               // Fire, water, Fighting, etc. to be used for moves.
        private int energy_count_value;                       // Each energy card default count to 1. Max count = 2;
        private string energy_card_name;                    // Default card will have no name. Double will have "double" in the name.

        public Energy()
        {
            energy_card_name = "";
            energy_count_value = 1;
        }


        // Checks if the energy card is a double or not. Double = counts as 2 energy card.
        public void is_double()
        {
            if (energy_card_name.Contains("double"))
            {
                energy_count_value++;
            }
        }
    }

    public class Trainer : Card
    {
        public string trainer_card_name;
        public List<TrainerTypes>trainer_type;             // ITem, support, or stadium.
    }
}