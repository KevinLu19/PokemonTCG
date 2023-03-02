using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PokemonTCG
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Texture2D _pokemon_game_board, _window_background;
        private Texture2D _deck_of_cards;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.PreferredBackBufferWidth = 1980;
            _graphics.PreferredBackBufferHeight = 1080;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            // Change the default window size.
            _graphics.IsFullScreen = false;
            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _pokemon_game_board = Content.Load<Texture2D>("Pokemon/board");
            _window_background = Content.Load<Texture2D>("Pokemon/window_background");
            _deck_of_cards = Content.Load<Texture2D>("Pokemon/pokemon_back_side");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            _spriteBatch.Draw(_window_background, new Vector2(0, 0), Color.White);
            _spriteBatch.Draw(_pokemon_game_board, new Vector2(320,42), Color.White);
            _spriteBatch.Draw(_deck_of_cards, new Vector2(1366, 800), null, Color.White, 0, new Vector2(0,0), .12f, 0, 0);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}