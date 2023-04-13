namespace PokemonTCG;
public class Player
{
    private int max_num_of_cards_first_turn = 7;
    private int max_num_of_prize_card = 3;

    public Player()
    {
       
    }

    public int get_num_of_prize_card()
    {
        return max_num_of_prize_card;
    }

}