using System;
using System.Collections.Generic;

namespace PokemonTCG;

// Player's hand class.
public class Hand : Decks
{
    private List<CardType> player_hand;

    public Hand(Texture2D texture, Vector2 position, Single scale) : base(texture, position, scale)
    {
        player_hand = new List<CardType>();
    }
}