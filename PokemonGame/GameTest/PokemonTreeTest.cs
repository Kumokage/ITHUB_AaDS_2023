namespace GameTest;

using System.Globalization;
using PokemonGame;

[TestClass]
public class PokemonTreeTest
{
    private const int TEST_TREE_SIZE = 100;
    private const string TEST_DATA_PATH = "../../../../data/pokemon.csv";
    private readonly Pokemon[] collection = new Pokemon[TEST_TREE_SIZE];

    [TestInitialize]
    public void TestInitialize()
    {
        int index = 0;
        foreach (var line in File.ReadAllLines(TEST_DATA_PATH))
        {
            string[] pokemonData = line.Split(';');
            int pokemonTypesNumber = Enum.GetNames(typeof(PokemonType)).Length;
            float[] againstTypeTable = new float[pokemonTypesNumber];

            for (int i = 0; i < pokemonTypesNumber; ++i)
            {
                againstTypeTable[i] = float.Parse(pokemonData[i], CultureInfo.InvariantCulture);
            }

            collection[index] = new(
                float.Parse(pokemonData[pokemonTypesNumber]),
                int.Parse(pokemonData[pokemonTypesNumber + 1]),
                int.Parse(pokemonData[pokemonTypesNumber + 2]),
                float.Parse(pokemonData[pokemonTypesNumber + 3]),
                float.Parse(pokemonData[pokemonTypesNumber + 4]),
                int.Parse(pokemonData[pokemonTypesNumber + 6]),
                int.Parse(pokemonData[pokemonTypesNumber + 7]),
                int.Parse(pokemonData[pokemonTypesNumber + 8]),
                int.Parse(pokemonData[pokemonTypesNumber + 11]),
                int.Parse(pokemonData[pokemonTypesNumber + 12]) == 1,
                pokemonData[pokemonTypesNumber + 5],
                (PokemonType)Enum.Parse(typeof(PokemonType), pokemonData[pokemonTypesNumber + 9]),
                pokemonData[pokemonTypesNumber + 10] != "" ? (PokemonType)Enum.Parse(typeof(PokemonType), pokemonData[pokemonTypesNumber + 10]) : null,
                againstTypeTable
            );
            ++index;
            if (index == TEST_TREE_SIZE)
                return;
        }
    }

    [TestMethod]
    public void TestAdd()
    {
        PokemonTree tree = new();
        for (int i = 0; i < TEST_TREE_SIZE; ++i)
        {
            tree.Add(collection[i]);
        }
    }


    [TestMethod]
    public void TestSearch()
    {
        PokemonTree tree = new();
        for (int i = 0; i < TEST_TREE_SIZE; ++i)
        {
            tree.Add(collection[i]);
        }

        string find_name = tree.Search(collection[TEST_TREE_SIZE / 2].Name).Name;
        Assert.AreEqual(collection[TEST_TREE_SIZE / 2].Name, find_name);

        Assert.ThrowsException<ArgumentException>(() => tree.Search("sdfasdfas"));
    }

    [TestMethod]
    public void TestDelete()
    {
        PokemonTree tree = new();
        for (int i = 0; i < TEST_TREE_SIZE; ++i)
        {
            tree.Add(collection[i]);
        }

        Pokemon deleted_pokemon = tree.Delete(collection[TEST_TREE_SIZE / 2].Name);
        Assert.ThrowsException<ArgumentException>(() => tree.Search(deleted_pokemon.Name));
    }
}
