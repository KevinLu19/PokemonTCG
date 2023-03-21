using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
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
    // Can't have more than 3 of the same card in a deck.
    public class Deck
    {
        private static int MAX_DECK_SIZE = 42;

        private Pokemon _pokemon_obj;

        private List<Pokemon> pokemon_cards { get; set; }

        public Deck()
        {
            // Pokemon pokemon_cards = new Pokemon();

            for (int index = 0; index < MAX_DECK_SIZE; index++)
            {
                
                pokemon_cards.Add(new Pokemon()
                {
                    pokemon_name = "Pikachu",
                    hp = 60,
                });
            }
        }

        // Shuffle using Fisher- Yates algorithm.
        public void shuffle()
        {
            Random rand = new Random();

        }

        // Drawing card form deck.
        public string Draw(int count)
        {
            return "";
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