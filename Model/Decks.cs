using System;
using System.Collections.Generic;
using System.IO;
namespace PokemonTCG;


public class Decks : Sprite
{
    private MouseState mouse_state;
    private List<string> sprite_files = new List<String>();
    private Card card;

    // Loading sprites variable
    private List<Texture2D> list_loaded_sprites_directory = new List<Texture2D>();
    private GraphicsDevice _graphics { get; set; }

    public Decks(Texture2D text, Vector2 post, Single sprite_scale) : base(text, post, sprite_scale)
    {

    }

    public void mouse_hover_deck()
    {
        mouse_state = Mouse.GetState();
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

        // When left clicked, generate a new card. 
        if (mouse_state.LeftButton != ButtonState.Pressed && mouse_state.X == deck_position.X)
        {

            card = new(Globals.Content.Load<Texture2D>("pokemon_sprite/Sprites/Pikachu"), new(200, 200), .5f);
        }
    }
}