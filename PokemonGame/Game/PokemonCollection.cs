using System.Globalization;
namespace PokemonGame;

public class PokemonCollection
{
    class Node
    {
        public const int COLLECTIONSIZE = 1000;
        public Pokemon pokemon;
        public Node? next;
        public Node(Pokemon pokemon,Node? next,int CONSTSIZE )
        {
            this.pokemon = pokemon;
            this.next = next;
            COLLECTIONSIZE = CONSTSIZE;
        }
    }
    public PokemonCollection(string dataPath)
    {
        throw new NotImplementedException();
    }

    public void ParseData(string[] data)
    {
        throw new NotImplementedException();
    }

    public void Push(Pokemon pokemon)
    {
        throw new NotImplementedException();
    }

    public Pokemon FindByName(string name)
    {
        throw new NotImplementedException();
    }
}