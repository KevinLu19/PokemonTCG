using System;

namespace PokemonTCG;

// Game rules and gameplay code will live in.
public class GameLogic
{
    //private readonly Card card;
    private readonly Board background;
    private readonly Board board_sprite;
    private readonly Decks player_deck_of_cards;

    private Single scale = .5f;

    private Vector2 player_deck_of_cards_position = new Vector2(1426, 860);

    public GameLogic()
    {
        //card = new(Globals.Content.Load<Texture2D>("pokemon_sprite/Sprites/Pikachu"), new(200, 200), scale);
        background = new(Globals.Content.Load<Texture2D>("pokemon_sprite/window_background"), new(0,0), scale);
        board_sprite = new(Globals.Content.Load<Texture2D>("pokemon_sprite/board"), new(320, 28), scale);
        player_deck_of_cards = new(Globals.Content.Load<Texture2D>("pokemon_sprite/pokemon_back_side"), new(1426, 860), scale);
    }

    // Card collision spots on the board. For cards to be "placed" on the board.
    private void card_spot_collision()
    {
        
    }

    public void update()
    {
        player_deck_of_cards.Update(player_deck_of_cards_position);

        //card.Update();

        card_spot_collision();
    }

    public void Draw()
    {
        
        background.Draw();
        board_sprite.Draw();
        player_deck_of_cards.Draw();
        //card.Draw();
    }
}