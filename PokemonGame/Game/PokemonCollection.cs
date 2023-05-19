using System.Globalization;
using System.IO;
using System.Diagnostics;
namespace PokemonGame
{
    public class PokemonCollection
    {
        public class Node
        {
            public Node? next;
            public Pokemon value;
            public Node(Node node, Pokemon pokemon)
            {
                next = node;
                value = pokemon;
            }
        }
        private Node[] _collection = new Node[1000];
        public PokemonCollection(string dataPath)
        {
            ParseData(File.ReadAllLines(dataPath));
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
                Push(new Pokemon(float.Parse(pokemon_data[18]),
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
                    pokemon_data[28] != "" ? (PokemonType)Enum.Parse(typeof(PokemonType), pokemon_data[28]) : null, againstTypeTable));

            }
        }

        public void Push(Pokemon pokemon)
        {
            int hash = Math.Abs(pokemon.Name.GetHashCode() % _collection.Length);

            if (_collection[hash] is not null)
            {
                Node node = _collection[hash];

                while (node is not null)
                {

                    if (node.value.Name == pokemon.Name)
                    {
                        node.value = pokemon;
                        return;
                    }
                    node = node.next;
                }

                _collection[hash] = new Node(_collection[hash], pokemon);
            }
            else
            {
                _collection[hash] = new Node(null, pokemon);
            }

        }

        public Pokemon FindByName(string name)
        {
            int hash = Math.Abs(name.GetHashCode() % _collection.Length);

            if (_collection[hash] is not null)
            {
                Node node = _collection[hash];

                while (node is not null)
                {
                    if (node.value.Name == name)
                    {
                        return node.value;
                    }
                    node = node.next;
                }
            }

            throw new Exception("No pokemon was found");
        }
    }
}