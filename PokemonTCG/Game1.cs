namespace PokemonTCG;
public class Game1 : Game
{
    // Monogame drawing variables.
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    // Game manager
    private GameLogic _game_logic;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        
        // Changing the window size
        _graphics.IsFullScreen = false;
        
        // Setting window size to 1920 x 1080.
        _graphics.PreferredBackBufferWidth = 1920;
        _graphics.PreferredBackBufferHeight = 1080;

        _graphics.ApplyChanges();
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
        Globals.spriteBatch = _spriteBatch;
        Globals.contentManager = Content;
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
        //_game_manager.draw();
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
