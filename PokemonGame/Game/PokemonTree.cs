
using System.Diagnostics;


namespace PokemonGame;

public class PokemonTree
{

    class Node
    {
        private Node? left;
        private Node? right;
        private Pokemon pokemon;
        private string value;

        public Node(Pokemon pokemon, Node? left, Node? right)
        {
            this.pokemon = pokemon;
            this.left = left;
            this.right = right;
            value = pokemon.Name;


        }

    }

    private Node? root;
    public int Size { get; }

    public void Add(Pokemon pokemon)
    {
        
        throw new NotImplementedException();
    }

    public void Add(Pokemon pokemon)
    {
        throw new NotImplementedException();
    }


    public Pokemon Search(string name)
    {
        throw new NotImplementedException();
    }


    public Pokemon Delete(string name)
    {
        throw new NotImplementedException();
    }

    public void Balance()
    {
        throw new NotImplementedException();
    }
    




}