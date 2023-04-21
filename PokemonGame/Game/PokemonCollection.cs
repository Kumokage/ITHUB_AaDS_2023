using System.Globalization;
namespace PokemonGame;

public class PokemonCollection
{
    public class Node(Node next, int value)
    {
    public int value;
    public Pokemon pokemon;
    public Node next;
    public Node(Node next,int value,Pokemon pokemon)
    {
        this.next = next;
        this.value = value;
        this.pokemon = pokemon;
    }
    const int size = 1000;
    Node[] collection = new Node[size];

    public PokemonCollection(string dataPath)
    {
        string[] data = File.ReadAllLines (dataPatch);
        ParseData (data);
    }

    public void ParseData(string[] data)
    {
        string[] dataStroka;
       for (int i = 0; i < data.Length; i++)
        {
            dataStroka = data[i].Split (';');
        }
       float[] poremonCoef = new float[dataStroka.Length];
        int EachCoef = 0;
        int index = 0;
        for (int i = 0; i < 18; i++)
        {
            poremonCoef [i] = float.Parse (dataStroka [i]);
            index++;
        }
        Pokemon pokemon = new(
            float.Parse(data[poremonCoef],index)
            int.Parse(data[poremonCoef+1],index)
            int.Parse(data[poremonCoef+2],index)
            float.Parse(data[poremonCoef+3],index)
            string.Parse(data[poremonCoef+4],index) //name
            float.Parse(data[poremonCoef+5],index)
            float.Parse(data[poremonCoef+7],index)
            int.Parse(data[poremonCoef+8],index)
            PokemonType.Parse(data[poremonCoef+9],index) 
            PokemonType.Parse(data[poremonCoef+10],index) 
            int.Parse(data[poremonCoef+11],index)
            bool.Parse(data[poremonCoef+12],index)
      //      float.Parse(data[poremonCoef+13],index)
            );


    }

    public void Push(Pokemon pokemon)
    {
            int hash = Math.Abs(data.name.GetHashCode());
            if (container[hash] is null)
            {
                Node new_Node = new Node(pokemon,null);
            }
            else
            {
                Node buf = container[hash];
                container[hash] = new Node(pokemon,buf)
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
