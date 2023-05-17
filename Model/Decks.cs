using System;
using System.Collections.Generic;
using System.IO;
namespace PokemonTCG;

public class Decks : Sprite
{
    private MouseState mouse_state;
    private Point mouse_point;

    private List<string> sprite_files = new List<String>();
    private Card card;

    private List<Card> player_deck = new List<Card>();
    private EnergyType energy_type;

    // Loading sprites variable
    private List<Texture2D> list_loaded_sprites_directory = new List<Texture2D>();
    private GraphicsDevice _graphics { get; set; }

    // Deck sprite collision via Rectangles from Monogame.
    int rectangle_x = 1426;
    int rectangle_y = 860;
    int rectangle_width = 10;    
    int rectangle_height = 10;
    Rectangle sprite_rectangle_obj;

    public Decks(Texture2D text, Vector2 post, Single sprite_scale) : base(text, post, sprite_scale)
    {
        // Rectangle used for collision.
        sprite_rectangle_obj = new Rectangle(rectangle_x, rectangle_y, rectangle_width, rectangle_height);

        // Create a deck. - The focus of the deck would be chosen by random via random selection of the energy card.
        EnergyType main_deck_type = choose_energy_card_type();

    }

    // Picking a random energy type. This will dictate what is the "main" focus of the deck. The return value would be a random Energy type from the enum.
    public EnergyType choose_energy_card_type()
    {
        Random random = new Random();
        Type type = typeof(EnergyType);

        Array values = type.GetEnumValues();

        int index = random.Next(values.Length);
        EnergyType value = (EnergyType)values.GetValue(index);

        return value;
    }

    public List<Texture2D> load_sprites_from_folder()
    {
        var directory_path = new DirectoryInfo(Globals.Content.RootDirectory + "/pokemon_sprite");

        if (!directory_path.Exists)
            throw new DirectoryNotFoundException();

        FileInfo[] files = directory_path.GetFiles(".*");

        foreach (FileInfo file in files)
        {
            string sprite_files = Path.GetFileName(file.Name);

            FileStream file_stream = new FileStream(Globals.Content.RootDirectory + "/pokemon_sprite" + "/" + sprite_files, FileMode.Open);
            Texture2D sprite = Texture2D.FromStream(_graphics, file_stream);

            list_loaded_sprites_directory.Add(sprite);
        }

        return list_loaded_sprites_directory;
    }

    public void Update(Vector2 deck_position)
    {
        mouse_state = Mouse.GetState();

        // Getting the current mouse location.
        mouse_point = new Point(mouse_state.X, mouse_state.Y);

        //// When left clicked, generate a new card. 
        //if (mouse_state.LeftButton != ButtonState.Pressed && mouse_state.X == deck_position.X)
        //{
        //    card = new(Globals.Content.Load<Texture2D>("pokemon_sprite/Sprites/Pikachu"), new(200, 200), .5f);
        //}

        // Mouse Collision Detection - If the mouse contains the sprite rectangle, then generate a new card.
        if (sprite_rectangle_obj.Contains(mouse_point))
        {
            sprite_scale = 5f;
        }
    }
}