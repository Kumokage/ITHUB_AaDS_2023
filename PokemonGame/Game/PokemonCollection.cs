using System.Drawing;
using System.Globalization;
namespace PokemonGame;

public class PokemonCollection
{
    const int SIZE = 1000;
    Node[] container = new Node[SIZE];
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
    public PokemonCollection(string dataPath)
    {
        string[] data = File.ReadAllLines(dataPath);
    }

    public void ParseData(string[] data)
    {
        foreach (string link in data)
        {
            string[] mass = link.Split(";");
            float[] againttypetable = new float[18];
            for(int i = 0; i < againttypetable.Length; i++)
            {
                againttypetable[i] = float.Parse(mass[i]);
            }
            int[] intmass = new int[8];
            intmass[0] = Convert.ToInt32(mass[18]); //attack
            intmass[1] = Convert.ToInt32(mass[19]); //base_total
            intmass[2] = Convert.ToInt32(mass[20]); //capture
            intmass[3] = Convert.ToInt32(mass[21]); //defense
            intmass[4] = Convert.ToInt32(mass[22]); //hp
            string name = mass[23];
            intmass[5] = Convert.ToInt32(mass[24]); //sp_attack
            intmass[6] = Convert.ToInt32(mass[25]); //sp_defence
            intmass[7] = Convert.ToInt32(mass[26]); //speed
            PokemonType type1 = (PokemonType)Enum.Parse(typeof(PokemonType), mass[27]);
             PokemonType?   type2 = mass[28] == "" ? null : (PokemonType)Enum.Parse(typeof(PokemonType), mass[28]);
            int generat = Convert.ToInt32(mass[29]);
            bool legend = Convert.ToBoolean(mass[30]);
            Pokemon poc = new Pokemon(intmass[0], intmass[1], intmass[2], intmass[3], intmass[4], intmass[5], intmass[6], intmass[7], generat, legend, name, type1, type2,againttypetable);
            Push(poc);
        }
    }

    public void Push(Pokemon pokemon)
    {
        int hasg = Math.Abs(pokemon.name.GetHashCode()%container.Length);
        if (container[hasg] == null)
        {
            container[hasg] = new Node(pokemon,null);
        }
        else
        {
            Node buf = container[hasg];
            container[hasg] = new Node(pokemon,buf);
        }
    }

    public Pokemon FindByName(string name)
    {
        int hash = Math.Abs(name.GetHashCode()) % container.Length;
        Node buf = container[hash];
        while (buf.pokemon.name != name)
        {
            buf = buf.next;
        }
        if (buf is null)
        {
            throw new NotImplementedException();
        }
        return buf.pokemon;
    }
}