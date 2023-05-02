using System;

namespace PokemonTCG;

public class Board : Sprite
{
    public Board(Texture2D texture, Vector2 post, Single sprite_scale) : base (texture, post, sprite_scale) 
    {
        
    }

    public override void Draw()
    {
        Globals.spriteBatch.Draw(texture, position, Color.White);
    }
}