using System.Globalization;
namespace PokemonGame;

public class PokemonCollection
{
    class Node
    {
        public Pokemon pokemon;
        public Node? next;
        public Node(Pokemon pokemon, Node? next)
        {
            this.pokemon = pokemon;
            this.next = next;
        }
    }
    private readonly Node[] collection = new Node[Size];


    const int Size = 1000;
    public PokemonCollection(string dataPath)
    {
        string[] data = File.ReadAllLines(dataPath);
        ParseData(data);
    }

    public void ParseData(string[] data)
    {
        foreach (var line in data)
        {
            string[] pokemon_data = line.Split(';');
            float[] againstTypeTable = new float[18];
            for (int i = 0; i < againstTypeTable.Length; i++)
            {
                againstTypeTable[i] = float.Parse(pokemon_data[i], CultureInfo.InvariantCulture);
            }

            Pokemon pok = new(
                float.Parse(pokemon_data[18]),
                int.Parse(pokemon_data[19]),
                int.Parse(pokemon_data[20]),
                float.Parse(pokemon_data[21]),
                float.Parse(pokemon_data[22]),
                int.Parse(pokemon_data[24]),
                int.Parse(pokemon_data[25]),
                int.Parse(pokemon_data[26]),
                int.Parse(pokemon_data[29]),
                int.Parse(pokemon_data[30]) == 1,
                pokemon_data[23],
                (PokemonType)Enum.Parse(typeof(PokemonType), pokemon_data[27]),
                pokemon_data[28] != "" ? (PokemonType)Enum.Parse(typeof(PokemonType), pokemon_data[28]) : null, againstTypeTable);

            Push(pok);

        }

    }

    public void Push(Pokemon pokemon)
    {
        int hash = Math.Abs(pokemon.Name.GetHashCode()) % Size;
        if (collection[hash] is null)
        {
            collection[hash] = new Node(pokemon, null);

        }
        else
        {
            Node next = collection[hash];
            collection[hash] = new Node(pokemon, next);
        }

    }

    public Pokemon FindByName(string name)
    {
        int hash = Math.Abs(name.GetHashCode()) % Size;


        Node buf = collection[hash];

        if (buf is null)
        {
            throw new NotImplementedException();
        }
        else
        {
            while (buf.pokemon.Name != name)
            {
                buf = buf.next;
            }

        }

        return buf.pokemon;
    }
}