using System;

using PokemonTCG.Graphics;
using System.Collections.Generic;
using PokemonTCG.Entities;

namespace PokemonTCG;

public class MonoGameLogic : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    // Board variables
    private Texture2D _pokemon_game_board, _window_background;
    private Texture2D _deck_of_cards;

    // Pokemon Sprites
    //private List<Sprites> _active_pokemon;
    private Texture2D active_pokemon_texture;
    private Texture2D _example_pokemon_2;

    private Vector2 _example_pokemon_card_position = new Vector2(380, 130);
    private Vector2 _example_2_position = new Vector2(370, 130);
    const int card_off_set = 55;

    private MouseState m_state, new_state;

    // Game related variables;
    List<Pokemon> player_hand = new List<Pokemon>();
    List<Pokemon> opponent_hand = new List<Pokemon>();

    // Deck Drawing
    private Deck deck_obj;

    // Draw sprite function variables
    private Nullable<Rectangle> _source_rectangle = null;
    private Single _rotation = 0;
    private Vector2 _origin = new Vector2(0,0);
    private SpriteEffects _effects = 0;
    private Single _layer_depth = 0;

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

        GameLogic game_logic_obj = new GameLogic();
        Window.Title = "Pokemon TCG";
        //PokemonTCG.Deck deck_obj = new PokemonTCG.Deck();

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        _pokemon_game_board = Content.Load<Texture2D>("Pokemon/board");
        _window_background = Content.Load<Texture2D>("Pokemon/window_background");
        _deck_of_cards = Content.Load<Texture2D>("Pokemon/pokemon_back_side");

        deck_obj = new Deck();

        active_pokemon_texture = Content.Load<Texture2D>("Pokemon/Sprites/Pokemons/Pikachu");
        _example_pokemon_2 = Content.Load<Texture2D>("Pokemon/Sprites/Pokemons/Charmander");

    }
    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        m_state = Mouse.GetState();

        // Calculates the difference between the two points.
        float mouse_target_dist = Vector2.Distance(_example_pokemon_card_position, m_state.Position.ToVector2());

        /*
            The way this move sprite function works is the sprite will move to where the current mouse state is currently at instead of incrementing 
            the mouse speed. This will move instantly. 
         */
        // This is the test of the second sprite. In this case it was the charmander sprite that I was testing out.
        if (m_state.LeftButton == ButtonState.Pressed && m_state.X != _example_pokemon_card_position.X)
        {

            // Allows to move the card via mouse left click. The draw function places sprite to the left and up to offset the draw sprite placement.
            if (mouse_target_dist < _example_pokemon_card_position.X)
            {
                _example_pokemon_card_position.X = m_state.X;
                _example_pokemon_card_position.Y = m_state.Y;
            }
           
        }

        float mouse_target_dist2 = Vector2.Distance(_example_pokemon_card_position, m_state.Position.ToVector2());

        if (m_state.LeftButton == ButtonState.Pressed && m_state.X != _example_2_position.X)
        {
            if (mouse_target_dist2 < _example_pokemon_card_position.X)
            {
                _example_pokemon_card_position.X = m_state.X;
                _example_pokemon_card_position.Y = m_state.Y;
            }
        }

        // Handles the drawing deck sprite.
        if(m_state.LeftButton == ButtonState.Pressed && m_state.LeftButton == ButtonState.Released)
        {
            
        }
        

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();

        Sprites card_sprite = new Sprites(active_pokemon_texture);
        
        // Static drawing where they wont change the outcome of the game.
        // Background sprites.
        _spriteBatch.Draw(_window_background, new Vector2(0, 0), Color.White);
        _spriteBatch.Draw(_pokemon_game_board, new Vector2(320,42), Color.White);
        _spriteBatch.Draw(_deck_of_cards, new Vector2(1366, 800), _source_rectangle, Color.White, _rotation, _origin, .12f, _effects, _layer_depth);

        // When deck of cards are clicked, this will draw a card from the deck pile.
        

        // Drawing playing pokemon cards.
        _spriteBatch.Draw(active_pokemon_texture, new Vector2(_example_pokemon_card_position.X - card_off_set, _example_pokemon_card_position.Y - card_off_set), _source_rectangle, Color.White, _rotation, _origin, .5f, _effects, _layer_depth);
        
        // Position 555, 800) is the position that is the left side bench of player 1 side of the board.
        //card_sprite.draw(_spriteBatch, new Vector2(555, 800));
        
        //_spriteBatch.Draw(_example_pokemon_2, new Vector2(0,0), _source_rectangle, Color.White, _rotation, _origin, .5f, _effects, _layer_depth);

        _spriteBatch.End();

        base.Draw(gameTime);
    }
}