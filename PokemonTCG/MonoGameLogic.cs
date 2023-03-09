using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PokemonTCG
{
    public class MonoGameLogic : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Texture2D _pokemon_game_board, _window_background;
        private Texture2D _deck_of_cards;
        private Texture2D _example_pokemon_card;

        private Vector2 _example_pokemon_card_position = new Vector2(320, 42);

        private MouseState m_state;

        public MonoGameLogic()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.PreferredBackBufferWidth = 1980;
            _graphics.PreferredBackBufferHeight = 1080;
        }

        protected override void Initialize()
        {
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
            _example_pokemon_card = Content.Load<Texture2D>("Pokemon/Sprites/Pokemons/Electric/Pikachu");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            m_state = Mouse.GetState();

            // Use the mouse to drag around the cards.

            /*
                The way this move sprite function works is the sprite will move to where the current mouse state is currently at instead of incrementing 
                the mouse speed. This will move instantly. 

                - Still need to change where the mouse needs to be hovering over the card to move.
                - Cannot move diagonally
                - Moving up and down is very jank.
             */
            if (m_state.LeftButton == ButtonState.Pressed && m_state.X != _example_pokemon_card_position.X)
            {
                _example_pokemon_card_position.X = m_state.X;
            }
           
            else if (m_state.LeftButton == ButtonState.Pressed && m_state.Y != _example_pokemon_card_position.Y)
            {
                _example_pokemon_card_position.Y = m_state.Y;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            _spriteBatch.Draw(_window_background, new Vector2(0, 0), Color.White);
            _spriteBatch.Draw(_pokemon_game_board, new Vector2(320,42), Color.White);
            _spriteBatch.Draw(_deck_of_cards, new Vector2(1366, 800), null, Color.White, 0, new Vector2(0,0), .12f, 0, 0);

            _spriteBatch.Draw(_example_pokemon_card, _example_pokemon_card_position, Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}