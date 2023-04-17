namespace PokemonTCG;

// Class used for drawing game related entities.
public class Sprite
{
    public Texture2D texture { get; protected set; }
    public Vector2 position { get; set; }

    protected Vector2 origin;
    protected Vector2 scale;
    protected Color color; 

    public Sprite(Texture2D text, Vector2 pos)
    {
        texture = text;
        position = pos;
        origin = new(text.Width / 2, text.Height / 2);
        scale = Vector2.One;
    }


    // virtual class to allow sub classes to build on top of this function.
    public virtual void Draw()
    {
        Globals.spriteBatch.Draw(texture, position, null, color, 0f, origin, scale, SpriteEffects.None, 1f);
    }
}