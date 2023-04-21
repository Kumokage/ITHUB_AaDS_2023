using System.Globalization;
namespace PokemonGame;

public class PokemonCollection
{
    public class Node
    {
        public Pokemon pokemon;
        public Node? next;
        public Node(Pokemon pokemon,Node? next)
        {
            this.pokemon = pokemon;
            this.next = next;
        }
        public override string ToString()
        {
            return $"{pokemon.Name}\n\t{pokemon.Type1}-{pokemon.Type2}";
        }
    }
    const int SIZE = 1000;
    Node[] pokemons = new Node[SIZE];
    public PokemonCollection(string dataPath)
    {  
       ParseData(File.ReadAllLines(dataPath));
    }

    public void ParseData(string[] data)
    {
        for(int i = 0; i<data.Length; i++)
        {
            string[]SplitedData ;
            float[]AgainstTable = new float[18];
            SplitedData = data[i].Split(';');

            for(int j = 0; j < 18; j++)
            {
                AgainstTable[j]= float.Parse(SplitedData[j],CultureInfo.InvariantCulture);
            }
            Pokemon pokemon = new Pokemon(float.Parse(SplitedData[18]),int.Parse(SplitedData[19]),
                int.Parse(SplitedData[20]),float.Parse(SplitedData[21]),float.Parse(SplitedData[22]),
                int.Parse(SplitedData[24]),int.Parse(SplitedData[25]),
                int.Parse(SplitedData[26]), 
                int.Parse(SplitedData[29]),
                Convert.ToBoolean(int.Parse(SplitedData[30])),SplitedData[23], (PokemonType)Enum.Parse(typeof(PokemonType),SplitedData[27]),SplitedData[28]==""?null:(PokemonType)Enum.Parse(typeof(PokemonType),SplitedData[28]),AgainstTable);
            Push(pokemon);
        }
    }
    public void Push(Pokemon pokemon)
    {
        int hashKey = Math.Abs(pokemon.GetHashCode() % SIZE);
        if (pokemons[hashKey] is Node nodik)
        {
            Node new_node = new Node(pokemon,nodik);
        }
        else
        {
            pokemons[hashKey] = new Node(pokemon,null);
        }
    }

    public Pokemon FindByName(string name)
    {
       int hashKey = Math.Abs(name.GetHashCode() % SIZE);
        Node buff = pokemons[hashKey];
        while (buff is not null&&buff.pokemon.Name!=name)
        {
            buff.next = buff;
        }
        if(buff.pokemon.Name== name)
        {
            return buff.pokemon;
        }
        else
        {
            throw new Exception("Че-то матерное");
        }
    }
}