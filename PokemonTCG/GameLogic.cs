using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//using static Player;

public class GameLogic
{
    bool item_card_used_per_turn = false;
    private static int max_bench_pokemon = 5;
    bool end_turn_phase = false;

    public GameLogic()
    {
        //Player player1;
        //PokemonTCG.Deck deck = new PokemonTCG.Deck();

        determine_first_turn();
        //game_start();


    }

    public void determine_first_turn()
    {
        Random rand_num = new Random(); 

        int generate_1_10 = rand_num.Next(1, 11);       // Generates a number from 1 - 10.
        const int HALF_OF_GENERATED_NUMBER = 5;

        if (generate_1_10 > HALF_OF_GENERATED_NUMBER)
        {
            // Player 1 Goes First
            Console.WriteLine("Player 1 Goes First");
            Console.WriteLine("Player 2 Goes Second");
        }
        else
        {
            // Player 2 Goes First.
            Console.WriteLine("Player 2 Goes First");
            Console.WriteLine("Player 1 Goest Second");
        }
    }

    private void game_start()
    {

    }

    public void draw_a_card()
    {

    }
    // player require to redraw 7 cards if there is no active pokemon to play.
    public void no_pokemon_initial_game()
    {

    }

    public void play_pokemon_card()
    {

    }

    public void play_energy_card()
    { }

    public void play_trainer_card()
    {

    }
}
