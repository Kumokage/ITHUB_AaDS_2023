using System.Globalization;
using System.IO;
using System.Diagnostics;

namespace PokemonGame
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

    public class PokemonCollection
    {
        int hashnew;

        private Node[] _collection = new Node[1000];

        public PokemonCollection(string dataPath)
        {
            ParseData(File.ReadAllLines(dataPath));
        }

        public void ParseData(string[] data)
        {
            for(int i = 0; i < data.Length; ++i)
            {
                string[] pokData = data[i].Split(';');

                bool is_legend;
                if (int.Parse(pokData[30]) == 0) is_legend = false;
                else is_legend = true;

                PokemonType? type2;
                if (pokData[28] != "") type2 = (PokemonType)Enum.Parse(typeof(PokemonType), pokData[28]);
                else type2 = null;

                float[] againstTypeTable = new float[18];

                for (int j = 0; j < 18; ++j)
                {
                    againstTypeTable[j] = float.Parse(pokData[j], CultureInfo.InvariantCulture);
                }

                Push(new Pokemon(
                float.Parse(pokData[18], CultureInfo.InvariantCulture),
                int.Parse(pokData[19]),
                int.Parse(pokData[20]),
                float.Parse(pokData[21], CultureInfo.InvariantCulture),
                float.Parse(pokData[22], CultureInfo.InvariantCulture),
                int.Parse(pokData[24]),
                int.Parse(pokData[25]),
                int.Parse(pokData[26]),
                int.Parse(pokData[29]),
                is_legend,
                pokData[23],
                (PokemonType)Enum.Parse(typeof(PokemonType), pokData[27]),
                    type2,
                    againstTypeTable
                ));
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

        //-

        public Pokemon FindByName(string name)
        {
            int hash = Math.Abs(name.GetHashCode() % _collection.Length);

            hashnew = hash;

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

            throw new Exception("No such pokemon");
        }
    }
}