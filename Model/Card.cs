using System;

namespace PokemonTCG;

public class Card : Sprite
{
    private MouseState mouse_state;

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