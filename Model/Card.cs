using System;

namespace PokemonTCG;

enum CardType 
{
    Pokemon, 
    Trainer, 
    Energy 
}

public enum EnergyType
{
    Fire,
    Water,
    Grass,
    Electric,
    Fighting,
    Dark,
    Fairy,
    Psychic,
    Steel,
    Colorless
}

public class Card : Sprite
{
    private MouseState mouse_state;

    // Model properties of a card.
    // If card is a pokemon.
    private int pokemon_health;
    private string pokemon_name;
    private string pokemon_hidden_ability;             // Value of this can be null.
    private string damage_ability_name;
    private int inflicted_damage_ability;
    private int num_of_energy_cost_needed;                 
    private string ability_description;   
    private int weakness_damage_multiplier;     // Double damage.

    // Typing for these variables would need to be changed to a custom typing.
    private string ability_type; 
    private string pokemon_weakness_type;

    // Trainer - Item Cards
    private string item_card_name;
    private string item_card_description;

    // Trainer - Support Cards
    private string support_card_name;
    private string support_card_description;

    // Variable used for sprite collision detection. Used for if mouse collides with the card sprite or not.
    // private Rectangle sprite_rectangle;

    public Card (Texture2D tex, Vector2 pos, Single sprite_scale) : base (tex, pos, sprite_scale)
    {
    }

    public void Update()
    {
        // Get the current state. 
        mouse_state = Mouse.GetState();

        // Moving sprite via mouse.
        if (mouse_state.LeftButton == ButtonState.Pressed && mouse_state.X != position.X && mouse_state.Y != position.Y)
        {
            position = new Vector2(380, 130)
            {
                X = mouse_state.X,
                Y = mouse_state.Y
            };
        }

    }
}