using System;

namespace MTGCollection;

public enum Color
{
    W,
    B,
    G,
    R,
    U
}

public class Card
{
    public Color[] colors = new Color[Enum.GetNames(typeof(Color)).Length];
    
}
