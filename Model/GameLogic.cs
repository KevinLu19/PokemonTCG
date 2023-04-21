namespace PokemonTCG;

// Game rules and gameplay code will live in.
public class GameLogic
{
    private Card card;
    private readonly Texture2D background;

    public GameLogic() 
    {
        card = new(Globals.Content.Load<Texture2D>("pokemon_sprite/Sprites/Pikachu"), new(200, 200));
    }

    public void Update()
    {
        card.Update();
    }

    public void Draw()
    {
        card.Draw();
    }
}