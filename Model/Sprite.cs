using System;

namespace PokemonTCG;

// Class used for drawing game related entities.
// Base class in order to draw anything on the screen.
public class Sprite
{
    public Texture2D texture { get; protected set; }
    public Vector2 position { get; set; }

    protected Vector2 origin;
    protected Vector2 scale;

    protected Rectangle sprite_rectangle;
    protected Single rotation;


    public Sprite(Texture2D text, Vector2 pos)
    {
        texture = text;
        position = pos;
        origin = new(text.Width / 2, text.Height / 2);
        scale = Vector2.One;
        rotation = 0;
    }


    // virtual class to allow sub classes to build on top of this function.
    public virtual void Draw()
    {
        Globals.spriteBatch.Draw(texture, position, null, Color.White, rotation, origin, 1, SpriteEffects.None, 1);
    }
}