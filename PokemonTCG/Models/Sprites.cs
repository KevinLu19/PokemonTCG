using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonTCG.Graphics
{
    // Class that encapsulates the pokemon card sprite for spritebatch draw method. Avoids repeating ourselves.
    public class Sprites
    {
        public Texture2D card_texture { get; set; }

        public Color sprite_color { get; set; } = Color.White;
        public Nullable<Rectangle> rectangle { get; set; } = null;
        public Single rotation = 0;
        public Vector2 origin = new Vector2(0,0);
        public Single scale = .5f;
        public SpriteEffects effects = 0;
        public Single layer_depth = 0;


        public Sprites(Texture2D texture)
        {
            card_texture = texture;
        }

        public void draw(SpriteBatch sprite_batch, Vector2 position)
        {
            sprite_batch.Draw(card_texture, position, rectangle, sprite_color, rotation, origin, scale, effects, layer_depth);
        }
    }
}
