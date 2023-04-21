using Microsoft.Xna.Framework.Content;
namespace PokemonTCG;

// Globals used for storing data from the Game1.cs file.
public class Globals
{
    public static float TotalSeconds { get; set; }
    public static SpriteBatch spriteBatch { get; set; }
    public static ContentManager Content { get; set; }

    public static void Update(GameTime gt)
    {
        TotalSeconds = (float)gt.ElapsedGameTime.TotalSeconds;
    }
}